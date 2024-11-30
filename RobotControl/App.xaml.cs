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
        bool Connect(string deviceName);

        public string test();
        public void Write(byte[] data);
    }
}
