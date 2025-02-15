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
            new("Right_Pinky",'R','P',120,0),
            new("Right_Ring",'R','R',120,0),
            new("Right_Middle",'R','M',120,0),
            new("Right_Index",'R','I',120,0),
            new("Right_Thumb",'R','T',120,0),
            new("Right_Wrist",'R','H',150,0),
            new("Right_Pinky",'R','P',120,0),
            new("Right_Bicep",'R','P',40,0),
            new("Right_RotaBicep",'R','Z',120,0),
            new("Right_Shoulder",'R','S',60,30),
            new("Right_RotaShoulder",'R','P',150,0),
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

        public byte CurrentAngle = 0;
        public byte NewAngle = 0;
    }
}
