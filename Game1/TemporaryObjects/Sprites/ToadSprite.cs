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

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWarehouse.ToadTexture.Width, TextureWarehouse.ToadTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, drawLocationY, TextureWarehouse.ToadTexture.Width, TextureWarehouse.ToadTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.ToadTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
