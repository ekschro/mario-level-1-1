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
        public static Song died_theme;
        public static Song level_complete_theme;
        public static Song game_over_theme;
        public static Song star_theme;
        public static SoundEffect jump;

        public SoundWarehouse(Game1 game)
        {
            main_theme = game.Content.Load<Song>("01-main-theme-overworld");
            died_theme = game.Content.Load<Song>("08-you-re-dead");
            level_complete_theme = game.Content.Load<Song>("06-level-complete");
            game_over_theme = game.Content.Load<Song>("10-game-over-2");
            star_theme = game.Content.Load<Song>("05-starman");

            jump = game.Content.Load<SoundEffect>("smb_jumpsmall");

        }
    }
}
