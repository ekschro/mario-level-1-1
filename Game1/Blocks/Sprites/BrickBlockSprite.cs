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
        private int jumpDistance;
        private int currentJumpLocation;
        private BlockUtilityClass utility;

        public BrickBlockSprite(Game1 game, IBlock brick)
        {
            utility = new BlockUtilityClass();
            jumpDistance = utility.jumpDistanceOrCurrentFrame;
            currentJumpLocation = utility.InitialFrame;
            brickBlockObject = brick;
            myGame = game;
            currentFrame = utility.Two;
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

            int width = TextureWarehouse.BlockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(brickBlockObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, utility.InitialFrame, width, TextureWarehouse.BlockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)brickBlockObject.GameObjectLocation.Y - currentJumpLocation, width, TextureWarehouse.BlockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.BlockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public void Bounce()
        {
            endofJumping = false;
            up = true;
        }
    }
}