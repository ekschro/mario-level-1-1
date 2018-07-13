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
    public class BrickBlockSprite : IBlockSprite
    {
        private IBlock brickBlockObject;
        private Game1 myGame;
        private int currentFrame;

        private bool up = false;
        private bool endofJumping = true;
        private int jumpDistance = 10;
        private int currentJumpLocation = 0;
        private BlockUtilityClass utility;

        public BrickBlockSprite(Game1 game, IBlock brick)
        {
            utility = new BlockUtilityClass();
            brickBlockObject = brick;
            myGame = game;
            currentFrame = 2;
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
                else if (currentJumpLocation > 0)
                { currentJumpLocation -= 2; }
            }

            int width = TextureWarehouse.blockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(brickBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)brickBlockObject.GetGameObjectLocation().Y - currentJumpLocation, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public void Bounce()
        {
            endofJumping = false;
            up = true;
        }
    }
}