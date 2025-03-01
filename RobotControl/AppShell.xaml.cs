
using RobotControl.Classes;
using System.Diagnostics;



namespace RobotControl
{
    public partial class AppShell : Shell
    {
        //public static AppShell instance;
        public AppShell()
        {
            InitializeComponent();
            //instance = this;
              Started = DateTime.Now;
            
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

        private DateTime Started;
        private int LastSend = 0;
        private TimeSpan GetTimeSinceStart()
        {
            return DateTime.Now - Started;
        }

        private async void Send_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("time", GetTimeSinceStart().Seconds + "///" + LastSend, "s");
            if(GetTimeSinceStart().Seconds > LastSend + 5)
            {
                LastSend = GetTimeSinceStart().Seconds;
                BTComm.SendPositions();

              
                foreach(ServoData d in ServoData.ServoDataList)
                {
                   
                    d.CurrentAngle = d.NewAngle;
                }
                

            }
            else
            {
                await DisplayAlert("Delay", "The send button is on delay. Please wait a few seconds before sending again","Ok");
            }
        }
    } 

}
