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
    public class BottomLeftPipeBlockSprite : IBlockSprite
    {
        private BottomLeftPipeBlock bottomLeftPipeBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private BlockUtilityClass utility;

        public BottomLeftPipeBlockSprite(Game1 game, IBlock bottomLeftPipe)
        {
            utility = new BlockUtilityClass();
            bottomLeftPipeBlockObject = (BottomLeftPipeBlock)bottomLeftPipe;
            myGame = game;
            currentFrame = utility.jumpDistanceOrCurrentFrame;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWarehouse.blockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(bottomLeftPipeBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, utility.InitialFrame, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)bottomLeftPipeBlockObject.GetGameObjectLocation().Y, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}