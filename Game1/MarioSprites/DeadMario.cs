using Microsoft.Xna.Framework;
using System;
namespace Game1 { 
public class MarioDead : ISprite
{
    private Game1 myGame;
    

        private int currentFrame = 12 + 28;

    public MarioDead(Game1 game)
    {
        myGame = game;
        
    }


    public void Draw()
    {
        int width = myGame.marioTexture.Width / myGame.totalMarioColumns;
        int height = myGame.marioTexture.Height / myGame.totalMarioRows;
        int row = (int)((float)currentFrame / (float)myGame.totalMarioColumns);
        int column = currentFrame % myGame.totalMarioColumns;

        

        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);

        myGame.spriteBatch.Begin();
        myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
        myGame.spriteBatch.End();
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
        Mario.marioSprite = new MarioSmallIdleRight(myGame);
    }

        public void BigMarioCommandCalled() => Mario.marioSprite = new MarioBigIdleRight(myGame);

        public void FireMarioCommandCalled() => Mario.marioSprite = new MarioFireIdleRight(myGame);

        public void DeadMarioCommandCalled() => Mario.marioSprite = new MarioDead(myGame);

        public void Update()
    {

    }
}
}

