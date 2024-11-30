using RobotControl.Classes;

namespace RobotControl
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            Setup();
        }

        public async void Setup()
        {
            Settings.BTPermission = await RequestPermisions();
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



        private async Task<bool> RequestPermisions()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Bluetooth>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Bluetooth>();
                if (status == PermissionStatus.Granted) 
                    return true;
                else return false;
              
            }
            else
            {
                return true;
            }
        }
    }

}
