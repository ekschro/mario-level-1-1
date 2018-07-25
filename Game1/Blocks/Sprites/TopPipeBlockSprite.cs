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
    public class TopPipeBlockSprite : IBlockSprite
    {
        private TopPipeBlock topPipeBlockObject;
        private Game1 myGame;
        private int currentFrame;
        BlockUtilityClass utility;

        public TopPipeBlockSprite(Game1 game, IBlock topPipe)
        {
            topPipeBlockObject = (TopPipeBlock)topPipe;
            myGame = game;
            utility = new BlockUtilityClass();
            currentFrame = utility.CurrentFrame3;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = (TextureWarehouse.BlockTexture.Width * utility.Two) / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(topPipeBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle((width / utility.Two) * currentFrame, utility.InitialFrame, width, TextureWarehouse.BlockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)topPipeBlockObject.GetGameObjectLocation().Y, width, TextureWarehouse.BlockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.BlockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}