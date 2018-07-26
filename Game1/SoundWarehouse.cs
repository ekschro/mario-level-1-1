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
        public static Song castle_theme;
        public static Song castle_complete_theme;
        public static SoundEffect jump;
        public static SoundEffect stomp;
        public static SoundEffect bump;
        public static SoundEffect powerup_appears;
        public static SoundEffect powerup;
        public static SoundEffect pipe;
        public static SoundEffect pause;
        public static SoundEffect fireball;
        public static SoundEffect breakblock;
        public static SoundEffect coin;
        public static SoundEffect oneup;
        public static SoundEffect bowserFire;


        public SoundWarehouse(Game1 game)
        {
            main_theme = game.Content.Load<Song>("01-main-theme-overworld");
            died_theme = game.Content.Load<Song>("08-you-re-dead");
            level_complete_theme = game.Content.Load<Song>("06-level-complete");
            game_over_theme = game.Content.Load<Song>("10-game-over-2");
            star_theme = game.Content.Load<Song>("05-starman");
            castle_theme = game.Content.Load<Song>("04-castle");
            castle_complete_theme = game.Content.Load<Song>("07-castle-complete");

            jump = game.Content.Load<SoundEffect>("smb_jumpsmall");
            stomp = game.Content.Load<SoundEffect>("smb_stomp");
            bump = game.Content.Load<SoundEffect>("smb_bump");
            powerup_appears = game.Content.Load<SoundEffect>("smb_powerup_appears");
            powerup = game.Content.Load<SoundEffect>("smb_powerup");
            pipe = game.Content.Load<SoundEffect>("smb_pipe");
            pause = game.Content.Load<SoundEffect>("smb_pause");
            fireball = game.Content.Load<SoundEffect>("smb_fireball");
            breakblock = game.Content.Load<SoundEffect>("smb_breakblock");
            coin = game.Content.Load<SoundEffect>("smb_coin");
            oneup = game.Content.Load<SoundEffect>("smb_1-up");
            bowserFire = game.Content.Load<SoundEffect>("smb_bowserFire");

        }
    }
}
