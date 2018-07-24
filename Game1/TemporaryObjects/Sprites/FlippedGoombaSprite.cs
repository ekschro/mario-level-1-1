using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class FlippedGoombaSprite : ITemporarySprite
    {
        private FlippedGoomba goombaObject;
        private Game1 myGame;

        private float bouncePosition;
        private float bounceVelocity;
        private float bounceGravity;
        

        public FlippedGoombaSprite(Game1 game, FlippedGoomba goomba)
        {
            goombaObject = goomba;
            myGame = game;

            bouncePosition = 0f;
            bounceVelocity = -3.0f;
            bounceGravity = .07f;
           
        }

        public void Update()
        {
            Bounce();
        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(goombaObject.CurrentXPos);
            int drawLocationY = (int)(goombaObject.CurrentYPos + bouncePosition);

            Rectangle sourceRectangle = new Rectangle(0,0,(int)TextureWarehouse.flippedGoomba.Width, (int)TextureWarehouse.flippedGoomba.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, drawLocationY, (int)TextureWarehouse.flippedGoomba.Width, (int)TextureWarehouse.flippedGoomba.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.flippedGoomba, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public void Bounce()
        {
            bounceVelocity += bounceGravity;
            bouncePosition += bounceVelocity;
        }
    }
}
