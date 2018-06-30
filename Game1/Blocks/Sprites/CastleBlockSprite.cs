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
    public class CastleBlockSprite : IBlockSprite
    {
        private CastleBlock castleBlockObject;
        private Game1 myGame;

        public CastleBlockSprite(Game1 game, IBlock castle)
        {
            castleBlockObject = (CastleBlock)castle;
            myGame = game;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(castleBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWareHouse.castleTexture.Width, TextureWareHouse.castleTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)castleBlockObject.GetGameObjectLocation().Y, TextureWareHouse.castleTexture.Width, TextureWareHouse.castleTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.castleTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}