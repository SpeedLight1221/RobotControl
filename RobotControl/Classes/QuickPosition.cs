using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl.Classes
{
    class QuickPosition
    {
        public static List<QuickPosition> QuickPositions = new List<QuickPosition>();
     

        public byte id;

        public string Name;

        public List<byte[]> Angles = new List<byte[]>();

    }
}
