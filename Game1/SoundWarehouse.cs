using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class SoundWarehouse
    {
        public static Song main_theme;

        public static SoundEffect jump;

        public SoundWarehouse(Game1 game)
        {
            main_theme = game.Content.Load<Song>("01-main-theme-overworld");

            jump = game.Content.Load<SoundEffect>("smb_jumpsmall");

            
        }
    }
}
