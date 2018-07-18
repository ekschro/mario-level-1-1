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
    public class TopWarpPipeBlockSprite : IBlockSprite
    {
        private IBlock topWarpPipeBlockObject;
        private Game1 myGame;
        private int currentFrame;
        BlockUtilityClass utility;

        public TopWarpPipeBlockSprite(Game1 game, IBlock topPipe)
        {
            topWarpPipeBlockObject = (TopWarpPipeBlock)topPipe;
            myGame = game;
            utility = new BlockUtilityClass();
            currentFrame = utility.CurrentFrame3;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = (TextureWarehouse.blockTexture.Width * utility.Two) / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(topWarpPipeBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle((width / utility.Two) * currentFrame, utility.InitialFrame, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)topWarpPipeBlockObject.GetGameObjectLocation().Y, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}