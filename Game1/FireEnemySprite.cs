using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class FireEnemySprite : IEnemySprite
    {
        FireEnemy fireEnemy;
        Game1 myGame;
        private int currentFrame;
        public FireEnemySprite(Game1 game, FireEnemy enemy)
        {
            myGame = game;
            fireEnemy = enemy;
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
            int width = TextureWarehouse.FireballTexture.Width / 4;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(fireEnemy.CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.FireballTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)fireEnemy.CurrentYPos, width, TextureWarehouse.FireballTexture.Height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.FireballTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == 5)
            {
                currentFrame = 0;
            }
        }
    }
}
