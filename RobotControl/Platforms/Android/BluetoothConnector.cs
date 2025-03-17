using Android.Bluetooth;
using Java.Util;
using RobotControl.Platforms.Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: Dependency(typeof(BluetoothConnector))]
namespace RobotControl.Platforms.Android.Bluetooth
{
    class BluetoothConnector : IBluetoothConnector
    {



        BluetoothAdapter adapter;
        private const string SspUuid = "00001101-0000-1000-8000-00805F9B34FB";
        private BluetoothSocket? socket;
        public bool Connect(string deviceName)
        {
            var device = adapter.BondedDevices.FirstOrDefault(d => d.Name == deviceName);
            socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString(SspUuid));
            adapter.CancelDiscovery();  
            try
            {
                socket.Connect();
                
               
            }
            catch (Java.IO.IOException e)
            {
                return false;

            }



            if (socket.IsConnected) { return true; }
            else return false;

        }

        public void Disconnect()
        {
            if (socket != null || !socket.IsConnected) 
            { 
                socket.Close();
            }
        }

        public void Write(byte[] data)
        {
            foreach (byte b in data)
            {
                socket.OutputStream.WriteByte(b);
            }

        }


        public List<string> GetConnectedDevices()
        {
            adapter = BluetoothAdapter.DefaultAdapter;
            if (adapter == null)
            {
                throw new Exception("No Bluetooth adapter");
            }

            if (adapter.IsEnabled)
            {
                if (adapter.BondedDevices.Count > 0)
                {
                    return adapter.BondedDevices.Select(x => x.Name).ToList();
                }

            }
            else
            {
                Console.WriteLine("BT is not enabled");
            }

            return new List<string>();

        }

        public bool isConnected()
        {
            return socket.IsConnected;
        }










        public static async Task<bool> RequestPermisions()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Bluetooth>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Bluetooth>();
                if (status == PermissionStatus.Granted)
                    return true;
                else return false;

            }
            else
            {
                return true;
            }


        }

        




    }
}
