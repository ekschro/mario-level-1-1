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
        private int jumpDistance;
        private int currentJumpLocation;
        private BlockUtilityClass utility;

        public UsedBlockSprite(Game1 game, IBlock usedBlock)
        {
            utility = new BlockUtilityClass();
            usedBlockObject = (UsedBlock)usedBlock;
            myGame = game;
            jumpDistance = utility.Ten;
            currentJumpLocation = utility.Zero1;
            currentFrame = utility.Three;
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
                { currentJumpLocation += utility.Two; }
                else if ( currentJumpLocation > utility.Zero1)
                { currentJumpLocation -= utility.Two; }
            }

            int width = TextureWarehouse.blockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(usedBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)usedBlockObject.GetGameObjectLocation().Y - currentJumpLocation, width, TextureWarehouse.blockTexture.Height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}