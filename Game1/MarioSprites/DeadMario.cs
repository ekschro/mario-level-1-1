using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
namespace Game1 { 
public class MarioDead : ISprite
{
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
        private IPlayer player;
        private int currentFrame = 12 + 28;

        private float bouncePosition;
        private float bounceVelocity;
        private float bounceGravity;
        private float bounceTimer;

    public MarioDead(Game1 game,IPlayer player)
    {
        myGame = game;
            this.player = player;
            bouncePosition = 0f;
            bounceVelocity = -3.0f;
            bounceGravity = .07f;
            bounceTimer = 2*((bounceVelocity * bounceVelocity) / bounceGravity);

            MediaPlayer.Play(SoundWarehouse.died_theme);

        }


        public void Draw()
        {
            int width = TextureWarehouse.marioTexture.Width / player.TotalMarioColumns;
            int height = TextureWarehouse.marioTexture.Height / player.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)player.TotalMarioColumns);
            int column = currentFrame % player.TotalMarioColumns;
            Bounce();

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(player.CurrentXPos);
            int drawLocationY = (int)(player.CurrentYPos  + bouncePosition);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, drawLocationY, width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.marioTexture, destinationRectangle, sourceRectangle, player.MarioColor);
            myGame.SpriteBatch.End();
        }

    public void UpCommandCalled()
    {
       
    }

    public void DownCommandCalled()
    {
        
    }

    public void LeftCommandCalled()
    {

    }

        public void RightCommandCalled()
        {

        }
    public void SmallMarioCommandCalled()
    {
        player.MarioSprite = new MarioSmallIdleRight(myGame,player);
    }

        public void BigMarioCommandCalled() => player.MarioSprite = new MarioBigIdleRight(myGame, player);

        public void FireMarioCommandCalled() => player.MarioSprite = new MarioFireIdleRight(myGame, player);

        public void DeadMarioCommandCalled()
        {
            if (!(player.MarioSprite is MarioDead))
                player.MarioSprite = new MarioDead(myGame,player);
        }

        public void Update()
    {
    }

        public bool isSmall()
        {
            return true;
        }

        public bool isFire()
        {
            return false;
        }

        public bool isCrouching()
        {
            return true;
        }
        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(player.CurrentXPos, player.CurrentYPos);
        }

        public void Bounce()
        {
            bounceVelocity += bounceGravity;
            bouncePosition += bounceVelocity;
            if (--bounceTimer < 0)
                myGame.Reset();
        }
    }
}

