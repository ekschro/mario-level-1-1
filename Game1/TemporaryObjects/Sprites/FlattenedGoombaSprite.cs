using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class FlattenedGoombaSprite : ITemporarySprite
    {
        private FlattenedGoomba goombaObject;
        private Game1 myGame;

        public FlattenedGoombaSprite(Game1 game, FlattenedGoomba goomba)
        {
            goombaObject = goomba;
            myGame = game;
        }

        public void Update()
        {
        }

        public void Draw()
        {
            int width = (int)TextureWareHouse.goombaTexture.Width / 4;
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(goombaObject.CurrentXPos);
            int drawLocationY = (int)(goombaObject.CurrentYPos);

            Rectangle sourceRectangle = new Rectangle(width*2, 0, width, (int)TextureWareHouse.goombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, drawLocationY, width, (int)TextureWareHouse.goombaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.goombaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
