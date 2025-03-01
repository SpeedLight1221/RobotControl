using RobotControl.Classes;

namespace RobotControl;

public partial class RArm : ContentPage
{
	public RArm()
	{
		InitializeComponent();

	}

    private void RShoulder_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RShoulder_Slider.Value;
        RShoulder_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_Shoulder").NewAngle = (byte)val;
    }

    private void RRotShould_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RRotShould_Slider.Value;
        RRotShould_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_RotaShoulder").NewAngle = (byte)val;
    }

    private void RRotBicep_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RRotBicep_Slider.Value;
        RRotBicep_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_RotaBicep").NewAngle = (byte)val;
    }

    private void RBicep_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int val = (int)RBicep_Slider.Value;
        RBicep_Label.Text = val.ToString();
        ServoData.ServoDataList.Find(x => x.Name == "Right_Bicep").NewAngle = (byte)val;
    }
}