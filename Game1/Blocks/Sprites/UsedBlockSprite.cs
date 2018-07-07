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
    public class UsedBlockSprite : IBlockSprite
    {
        private UsedBlock usedBlockObject;
        private Game1 myGame;
        private int currentFrame;

        private bool up = true;
        private bool endofJumping = false;
        private int jumpDistance = 10;
        private int currentJumpLocation = 0;

        public UsedBlockSprite(Game1 game, IBlock usedBlock)
        {
            usedBlockObject = (UsedBlock)usedBlock;
            myGame = game;
            currentFrame = 3;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            if (endofJumping == false)
            {
                if (currentJumpLocation == jumpDistance)
                { up = false; }
                if (up == true)
                { currentJumpLocation += 2; }
                else if ( currentJumpLocation > 0)
                { currentJumpLocation -= 2; }
            }

            int width = TextureWarehouse.blockTexture.Width / 13;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(usedBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)usedBlockObject.GetGameObjectLocation().Y - currentJumpLocation, width, TextureWarehouse.blockTexture.Height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}