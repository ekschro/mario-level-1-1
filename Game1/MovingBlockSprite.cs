using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    public class MovingBlockSprite : IBlockSprite
    {
        Game1 myGame;
        IBlock block2;
        public MovingBlockSprite(Game1 game, IBlock block)
        {
            myGame = game;
            block2 = block;
            block2 = (MovingBlock)block2;
        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(block2.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(0,0, (int)TextureWarehouse.movingPlatform.Width, (int)TextureWarehouse.movingPlatform.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)block2.GetGameObjectLocation().Y, (int)TextureWarehouse.movingPlatform.Width, (int)TextureWarehouse.movingPlatform.Height);

            myGame.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            myGame.SpriteBatch.Draw(TextureWarehouse.movingPlatform, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public void Update()
        {
            
        }
    }
}
