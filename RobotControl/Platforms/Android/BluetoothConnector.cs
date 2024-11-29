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
        private const string SspUuid = "00001101-0000-1000-8000-00805f9b34fb";
        private BluetoothSocket? socket;
        public void Connect(string deviceName)
        {
            var device = adapter.BondedDevices.FirstOrDefault(d=> d.Name == deviceName);
            socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString(SspUuid));
            socket.Connect();
        
        }

        public void Write(byte[] data) 
        { 
        
        }


        public string test()
        {
            return "tested";
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
                if(adapter.BondedDevices.Count >0)
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
    }



}
