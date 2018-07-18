using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public abstract class AbstractBlockSprite : IBlockSprite
    {
        protected IBlock blockObject;
        private Game1 myGame;
        protected int currentFrame;
        protected BlockUtilityClass utility;

        protected AbstractBlockSprite(Game1 game, IBlock stairBlock)
        {
            utility = new BlockUtilityClass();
            //blockObject = (StairBlock)stairBlock;
            myGame = game;
            //currentFrame = utility.CurrentFrame2;
            //blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWarehouse.blockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(blockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, utility.InitialFrame, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)blockObject.GetGameObjectLocation().Y, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
