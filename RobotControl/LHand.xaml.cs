
using RobotControl.Classes;
using System.Drawing;

namespace RobotControl
{

    public partial class LHand : ContentPage
    {
        public int LPinky_Angle;
        public int LRing_Angle;
        public int LMiddle_Angle;
        public int LIndex_Angle;
        public int LThumb_Angle;
        public int LRota_Angle;



      
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
            LPinky_Label.Text = (LPinky_Angle +=1).ToString();

            
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