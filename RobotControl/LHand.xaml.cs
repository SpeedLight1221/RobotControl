
using RobotControl.Classes;
using System.Drawing;

namespace RobotControl
{

    public partial class LHand : ContentPage
    {
        public int L_PinkyAngle;
        public int L_RingAngle;
        public int L_MiddleAngle;
        public int L_IndexAngle;
        public int L_ThumbAngle;
        public int L_RotaAngle;



      
        public LHand()
        {
            InitializeComponent();
          

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (Settings.BTPermission == false)
            {
                await DisplayAlert("Bluetooth ", "Bluetooth permission not granted.", "ok");
            }
        }

      

    

        private async void LPinkySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (Settings.BTPermission == false) { return; }

            var connector = DependencyService.Get<IBluetoothConnector>();

            if (connector == null)
            {
                await DisplayAlert("er", "connector is null", "ok");
            }

            string arduino = connector.GetConnectedDevices().FirstOrDefault(x => x == "HC-05");

            if (arduino == null)
            {
                await DisplayAlert("Bluetooth", "Device not found!", "ok");
                return;
            }
            else
            {
                if (connector.Connect(arduino))
                {
                    connector.Write([2, 14, 255]);
                }

            }
        }

        private void LRingSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void LMiddleSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void LIndexSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void LThumbSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }
    }
}