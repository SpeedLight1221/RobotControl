namespace RobotControl
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("///LHandPage");
            }
            catch (Exception ex)
            {
                
            }
        }
    }

}
