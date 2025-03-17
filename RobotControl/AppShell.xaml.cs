
using RobotControl.Classes;
using System.Diagnostics;
using System.Timers;




namespace RobotControl
{
    public partial class AppShell : Shell
    {
        public static AppShell instance;
        System.Timers.Timer SendDelay = new System.Timers.Timer(5000);
        public bool isOnDelay = false;
        public AppShell()
        {
            InitializeComponent();
            instance = this;
            SendDelay.AutoReset = false;
            SendDelay.Elapsed += DelayOver;


        }

        private void DelayOver(Object source, ElapsedEventArgs e)
        {
            Debug.Print("OVer");
            isOnDelay = false;
            Dispatcher.Dispatch(() =>
            {
                SendBtn.Text = "Send";
                SendBtn.BackgroundColor = new Color(81, 43, 212);
            });
        }

        private async void BTConnBtn_Clicked(object sender, EventArgs e)
        {
            if (BTComm.BTConnector != null && BTComm.BTConnector.isConnected())
            {
                BTComm.BTConnector.Disconnect();
                BTConnBtn.Text = "⥮";


            }
            else
            {
                string result = await BTComm.ConnectToArduino();

                if (result == "")
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



        private async void Send_Clicked(object sender, EventArgs e)
        {
            if (BTComm.BTConnector == null)
            {
                await DisplayAlert("Error", "BT not connected", "Ok");
                return;
            }

            if(isOnDelay)
            {

                await DisplayAlert("Error", "Send function is on delay", "Ok");
                return;
            }
              


           isOnDelay= true;
            SendBtn.Text = "...";
            SendBtn.BackgroundColor =Colors.Gray;


            BTComm.SendPositions();


            foreach (ServoData d in ServoData.ServoDataList)
            {

                d.CurrentAngle = d.NewAngle;
            }
            Debug.Print("Start");
            SendDelay.Start();
       


        }
    }

}
