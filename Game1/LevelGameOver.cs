using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    public class LevelGameOver
    {
        private Game1 myGame;
        public LevelGameOver(Game1 game)
        {
            myGame = game;
            MediaPlayer.Play(SoundWarehouse.game_over_theme);
        }
        public void Draw()
        {           
            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, "GAME OVER", new Vector2(150, 100), Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
