
using RobotControl.Classes;



namespace RobotControl
{
    public partial class AppShell : Shell
    {
        //public static AppShell instance;
        public AppShell()
        {
            InitializeComponent();
            //instance = this;
        }

        private async void BTConnBtn_Clicked(object sender, EventArgs e)
        {
            if (BTComm.BTConnector != null && BTComm.BTConnector.isConnected() )
            { 
                BTComm.BTConnector.Disconnect();
                BTConnBtn.Text = "⥮";


            }
            else
            {
                string result = await BTComm.ConnectToArduino();

                if(result == "")
                {
                    BTConnBtn.Text = "✓";
                }
                else
                {
                    DisplayAlert("Connection failed", result, "Dismiss");
                }
               
            }

            

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

        public string FindDevice()
        {
            return BTComm.BTConnector.GetConnectedDevices().FirstOrDefault(x => x == "HC-05");
        }

        

    } 

}
