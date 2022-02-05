using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace AppTreinoCarlos.Utils
{
    public static class Share
    {
        public static Color CorIcon { get; set; }
        public static Color CorButton { get; set; }
        public static Color CorPadrao { get; set; }

        static Share()
        {
            CorPadrao = Color.Purple;
            CorIcon = Color.Purple;
            CorButton = Color.Purple;
        }
    }
}
