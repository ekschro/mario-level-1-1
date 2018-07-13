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
    public class HiddenGreenMushroomBlockSprite : IBlockSprite
    {
        private HiddenGreenMushroomBlock hiddenGreenMushroomBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private BlockUtilityClass utility;

        public HiddenGreenMushroomBlockSprite(Game1 game, IBlock hiddenGreenMushroomBlock)
        {
            utility = new BlockUtilityClass();
            hiddenGreenMushroomBlockObject = (HiddenGreenMushroomBlock)hiddenGreenMushroomBlock;
            myGame = game;
            currentFrame = 0;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWarehouse.blockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(hiddenGreenMushroomBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)hiddenGreenMushroomBlockObject.GetGameObjectLocation().Y, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.SpriteBatch.End();
        }

    }
}