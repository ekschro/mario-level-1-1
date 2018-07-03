using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class FlagpoleBlockSprite : IBlockSprite
    {
        private FlagpoleBlock flagpoleObject;
        private Game1 myGame;

        public FlagpoleBlockSprite(Game1 game, IBlock flag)
        {
            flagpoleObject = (FlagpoleBlock)flag;
            myGame = game;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(flagpoleObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWareHouse.flagpoleTexture.Width, TextureWareHouse.flagpoleTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)flagpoleObject.GetGameObjectLocation().Y, TextureWareHouse.flagpoleTexture.Width, TextureWareHouse.flagpoleTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.flagpoleTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}