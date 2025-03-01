using RobotControl.Classes;

namespace RobotControl;

public partial class RHand : ContentPage
{
	public RHand()
	{
		InitializeComponent();
	}

    private void RPinky_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RPinky_Slider.Value;
        RPinky_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_Pinky").NewAngle = (byte)val;
    }

    private void RRing_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RRing_Slider.Value;
        RRing_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_Ring").NewAngle = (byte)val;
    }

    private void RMiddle_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RMiddle_Slider.Value;
        RMiddle_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_Middle").NewAngle = (byte)val;
    }

    private void RIndex_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RIndex_Slider.Value;
        RIndex_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_Index").NewAngle = (byte)val;
    }

    private void RThumb_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RThumb_Slider.Value;
        RThumb_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_Thumb").NewAngle = (byte)val;
    }

    private void RWrist_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RWrist_Slider.Value;
        RWrist_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_Wrist").NewAngle = (byte)val;
    }
}