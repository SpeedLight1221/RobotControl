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
            byte i = byte.Parse((sender as Button).StyleId); // Gets the number of the button and uses it to find a quickposition with the matching ID
            QuickPosition q = QuickPosition.QuickPositions.Where(x => x.id == i).FirstOrDefault();
            if (q != null)// if  found, sends the angles saved in the quickpos to the arduino
            {
                foreach (byte[] b in q.Angles)
                {
                    BTComm.SendBytes(b);

                    ServoData.ServoDataList.Find(x=>x.Side == b[0] &&x.Symbol == b[1]).CurrentAngle = b[2]; // overwrites the current angel of all servos to match the one set by the quickp ost

                }
            }
            else// if not found, prompts for a name and creates a new one from the currently set angles
            {
                string newName = await DisplayPromptAsync($"Position {i}", "Insert Name", "Ok", "Cancel", maxLength: 5);

                if (newName == null) 
                {
                    newName = "Pos " + i;
                }



                q = new QuickPosition() { id = i, Name = newName };
                foreach (ServoData s in ServoData.ServoDataList) 
                {
                    q.Angles.Add(new byte[]{(byte)s.Side,(byte)s.Symbol,s.CurrentAngle });
                    
                }
            }

        }
    }

}
