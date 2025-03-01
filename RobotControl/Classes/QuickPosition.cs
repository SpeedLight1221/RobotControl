using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl.Classes
{
    class QuickPosition
    {
        public static List<QuickPosition> QuickPositions = new List<QuickPosition>()
        {
            new QuickPosition(){id=0,Name="Rest", Angles=new List<byte[]>()
                {




                } 
            },



            new QuickPosition(){id=11,Name="TakeBegin", Angles=new List<byte[]>()
                {




                } 
            },

            new QuickPosition(){id=12,Name="TakeEnd", Angles=new List<byte[]>()
                {




                } 
            }

        };


        public byte id;

        public string Name;

        public List<byte[]> Angles = new List<byte[]>();

        public static void SetQuickPos(QuickPosition quickPosition)
        {
            foreach (byte[] b in quickPosition.Angles)
            {
                BTComm.SendBytes(b);

                ServoData.ServoDataList.Find(x => x.Side == b[0] && x.Symbol == b[1]).CurrentAngle = b[2]; // overwrites the current angel of all servos to match the one set by the quickp ost

            }
        }

    }
}
