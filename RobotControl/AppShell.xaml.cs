
using RobotControl.Classes;



namespace RobotControl
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void BTConnBtn_Clicked(object sender, EventArgs e)
        {
            if (Settings.BTConnector != null && Settings.BTConnector.isConnected() )
            { 
                Settings.BTConnector.Disconnect();
                BTConnBtn.Text = "⥮";


            }
            else
            {

                BTConnBtn.Text = await ConnectToArduino();
            }

            

        }


        public async Task<string> ConnectToArduino()
        {
            if (await CheckBTPerms() == false)
            {
                await DisplayAlert("Connection Error", "Bluetooth permission are required", "Dismiss");
                return "⤫";
            }
            else
            {
                Settings.BTPermission = true;
            }

            if (!GetConnector())
            {
                await DisplayAlert("Connection Error", "Bluetooth Connector not found", "Dismiss");
                return "⤫";
            }



            string Device = FindDevice();
            if (Device == null)
            {
                await DisplayAlert("Connection Error", "Device not found", "Dismiss");
                return "⤫";
            }

            if (!Settings.BTConnector.Connect(Device))
            {

                await DisplayAlert("Connection Error", "Connection Failed", "Dismiss");
                return "⤫";
            }


            
            return "✓";
        }








        public async Task<bool> CheckBTPerms()
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


        public bool GetConnector()
        {
            Settings.BTConnector = DependencyService.Get<IBluetoothConnector>();

            if (Settings.BTConnector == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string FindDevice()
        {
            return Settings.BTConnector.GetConnectedDevices().FirstOrDefault(x => x == "HC-05");
        }

        

    } 

}
