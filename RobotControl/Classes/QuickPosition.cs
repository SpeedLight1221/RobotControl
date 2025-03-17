using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RobotControl.Classes
{
    class QuickPosition
    {
        [JsonIgnore]
        public static List<QuickPosition> QuickPositions = new List<QuickPosition>()
        {
            new QuickPosition(){id=0,Name="Rest", Angles=new List<byte[]>()
                {
                    new byte[]{1,1,1},
                    new byte[]{82,84,0},
                    new byte[]{82,73,0},
                    new byte[]{82,77,0},
                    new byte[]{82,82,0},
                    new byte[]{82,80,0},
                    new byte[]{82,72,120},
                    new byte[]{82,66,0},
                    new byte[]{82,90,75},
                    new byte[]{82,83,30},
                    new byte[]{82,88,35},




                }
            },



            new QuickPosition(){id=11,Name="TakeBegin", Angles=new List<byte[]>()
                {
                    new byte[]{1,1,1},
                    new byte[]{82,84,0},
                    new byte[]{82,73,0},
                    new byte[]{82,77,0},
                    new byte[]{82,82,0},
                    new byte[]{82,80,0},
                    new byte[]{82,72,60},
                    new byte[]{82,66,40},
                    new byte[]{82,90,90},
                    new byte[]{82,83,60},
                    new byte[]{82,88,50},



                }
            },

            new QuickPosition(){id=12,Name="TakeEnd", Angles=new List<byte[]>()
                {
                    new byte[]{1,1,1},
                    new byte[]{82,84,90},
                    new byte[]{82,73,110},
                    new byte[]{82,77,120},
                    new byte[]{82,82,90},
                    new byte[]{82,80,105},
                    new byte[]{82,72,120},
                    new byte[]{82,66,0},
                    new byte[]{82,90,75},
                    new byte[]{82,83,30},
                    new byte[]{82,88,35},



                }
            }

        };

        [JsonInclude]
        public byte id;
        [JsonInclude]
        public string Name;
        [JsonInclude]
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
