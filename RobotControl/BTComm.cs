using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl
{
    static class BTComm
    {/*

        private const string ArduinoConName = "HC-05";
        static BluetoothSocket? Socket;
        static IBluetoothConnector connector;
        public static bool EstablishConnection()
        {
            connector =DependencyService.Get<IBluetoothConnector>();
            var RobotConnector = connector.GetConnectedDevices().FirstOrDefault(d => d== ArduinoConName);

            if (RobotConnector != null) {
                connector.Connect(RobotConnector);

                return true;    
            }    
            else
            {
                return false;
            }
        }


        public static void SendData(string data)
        {
            connector.Write(Encoding.ASCII.GetBytes(data));
        }
        */
    }
}
