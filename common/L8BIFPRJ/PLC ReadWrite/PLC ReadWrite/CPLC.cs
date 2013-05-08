using System;
using System.Threading;

namespace PLC
{

    public enum Device
    {
        D = 0xA8,
        W = 0xB4,
        R = 0xAF,
        ZR = 0xB0,
        X = 0x9C,
        B = 0xA0,
        M = 0x90,
        Y = 0x9D,
    }


    public class CPLCRW : TCPBase.CTCPIP
    {

        #region Class Member

       // private byte[] m_SendWordWrite ;//= new byte[2560];

       // private byte[] m_SendWordRead = new byte[21];

        private CPLCLog m_Logger = new CPLCLog();

        private bool m_bLogEnable;

        #endregion


        #region Class Public Funtion

        //    Write Word   
        public bool WriteWord(int[] aWriteWord, int StartAddress, Device device, short Count)
        {

            bool bRet = false;
            int RecLen;
            int MessageLen;
            byte Header;
            byte[] ByteArr = new byte[0];
            byte[] rec_Buff = new byte[0];
            int nSendLen = 21 + Count * 2;
            byte[] SendWordWrite = new byte[nSendLen];

            lock (this)
            {
                if (m_enConState == TCPBase.ConState.Connected & IsWordDevice(device))
                {
                    WordWriteIniFormat(ref SendWordWrite);
                    Header = (byte)device;
                    MakeSendByteArr(aWriteWord, ref ByteArr, Count);

                    SendWordWrite[7] = (byte)((0x0c + Count * 2) % 0x100);	//Request data length(2byte)
                    SendWordWrite[8] = (byte)((0x0c + Count * 2) / 0x100);
                    SendWordWrite[13] = 0x0;   //sub-command(2byte)
                    SendWordWrite[14] = 0x0;
                    SendWordWrite[15] = (byte)(StartAddress % 0x100);
                    SendWordWrite[16] = (byte)(StartAddress / 0x100);
                    SendWordWrite[18] = Header;
                    SendWordWrite[19] = (byte)(Count % 0x100);
                    SendWordWrite[20] = (byte)(Count / 0x100);

                    Array.Copy(ByteArr, 0, SendWordWrite, 21, ByteArr.Length);

                    SendSocket(SendWordWrite, nSendLen);
                    RecLen = ReadSocket(ref rec_Buff, 9);

                    if (RecLen == 9)
                    {
                        MessageLen = rec_Buff[7] + rec_Buff[8] * 0x100;
                        ReadSocket(ref rec_Buff, MessageLen);

                        if (rec_Buff[0] == 0 && rec_Buff[1] == 0)
                            bRet = true;
                    }
                }

                if (m_bLogEnable) m_Logger.MakeLog(aWriteWord, device, StartAddress, Count, bRet);
            }
            return bRet;

        }

        public bool WriteWord(int WriteWord, int StartAddress, Device device)//, short Count)
        {

            bool bRet = false;
            int RecLen;
            int MessageLen;
            byte Header;
            //byte[] ByteArr = new byte[2];
            byte[] rec_Buff = new byte[0];
            //int nSendLen = 23;  //int nSendLen = 21 + Count * 2;
            byte[] SendWordWrite = new byte[23];

            lock (this)
            {
                if (m_enConState == TCPBase.ConState.Connected & IsWordDevice(device))
                {
                    WordWriteIniFormat(ref SendWordWrite);
                    Header = (byte)device;
                    //MakeSendByteArr(aWriteWord, ref ByteArr);

                    SendWordWrite[7] = 0x0c + 2;  //(byte)((0x0c + Count * 2) % 0x100);	//Request data length(2byte)
                    SendWordWrite[8] = 0;         //(byte)((0x0c + Count * 2) / 0x100);
                    SendWordWrite[13] = 0x0;      //sub-command(2byte)
                    SendWordWrite[14] = 0x0;
                    SendWordWrite[15] = (byte)(StartAddress % 0x100);
                    SendWordWrite[16] = (byte)(StartAddress / 0x100);
                    SendWordWrite[18] = Header;
                    SendWordWrite[19] = 1;//(byte)(Count % 0x100);
                    SendWordWrite[20] = 0; //(byte)(Count / 0x100);
                    SendWordWrite[21] = (byte)(WriteWord % 0x100);
                    SendWordWrite[22] = (byte)(WriteWord / 0x100);

                    // Array.Copy(ByteArr, 0, m_SendWordWrite, 21, ByteArr.Length);

                    SendSocket(SendWordWrite, 23);
                    RecLen = ReadSocket(ref rec_Buff, 9);

                    if (RecLen == 9)
                    {
                        MessageLen = rec_Buff[7] + rec_Buff[8] * 0x100;
                        ReadSocket(ref rec_Buff, MessageLen);

                        if (rec_Buff[0] == 0 && rec_Buff[1] == 0)
                            bRet = true;
                    }
                }

                if (m_bLogEnable) m_Logger.MakeLog(WriteWord, device, StartAddress, bRet);
            }
            return bRet;
        }

        //    Write Bit Array 
        public bool WriteBit(bool[] WriteBitAy, int StartAddress, Device device, short Count)
        {
            bool bRet = false;
            int RecLen;
            int MessageLen;
            byte Header;
            byte[] ByteArr = new byte[0];
            byte[] rec_Buff = new byte[0];
            int nLen = Count / 2 + Count % 2;
            byte[] SendWordWrite = new byte[nLen + 21];

            lock (this)
            {
                if (m_enConState == TCPBase.ConState.Connected & IsBitDevice(device))
                {
                    WordWriteIniFormat(ref SendWordWrite);
                    Header = (byte)device;
                    MakeSendByteArr(WriteBitAy, ref ByteArr, Count);

                    SendWordWrite[7] = (byte)((0x0c + nLen) % 0x100);	//Request data length(2byte)
                    SendWordWrite[8] = (byte)((0x0c + nLen) / 0x100);
                    SendWordWrite[13] = 0x1;   //sub-command(2byte) Write Bit
                    SendWordWrite[14] = 0x0;
                    SendWordWrite[15] = (byte)(StartAddress % 0x100);
                    SendWordWrite[16] = (byte)(StartAddress / 0x100);
                    SendWordWrite[18] = Header;
                    SendWordWrite[19] = (byte)(Count % 0x100);
                    SendWordWrite[20] = (byte)(Count / 0x100);

                    Array.Copy(ByteArr, 0, SendWordWrite, 21, ByteArr.Length);

                    SendSocket(SendWordWrite, nLen + 21);
                    RecLen = ReadSocket(ref rec_Buff, 9);

                    if (RecLen == 9)
                    {
                        MessageLen = rec_Buff[7] + rec_Buff[8] * 0x100;
                        ReadSocket(ref rec_Buff, MessageLen);

                        if (rec_Buff[0] == 0 && rec_Buff[1] == 0)
                            bRet = true;
                    }
                }

                if (m_bLogEnable) m_Logger.MakeLog(WriteBitAy, StartAddress, device, Count, bRet);
            }
            return bRet;
        }

        //    Write Bit 
        public bool WriteBit(bool WriteBit, int StartAddress, Device device)
        {
            bool bRet = false;
            int RecLen;
            int MessageLen;
            byte Header;
            byte[] ByteArr = new byte[0];
            byte[] rec_Buff = new byte[0];
            byte[] SendWordWrite = new byte[22];

            lock (this)
            {
                if (m_enConState == TCPBase.ConState.Connected & IsBitDevice(device))
                {
                    WordWriteIniFormat(ref SendWordWrite);
                    Header = (byte)device;

                    SendWordWrite[7] = 0x0D;	//Request data length(2byte)
                    SendWordWrite[8] = 0x0;
                    SendWordWrite[13] = 0x1;   //sub-command(2byte) Write Bit
                    SendWordWrite[14] = 0x0;
                    SendWordWrite[15] = (byte)(StartAddress % 0x100);
                    SendWordWrite[16] = (byte)(StartAddress / 0x100);
                    SendWordWrite[18] = Header;
                    SendWordWrite[19] = 0x01;
                    SendWordWrite[20] = 0x0;
                    SendWordWrite[21] = (byte)(Convert.ToByte(WriteBit) * 0x10);

                    SendSocket(SendWordWrite, 22);
                    RecLen = ReadSocket(ref rec_Buff, 9);

                    if (RecLen == 9)
                    {
                        MessageLen = rec_Buff[7] + rec_Buff[8] * 0x100;
                        ReadSocket(ref rec_Buff, MessageLen);

                        if (rec_Buff[0] == 0 && rec_Buff[1] == 0)
                            bRet = true;
                    }
                }

                if (m_bLogEnable) m_Logger.MakeLog(WriteBit, device, StartAddress, bRet);
            }
            return bRet;
        }

        //    Read Word 
        public bool ReadWord(int StartAddress, Device device, ref int[] ReadWord, short Count)
        {
            bool bRet = false;
            int RecLen;
            int MessageLen;
            byte Header = (byte)device;
            int nSendLen = 21;
            Int16[] NArr = new Int16[0];
            byte[] ByteArr = new byte[0];
            byte[] rec_Buff = new byte[0];
            //byte[] SendWordWrite = new byte[nSendLen];
            byte[] SendWordRead = new byte[21];

            lock (this)
            {
                if (m_enConState == TCPBase.ConState.Connected & IsWordDevice(device))
                {
                    WordReadIniFormat(ref SendWordRead);

                    Header = (byte)device;

                    SendWordRead[13] = 0x0;	//sub-command(2byte)
                    SendWordRead[14] = 0x0;
                    SendWordRead[16] = (byte)(StartAddress / 0x100);
                    SendWordRead[15] = (byte)(StartAddress % 0x100);
                    SendWordRead[18] = Header;
                    SendWordRead[19] = (byte)(Count % 0x100);
                    SendWordRead[20] = (byte)(Count / 0x100);

                    Array.Copy(ByteArr, 0, SendWordRead, 21, ByteArr.Length);

                    SendSocket(SendWordRead, nSendLen);
                    RecLen = ReadSocket(ref rec_Buff, 9);

                    if (RecLen == 9)
                    {
                        MessageLen = rec_Buff[7] + rec_Buff[8] * 0x100;
                        ReadSocket(ref rec_Buff, MessageLen);

                        if (rec_Buff[0] == 0 && rec_Buff[1] == 0)
                        {
                            ReadWord = PLCDataToNumArr(rec_Buff);
                            bRet = true;
                        }
                    }
                }
            }
            return bRet;
        }

        //    Read Bit
        public bool ReadBit(int StartAddress, Device device, ref bool[] ReadBit, short Count)
        {
            bool bRet = false;
            int RecLen;
            int MessageLen;
            byte Header = (byte)device;
            int nSendLen = 21;
            Int16[] NArr = new Int16[0];
            byte[] ByteArr = new byte[0];
            byte[] rec_Buff = new byte[0];
            //byte[] SendWordWrite = new byte[nSendLen];
            byte[] SendWordRead = new byte[21];

            lock (this)
            {
                if (m_enConState == TCPBase.ConState.Connected & IsBitDevice (device))
                {
                    WordReadIniFormat(ref SendWordRead);

                    Header = (byte)device;

                    SendWordRead[13] = 0x1;	//sub-command(2byte)
                    SendWordRead[14] = 0x0;
                    SendWordRead[16] = (byte)(StartAddress / 0x100);
                    SendWordRead[15] = (byte)(StartAddress % 0x100);
                    SendWordRead[18] = Header;
                    SendWordRead[19] = (byte)(Count % 0x100);
                    SendWordRead[20] = (byte)(Count / 0x100);

                    Array.Copy(ByteArr, 0, SendWordRead, 21, ByteArr.Length);

                    SendSocket(SendWordRead, nSendLen);
                    RecLen = ReadSocket(ref rec_Buff, 9);

                    if (RecLen == 9)
                    {
                        MessageLen = rec_Buff[7] + rec_Buff[8] * 0x100;
                        ReadSocket(ref rec_Buff, MessageLen);

                        if (rec_Buff[0] == 0 && rec_Buff[1] == 0)
                        {
                            ReadBit = PLCDataToBoolArr(rec_Buff, Count);
                            bRet = true;
                        }
                    }
                }
            }
            return bRet;
        }


        public void Close()
        {
            m_bStop = true;
        }

        #endregion


        #region Class Member Funtion

        private int MakeSendByteArr(int[] NumArr, ref byte[] ByteArr, int Count)
        {

            ByteArr = new byte[Count * 2];
            for (int i = 0; i < Count; i++)
            {
                ByteArr[i * 2] = (byte)(NumArr[i] % 0x100);
                ByteArr[i * 2 + 1] = (byte)(NumArr[i] / 0x100);

            }
            return NumArr.Length * 2;

        }

        private int MakeSendByteArr(bool[] BoolArr, ref byte[] ByteArr, int Count)
        {
            int Temp1, Temp2;
            ByteArr = new byte[Count / 2];
            for (int i = 0; i < Count; i++)
            {
                Temp1 = (Convert.ToByte(BoolArr[i * 2])) * 0x10;
                Temp2 = Convert.ToByte(BoolArr[i * 2 + 1]);
                ByteArr[i] = (byte)(Temp1 + Temp2);
            }
            return ByteArr.Length;
        }

        private int[] PLCDataToNumArr(byte[] ByteArr)
        {

            int[] NumArr = new int[(ByteArr.Length - 2) / 2];
            for (int i = 0; i < NumArr.Length; i++)
            {
                NumArr[i] = (ByteArr[i * 2 + 2] + (ByteArr[i * 2 + 3] * 0x100));
            }
            return NumArr;

        }

        private bool[] PLCDataToBoolArr(byte[] ByteArr, int Count)
        {
            int iIndex;
            int iRemain;
            bool[] boolArr;

            if ((ByteArr.Length - 2) * 2 < Count)
                Count = (ByteArr.Length - 2) * 2;

            boolArr = new bool[Count];

            for (int i = 0; i < Count; i++)
            {
                iIndex = i / 2;
                iRemain = i % 2;
                if (iRemain == 0)
                    boolArr[i] = Convert.ToBoolean(ByteArr[iIndex + 2] & 0x10);
                else if (iRemain == 1)
                    boolArr[i] = Convert.ToBoolean(ByteArr[iIndex + 2] & 0x01);
            }
            return boolArr;
        }



        private void WordReadIniFormat(ref  byte[] WordRead )
        {
            WordRead[0] = 0x50;	//Sub-Header(2byte)
            WordRead[1] = 0x0;
            WordRead[2] = 0x0;		//Network Number.
            WordRead[3] = 0xFF;	//PLC number.
            WordRead[4] = 0xFF;	//Request taget module I/O number(2byte)
            WordRead[5] = 0x3;
            WordRead[6] = 0x0;		//Request taget module station number
            WordRead[7] = 0x0C;	//Request data length(2byte)--//from array[9] start count 0xC number
            WordRead[8] = 0x0;
            WordRead[9] = 0x10;	//CPU monitoring timer(2byte)
            WordRead[10] = 0x0;
            WordRead[11] = 0x1;	//command(2byte)=0x0401
            WordRead[12] = 0x4;

            WordRead[15] = 0x1;	//Request data section.
            WordRead[16] = 0x0;
            WordRead[17] = 0x0;
            WordRead[18] = 0xA8;
            WordRead[19] = 0xC;
            WordRead[20] = 0x3;



        }


        private void WordWriteIniFormat(ref byte[] WordWrite)
        {


            //***********************************
            WordWrite[0] = 0x50;   //Subheader(2byte)
            WordWrite[1] = 0x0;
            WordWrite[2] = 0x0;    //Network NO.
            WordWrite[3] = 0xFF;   //PLC NO>
            WordWrite[4] = 0xFF;   //Request taget module I/O number(2byte)
            WordWrite[5] = 0x3;
            WordWrite[6] = 0x0;    //Request taget module station number

            WordWrite[9] = 0x10;   //CPU monitoring timer(2byte)
            WordWrite[10] = 0x0;
            WordWrite[11] = 0x1;   //command(2byte)=0x1401
            WordWrite[12] = 0x14;

            WordWrite[17] = 0x0;
            WordWrite[18] = 0xA8;

        }

        private bool IsWordDevice(Device device)
        {
            bool bRet=false ;

            if (device == Device.D || device == Device.W || device == Device.R || device == Device.ZR)
                bRet = true;

            return bRet;
        }

        private bool IsBitDevice(Device device)
        {
            bool bRet = false;

            if (device == Device.B || device == Device.M || device == Device.X || device == Device.Y)
                bRet = true;

            return bRet;
            
        }


        #endregion

        public bool LogWritePLC
        {
            get { return m_bLogEnable; }

            set { m_bLogEnable = value; }
        }





    }
}
