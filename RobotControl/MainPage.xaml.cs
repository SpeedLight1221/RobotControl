using RobotControl.Classes;


namespace RobotControl
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void QuickPos_Clicked(object sender, EventArgs e)
        {
            string num = (sender as Button).StyleId[1].ToString();
            byte i = byte.Parse(num); // Gets the number of the button and uses it to find a quickposition with the matching ID
            await DisplayAlert("h", i.ToString(), "h");
            QuickPosition q = QuickPosition.QuickPositions.Where(x => x.id == i).FirstOrDefault();
            if (q != null)// if  found, sends the angles saved in the quickpos to the arduino
            {
               
                QuickPosition.SetQuickPos(q);
               
            }
            else// if not found, prompts for a name and creates a new one from the currently set angles
            {
                string newName = await DisplayPromptAsync($"Position {i}", "Insert Name", "Ok", "Cancel", maxLength: 5);

                if (newName == null ||newName == "") 
                {
                    newName = "Pos " + i;
                }



                q = new QuickPosition() { id = i, Name = newName };

                foreach (ServoData s in ServoData.ServoDataList) 
                {
                 

                        q.Angles.Add(new byte[] { (byte)s.Side, (byte)s.Symbol, s.CurrentAngle });
                  
                }
                (sender as Button).Text = newName;
                (sender as Button).FontSize = 15;
                QuickPosition.QuickPositions.Add(q);
            }

        }


        private void RestBtn_Clicked(object sender, EventArgs e)
        {
            QuickPosition.SetQuickPos(QuickPosition.QuickPositions.Find(x=>x.id == 0));
        }

        private void TakeBtn_Clicked(object sender, EventArgs e)
        {// executes QP 11 (opens hand to collect an item), sleeps for 10 secs (preventing from anything else happening), executes QP 12, (Closes hand and returns to default)
            QuickPosition.SetQuickPos(QuickPosition.QuickPositions.Find(x => x.id == 11));
            Thread.Sleep(10000);
            QuickPosition.SetQuickPos(QuickPosition.QuickPositions.Find(x => x.id == 12));
        }
    }

}
