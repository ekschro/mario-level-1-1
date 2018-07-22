using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class LevelSelect
    {
        private Game1 myGame;
        private ButtonForLevelSelect button;
        public LevelSelect(Game1 game)
        {
            myGame = game;
            button = new ButtonForLevelSelect(game);

        }
        public void Update()
        {
            button.Update();
        }
        public void Draw()
        {
            myGame.SpriteBatch.Begin();
            button.Draw();
            myGame.SpriteBatch.End();
        }
    }

}