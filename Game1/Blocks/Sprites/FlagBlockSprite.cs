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
    public class FlagBlockSprite : IBlockSprite
    {
        private FlagBlock flagObject;
        private Game1 myGame;

        public FlagBlockSprite(Game1 game, IBlock flag)
        {
            flagObject = (FlagBlock)flag;
            myGame = game;
        }

        public void Update()
        {

        }

        public void Draw()
        {

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(flagObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWareHouse.flagTexture.Width, TextureWareHouse.flagTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)flagObject.GetGameObjectLocation().Y, TextureWareHouse.flagTexture.Width, TextureWareHouse.flagTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.flagTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}