using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class StairBlockSprite : IBlockSprite
    {
        private IBlock stairBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private BlockUtilityClass utility;

        public StairBlockSprite(Game1 game, IBlock stairBlock)
        {
            utility = new BlockUtilityClass();
            stairBlockObject = (StairBlock)stairBlock;
            myGame = game;
            currentFrame = utility.CurrentFrame2;
            
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWarehouse.blockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(stairBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, utility.InitialFrame, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)stairBlockObject.GetGameObjectLocation().Y, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}