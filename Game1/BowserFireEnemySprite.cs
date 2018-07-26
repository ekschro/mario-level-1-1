using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class BowserFireEnemySprite : IEnemySprite
    {
        BowserFireBall bowser;
        Game1 myGame;
        private int currentFrame;
        public BowserFireEnemySprite(Game1 game, BowserFireBall enemy)
        {
            myGame = game;
            bowser = enemy;
            currentFrame = 0;
        }

        public void ChangeFrame(int start, int endFrame)
        {
            
        }

        public void ChangeSpriteEffects(SpriteEffects effects)
        {
            
        }

        public void Draw()
        {
            int width = TextureWarehouse.BowserFireballTexture.Width / 2;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(bowser.CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width * currentFrame, TextureWarehouse.BowserFireballTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)bowser.CurrentYPos, width, TextureWarehouse.BowserFireballTexture.Height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.BowserFireballTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == 2)
            {
                currentFrame = 0;
            }
        }
    }
}
