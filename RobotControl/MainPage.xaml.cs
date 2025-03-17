using RobotControl.Classes;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace RobotControl
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            ReadQPFile();
        }

        private async void QuickPos_Clicked(object sender, EventArgs e)
        {
            string num = (sender as Button).StyleId[1].ToString();
            byte i = byte.Parse(num); // Gets the number of the button and uses it to find a quickposition with the matching ID
            
            QuickPosition q = QuickPosition.QuickPositions.Where(x => x.id == i).FirstOrDefault();
            if (q != null)// if  found, sends the angles saved in the quickpos to the arduino
            {
                if (AppShell.instance.isOnDelay) 
                {
                    await DisplayAlert("Error", "Send function is on delay", "Ok");
                }
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
                WriteQPFile();
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



        private string GetQPPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(path, "qp.json");
        }

        private void ReadQPFile()
        {
            if(File.Exists(GetQPPath()))
            {
                using (StreamReader sr = new StreamReader(GetQPPath())) 
                { 
                    List<QuickPosition> qps = new List<QuickPosition>();
                    qps = JsonSerializer.Deserialize<List<QuickPosition>>(sr.ReadToEnd());

                   

                    foreach(QuickPosition q in qps)
                    {
                        
                        QuickPosition.QuickPositions.Add(q);
                        (FindByName("b"+q.id) as Button).Text = q.Name;
                        (FindByName("b" + q.id) as Button).FontSize = 15;
                    }
                    
                
                }
            }
           
        }


        private void WriteQPFile()
        {
            using (StreamWriter sw = new StreamWriter(GetQPPath(), false)) 
            {
                var list = QuickPosition.QuickPositions.Where(x => x.id > 0 && x.id < 11).ToList();
                
                 
                
                if (list != null &&list.Count > 0)
                {
                    var json = JsonSerializer.Serialize(list);
                    sw.Write(json);
                  
                }
                
               

            
            }
        }

        private async void ResetQpBtn_Clicked(object sender, EventArgs e)
        {
           
            bool selected = await DisplayAlert("Delete?", "Do you want to delete saved values?", "Yes", "No");
            if (selected)
            {
                File.Delete(GetQPPath());
                DisplayAlert("Done", "Please Closed and Reopen app for changes to take effect", "Ok");
            }

        }
    }

}
