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
    public class PipeOnSideBlockSprite : IBlockSprite
    {
        private IBlock pipeOnSideBlockObject;
        private Game1 myGame;
        BlockUtilityClass utility;

        public PipeOnSideBlockSprite(Game1 game, IBlock pipeOnSide)
        {
            pipeOnSideBlockObject = (PipeOnSideBlock)pipeOnSide;
            myGame = game;
            utility = new BlockUtilityClass();
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(pipeOnSideBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(utility.InitialFrame, utility.InitialFrame, TextureWarehouse.pipeOnSideBlockTexture.Width, TextureWarehouse.pipeOnSideBlockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)pipeOnSideBlockObject.GetGameObjectLocation().Y, TextureWarehouse.pipeOnSideBlockTexture.Width, TextureWarehouse.pipeOnSideBlockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.pipeOnSideBlockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}