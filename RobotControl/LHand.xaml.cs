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

        private async void SPinky_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            var connector = DependencyService.Get<IBluetoothConnector>();
            
            if(connector == null)
            {
                await DisplayAlert("er", "connector is null", "huh");
            }
            else
            {
                await DisplayAlert("er", "isnt null", "huh");
            }

            string x = "";
            foreach(string s in connector.GetConnectedDevices())
            {
                x += s + "\n";
            }

            await DisplayAlert("er", x+ "", "huh");



        }

        private void SRing_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void SMiddle_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void SIndex_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void SThumb_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }
    }
}