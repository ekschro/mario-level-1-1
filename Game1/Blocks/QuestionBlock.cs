using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class QuestionBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite questionBlockSprite;
        //private IBlock usedBlockObject;
        //private Game1 myGame;
        private Vector2 blockLocation;
        //private Vector2 blockOriginalLocation;
        private int cyclePosition = 0;
        private int cycleLength = 8;
        //private bool jumping = false;

        public QuestionBlock(Game1 game, Vector2 location)
        {
            questionBlockSprite = new QuestionBlockSprite(game, this);
            //usedBlockObject = new UsedBlock(game, location);
            //myGame = game;
            blockLocation = location;
            //blockOriginalLocation = location;
            //Jumping = false;
        }

        public void Draw()
        {
            questionBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                questionBlockSprite.Update();
                cyclePosition = 0;
                blockLocation.Y -= 1;
            }
            //if (questionBlockSprite.isJumping() ==false)
            //if (jumping == true)
            //blockLocation.Y -= 1;

        }

        public void TopCollision() { }
        public void BottomCollision()
        {
            //Jump();
            //Update();
            //questionBlockSprite = new UsedBlockSprite(myGame, usedBlockObject);
            //blockLocation.Y += 20;
            //questionBlockSprite = new UsedBlockSprite(myGame, this);
            

        }
        public void LeftCollision() { }
        public void RightCollision() { }
        /*
        public void Jump()
        {
            //jumping = true;
            //blockLocation.Y -= 20;  
        }
        */
    }
}
