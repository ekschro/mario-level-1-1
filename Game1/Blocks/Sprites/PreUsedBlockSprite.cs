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
    public class PreUsedBlockSprite : IBlockSprite
    {
        private IBlock preUsedBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private BlockUtilityClass utility;

        public PreUsedBlockSprite(Game1 game, IBlock preUsedBlock)
        {
            utility = new BlockUtilityClass();
            preUsedBlockObject = (PreUsedBlock)preUsedBlock;
            myGame = game;
            currentFrame = utility.CurrentFrame4;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWarehouse.BlockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(preUsedBlockObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.BlockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)preUsedBlockObject.GameObjectLocation.Y, width, TextureWarehouse.BlockTexture.Height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.BlockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}