
using RobotControl.Classes;
using System.Drawing;

namespace RobotControl
{

    public partial class LHand : ContentPage
    {
     



      
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

      

    

        private  void LPinkySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int val = (int)LPinky_Slider.Value;
            LPinky_Label.Text = val.ToString();
            ServoData.ServoDataList.Find(x => x.Name == "Left_Pinky").NewAngle = (byte)val;


        }

        private void LRingSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int val = (int)LRing_Slider.Value;
            LRing_Label.Text = val.ToString();
            ServoData.ServoDataList.Find(x => x.Name == "Left_Ring").NewAngle = (byte)val;
        }

        private void LMiddleSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int val = (int)LMiddle_Slider.Value;
            LMiddle_Label.Text = val.ToString();
            ServoData.ServoDataList.Find(x => x.Name == "Left_Middle").NewAngle = (byte)val;
        }

        private void LIndexSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int val = (int)LIndex_Slider.Value;
            LIndex_Label.Text = val.ToString();
            ServoData.ServoDataList.Find(x => x.Name == "Left_Index").NewAngle = (byte)val;
        }

        private void LThumbSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int val = (int)LThumb_Slider.Value;
            LThumb_Label.Text = val.ToString();
            ServoData.ServoDataList.Find(x => x.Name == "Left_Thumb").NewAngle = (byte)val;
        }

        private void LWrist_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int val = (int)LWrist_Slider.Value;
            LWrist_Label.Text = val.ToString();
            ServoData.ServoDataList.Find(x => x.Name == "Left_Wrist").NewAngle = (byte)val;
        }
    }
}