using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class ToadSprite : ITemporarySprite
    {
        private Toad toadObject;
        private Game1 myGame;

        public ToadSprite(Game1 game, Toad toad)
        {
            toadObject = toad;
            myGame = game;
        }

        public void Update()
        {
        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(toadObject.CurrentXPos);
            int drawLocationY = (int)(toadObject.CurrentYPos);

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWarehouse.toadTexture.Width, TextureWarehouse.toadTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, drawLocationY, TextureWarehouse.toadTexture.Width, TextureWarehouse.toadTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.toadTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
