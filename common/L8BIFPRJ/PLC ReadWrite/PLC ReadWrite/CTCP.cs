using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;

namespace TCPBase
{
    public enum ConState { None = 0, listen, Opening, Opened, Connected };

    public class CTCPIP
    {
        #region Define Area

        protected bool m_bPassive;
        protected int m_iPortNum = 0;
        protected string m_sIPAddress;
        protected ConState m_enConState = ConState.None;
        protected Socket m_ServerSocket;
        protected Socket m_ClientSocket;
        protected Thread TCPThread;
        protected bool m_bStop = false;

        private IPGlobalProperties properties;
        private TcpConnectionInformation[] connections;


        #endregion

        public virtual void TCPLoop()
        {


            while (!m_bStop)
            {
                if (m_enConState < ConState.Connected)
                {
                    if (m_bPassive) //Is Server
                    {

                        if (m_enConState == ConState.listen)
                        {
                            m_ClientSocket = m_ServerSocket.Accept();
                            m_enConState = ConState.Connected;

                        }
                        else //Server Socket is not Listening
                        {
                            if (ServerListen()) m_enConState = ConState.listen;

                        }
                    }
                    else //Is Client
                    {
                        if (m_enConState < ConState.Connected)
                        {
                            if (ClientConnect()) m_enConState = ConState.Connected;
                            else m_enConState = ConState.Opening; 
                        }
                    }
                }

                if (m_enConState == ConState.Connected)
                {
                    if (!IsConnect(m_iPortNum))
                    {
                        CloseSocket();
                    }
                }

                Thread.Sleep(10);
            }
        }

        protected int ReadSocket(ref byte[] Buffer)
        {

            int RecLen = -1;
            byte[] RecByte = new byte[1941];

            if (m_enConState == ConState.Connected)
            {
                try
                {
                    RecLen = m_ClientSocket.Receive(RecByte);
                    Buffer = new byte[RecLen];
                    Array.Copy(RecByte, Buffer, RecLen);

                    if (RecLen == 0)
                    {
                        RecLen = -1;
                        CloseSocket();
                    }
                }
                catch (Exception)
                {
                    RecLen = -1;
                }
            }
            return RecLen;
        }

        protected int ReadSocket(ref byte[] Buffer, int iReqLen)
        {

            int iGotLen = 0;
            int iTCPLen = 0;
            int iRemainLen = iReqLen;
            byte[] RecByte = new byte[iReqLen];
            Buffer = new byte[iReqLen];

                do
                {
                    try
                    {
                        iTCPLen = m_ClientSocket.Receive(RecByte, iRemainLen, 0);

                        if (iTCPLen > 0)
                        {
                            Array.Copy(RecByte, 0, Buffer, iGotLen, iTCPLen);
                            iGotLen += iTCPLen;
                            iRemainLen = iReqLen - iGotLen;
                        }

                        if (iTCPLen == 0)
                        {
                            iGotLen = -1;
                            CloseSocket();
                            return iGotLen;
                        }
                    }
                    catch (SocketException)
                    {
                        iGotLen = -1;
                        break;
                    }
                    catch (Exception)
                    {
                        iGotLen = -1;
                        break;
                    }

                } while (iGotLen < iReqLen);
  
            return iGotLen;
        }

        protected int SendSocket(byte[] SendByte, int size)
        {

            int SendLen=0;


                try
                {
                    SendLen = m_ClientSocket.Send(SendByte, size, SocketFlags.None);
                    //m_ClientSocket.Send(SendByte, 0, size, SocketFlags.None);

                }
                catch (Exception)
                {
                    SendLen = -1;
                }
 
           
            return SendLen;
        }

        public void TCPInitial(string IPAddress, int Port, bool Mode)
        {
            m_sIPAddress = IPAddress;
            m_iPortNum = Port;
            m_bPassive = Mode;

            TCPThread = new Thread(new ThreadStart(TCPLoop));
            TCPThread.Start();
        }

        public void TCPInitial()
        {
            TCPThread = new Thread(new ThreadStart(TCPLoop));
            TCPThread.Start();
        }

        protected bool ServerListen()
        {
            try
            {
                m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                m_ServerSocket.Bind(new IPEndPoint(IPAddress.Parse(m_sIPAddress), m_iPortNum));
                m_ServerSocket.Listen(10);

                return true;
            }

            catch
            {
                m_ServerSocket = null;
                return false;
            }
        }

        protected bool ClientConnect()
        {
            try
            {
                m_enConState = ConState.Opening;
                m_ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                m_ClientSocket.Connect(IPAddress.Parse(m_sIPAddress), m_iPortNum);

                return true;
            }
            catch (Exception)
            {
                m_ClientSocket = null;
                Thread.Sleep(500);
                return false;
            }

        }

        protected bool IsConnect(int PortNO)
        {
            bool Connect = false;
            properties = IPGlobalProperties.GetIPGlobalProperties();
            connections = properties.GetActiveTcpConnections();

            if (connections.Length > 0)
            {
                foreach (TcpConnectionInformation TCPinfor in connections)
                {

                    if (TCPinfor.State == TcpState.Established & TCPinfor.RemoteEndPoint.Port == PortNO)
                    {
                        Connect = true;
                    }
                }
            }
           
            return Connect;
        }

        protected void CloseSocket()
        {
            m_ClientSocket.Shutdown(SocketShutdown.Both);  // is have problam
            m_ClientSocket.Close();

            Thread.Sleep(100);

            if (m_bPassive) m_enConState = ConState.listen; 
            
            else  m_enConState = ConState.Opening; 

        }

        public string ConnectStatus
        {
            get { return m_enConState.ToString(); }

        }



    }



}



