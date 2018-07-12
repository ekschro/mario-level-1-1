using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class TestDeadMarioSprite : ITestMarioSprite
    {
        private TestDeadMario marioObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private IPlayer player;
        private float bouncePosition;
        private float bounceVelocity;
        private float bounceGravity;
        private float bounceTimer;
        public TestDeadMarioSprite(Game1 game, TestDeadMario Mario, IPlayer player)
        {
            marioObject = Mario;
            myGame = game;
            startFrame = 12 + 28; //MarioDead
            //endFrame = ;
            currentFrame = startFrame;
            this.player = player;
            bouncePosition = 0f;
            bounceVelocity = -3.0f;
            bounceGravity = .07f;
            bounceTimer = 2 * ((bounceVelocity * bounceVelocity) / bounceGravity);

            Microsoft.Xna.Framework.Media.MediaPlayer.Play(SoundWarehouse.died_theme);
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
        }

        public void Update()
        {
        }

        public void Draw()
        {   
                int width = TextureWarehouse.marioTexture.Width / player.TotalMarioColumns;
                int height = TextureWarehouse.marioTexture.Height / player.TotalMarioRows;
                int row = (int)((float)currentFrame / (float)player.TotalMarioColumns);
                int column = currentFrame % player.TotalMarioColumns;
                Bounce();

                int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(player.CurrentXPos);
                int drawLocationY = (int)(player.CurrentYPos + bouncePosition);

                Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
                Rectangle destinationRectangle = new Rectangle(drawLocationX, drawLocationY, width, height);

                myGame.SpriteBatch.Begin();
                myGame.SpriteBatch.Draw(TextureWarehouse.marioTexture, destinationRectangle, sourceRectangle, Color.White);
                myGame.SpriteBatch.End();
        }

        public void Bounce()
        {
            
            bounceVelocity += bounceGravity;
            bouncePosition += bounceVelocity;
            if (--bounceTimer < 0)
            {
                myGame.Reset();
                myGame.persistentData.DockLife();
            }
            
        }
        public Vector2 GetGameObjectLocation()
        {
            throw new NotImplementedException();
        }
    }
}
