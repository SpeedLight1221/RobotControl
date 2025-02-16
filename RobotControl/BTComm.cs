
#if ANDROID
using Android.Bluetooth;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotControl.Classes;

namespace RobotControl
{
    static  class BTComm
    {   
       public static async void SendPositions()
       {
            foreach (ServoData s in ServoData.ServoDataList.Where(x=> x.NewAngle != x.CurrentAngle)) 
            {
                BTComm.BTConnector.Write(new byte[] {(byte)s.Side,(byte)s.Symbol,s.NewAngle });

            }
       }


        public static async void SendBytes(byte[] bytes) 
        { 
            if(bytes != null &&bytes.Length ==3 )
            {
                BTComm.BTConnector.Write(bytes);
            }
        }

        public static IBluetoothConnector BTConnector;

        public static async Task<string> ConnectToArduino()
        {
            if (await BTComm.CheckBTPerms() == false)
            {
              
                return "Bluetooth permission are required";
            }
            else
            {
                Settings.BTPermission = true;
            }

            if (!GetConnector())
            {
               
                return "Bluetooth Connector not found";
            }



            string Device = FindDevice();
            if (Device == null)
            {
               
                return "Device not found";
            }

            if (!BTComm.BTConnector.Connect(Device))
            {

                
                return "Connection Failed";
            }



            return "";
        }








        public static async Task<bool> CheckBTPerms()
        {
#if ANDROID
            if (Settings.BTPermission == true)
            {
                return true;
            }
            else
            {
                return await Platforms.Android.Bluetooth.BluetoothConnector.RequestPermisions();
            }


#endif

            return false;
        }


        public static bool GetConnector()
        {
            BTComm.BTConnector = DependencyService.Get<IBluetoothConnector>();

            if (BTComm.BTConnector == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string FindDevice()
        {
            return BTComm.BTConnector.GetConnectedDevices().FirstOrDefault(x => x == "HC-05");
        }
    }
}
