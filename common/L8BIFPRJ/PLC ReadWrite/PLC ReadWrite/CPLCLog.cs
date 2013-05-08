using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PLC
{
    class CPLCLog
    {

        public void MakeLog(int[] iaSend, Device device, int iAddress, int iCount, bool bSuccess)
        {
            string sLog;
            string sDevice;
            string sHexData = "";
            string sSuccess;

            sSuccess = bSuccess ? "  Completed" : "  Fault";
            sDevice = GetDeviceString(device, iAddress);


            sLog = System.DateTime.Now.ToString("HH:mm:ss  ") + "Write To => PLC " + sDevice
                + " Count:" + iCount.ToString() + sSuccess + "\r\n";

            for (int i = 0; i < iaSend.Length; i++)
            {
                if (i == 0) sHexData = "[ Write Data ] " + "\t";

                sHexData += " " + iaSend[i].ToString("X4");

                if ((i + 1) % 20 == 0 && i > 0) sHexData += "\r\n  " + "\t\t";
            }
            //sHexData += " )" + "\r\n";
            sLog += sHexData + "\r\n" + "\r\n";
            SaveLog(sLog);
        }

        public void MakeLog(int iSend, Device device, int iAddress, bool bSuccess)
        {
            string sLog;
            string sDevice;
            string sSuccess;

            sSuccess = bSuccess ? "  Completed" : "  Fault";
            sDevice = GetDeviceString(device, iAddress);


            sLog = System.DateTime.Now.ToString("HH:mm:ss  ") + "Write To => PLC " + sDevice
                   + sSuccess + "\r\n";

            sLog += "[ Write Data ] " + "\t";
            sLog += " " + iSend.ToString("X4") + "\r\n" + "\r\n";

            SaveLog(sLog);
        }

        public void MakeLog(bool[] baSend,  int iAddress,Device device, int iCount, bool bSuccess)
        {
            string sLog;
            string sDevice;
            string sHexData = "";
            string sSuccess;
            string sTemp;

            sSuccess = bSuccess ? "  Completed" : "  Fault";
            sDevice = GetDeviceString(device, iAddress);


            sLog = System.DateTime.Now.ToString("HH:mm:ss  ") + "Write To => PLC " + sDevice
                + " Count:" + iCount.ToString() + sSuccess + "\r\n";

            for (int i = 0; i < baSend.Length; i++)
            {
                sTemp = baSend[i] ? "1" : "0";
                if (i == 0) sHexData = "[ Write Data ] " + "\t";

                sHexData += " " + sTemp;

                if ((i + 1) % 20 == 0 && i > 0) sHexData += "\r\n  " + "\t\t";
            }
            //sHexData += " )" + "\r\n";
            sLog += sHexData + "\r\n" + "\r\n";
            SaveLog(sLog);
        }

        public void MakeLog(bool bBit, Device device, int iAddress, bool bSuccess)
        {
            string sLog;
            string sDevice;
            string sSuccess;
            string sTemp;

            sSuccess = bSuccess ? "  Completed" : "  Fault";
            sDevice = GetDeviceString(device, iAddress);
            sTemp = bBit ? "1" : "0";

            sLog = System.DateTime.Now.ToString("HH:mm:ss  ") + "Write To => PLC " + sDevice
                + " " + sSuccess + "\r\n";

            sLog += "[ Write Data ] " + "\t" + sTemp + "\r\n" + "\r\n";
           
            SaveLog(sLog);
        }

        private string GetDeviceString(Device device, int iAddress)
        {
            string sDevice;
            
            if (device == Device.B || device == Device.W || device == Device.X || device == Device.Y)
                sDevice = "[" + device.ToString() + " " + iAddress.ToString("X6") + "]";
            else
                sDevice = "[" + device.ToString() + " " + iAddress.ToString("d6") + "]";

            return sDevice;
        }

        private void SaveLog(string sLog)
        {
            lock (this)
            {
                string sDirPath = @"c:\\log" + "\\" + System.DateTime.Now.ToString("yyMMdd");
                string sFileName = System.DateTime.Now.Hour.ToString("D2") + "_" + "PLClog.txt";
                string sPath = sDirPath + "\\" + sFileName;

                if (!Directory.Exists(sDirPath))
                    Directory.CreateDirectory(sDirPath);

                StreamWriter LogWrite = File.AppendText(sPath);

                if (!File.Exists(sPath))
                    File.CreateText(sPath);

                LogWrite.Write(sLog);
                LogWrite.Close();

            }
        }


    }
}
