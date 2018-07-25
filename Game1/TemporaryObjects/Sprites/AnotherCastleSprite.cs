using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class AnotherCastleSprite : ITemporarySprite
    {
        private AnotherCastle anotherCastleObject;
        private Game1 myGame;

        public AnotherCastleSprite(Game1 game, AnotherCastle anotherCastle)
        {
            anotherCastleObject = anotherCastle;
            myGame = game;
        }

        public void Update()
        {
        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(anotherCastleObject.CurrentXPos);
            int drawLocationY = (int)(anotherCastleObject.CurrentYPos);

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWarehouse.AnotherCastleTexture.Width, TextureWarehouse.AnotherCastleTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, drawLocationY, TextureWarehouse.AnotherCastleTexture.Width, TextureWarehouse.AnotherCastleTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.AnotherCastleTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
