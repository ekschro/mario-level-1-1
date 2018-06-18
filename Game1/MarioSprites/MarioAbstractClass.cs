using Microsoft.Xna.Framework;
using System;
namespace Game1
{

    public abstract class MarioAbstractClass : ISprite
    {
        public abstract void BigMarioCommandCalled();
        public abstract void DeadMarioCommandCalled();
        public abstract void DownCommandCalled();
        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / Mario.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)Mario.CurrentFrame / (float)Mario.TotalMarioColumns);
            int column = Mario.CurrentFrame % Mario.TotalMarioColumns;



            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);

            Mario.MyGame.spriteBatch.Begin();
            Mario.MyGame.spriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            Mario.MyGame.spriteBatch.End();
        }
        public abstract void FireMarioCommandCalled();
        public abstract Vector2 GameObjectLocation();
        public abstract bool isCrouching();
        public abstract bool isFire();
        public abstract bool isSmall();
        public abstract void LeftCommandCalled();
        public abstract void RightCommandCalled();
        public abstract void SmallMarioCommandCalled();
        public abstract void UpCommandCalled();
        public abstract void Update();
    }
}
