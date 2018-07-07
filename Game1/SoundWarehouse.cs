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
        public static Song theme;

        public SoundWarehouse(Game1 game)
        {
            theme = game.Content.Load<Song>("01-main-theme-overworld");
        }
    }
}
