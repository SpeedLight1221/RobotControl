


namespace RobotControl
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }
    }

    


    public interface IBluetoothConnector
    {
        List<string> GetConnectedDevices();
        void Connect(string deviceName);

        public void Write(byte[] data);
    }
}
