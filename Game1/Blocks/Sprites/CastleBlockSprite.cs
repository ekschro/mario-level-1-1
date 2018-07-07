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

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWarehouse.castleTexture.Width, TextureWarehouse.castleTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)castleBlockObject.GetGameObjectLocation().Y, TextureWarehouse.castleTexture.Width, TextureWarehouse.castleTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.castleTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}