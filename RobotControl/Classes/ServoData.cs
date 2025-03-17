using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl.Classes
{
    class ServoData
    {
        public static List<ServoData> ServoDataList = new List<ServoData>
        {
            new("Right_Pinky",'R','P',115,0),
            new("Right_Ring",'R','R',100,0),
            new("Right_Middle",'R','M',130,0),
            new("Right_Index",'R','I',120,0),
            new("Right_Thumb",'R','T',90,0),
            new("Right_Wrist",'R','H',145,45),

            new("Right_Bicep",'R','B',40,0),
            new("Right_RotaBicep",'R','Z',120,0),
            new("Right_Shoulder",'R','S',60,30),
            new("Right_RotaShoulder",'R','X',150,0),

             new("Left_Pinky",'L','P',115,0),
            new("Left_Ring",'L','R',115,0),
            new("Left_Middle",'L','M',130,0),
            new("Left_Index",'L','I',115,0),
            new("Left_Thumb",'L','T',100,0),
             new("Left_Wrist",'L','H',120,45),
        };
        public ServoData(string name, char side, char symbol, byte maxAngle, byte minAngle)
        {
            Name = name;
            Side = side;
            Symbol = symbol;
            MaxAngle = maxAngle;
            MinAngle = minAngle;

        }
        public readonly string Name;
        public readonly char Side;
        public readonly char Symbol;
        public readonly byte MaxAngle;
        public readonly byte MinAngle;
        public byte CurrentAngle { get; set; } = 0;
        public byte NewAngle {
            get{
                return newAngle;
            }
            set 
            {
                if (value <= MaxAngle && value >= MinAngle)
                {
                    newAngle = value;
                }
                else if (value > MaxAngle)
                {
                    newAngle = MaxAngle;
                }
                else if (value < MinAngle) 
                { 
                    newAngle = MinAngle; 
                }
            }
        }
        private byte newAngle = 0;
    }
}
