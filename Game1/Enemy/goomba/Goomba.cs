using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Goomba : IEnemy
    {
        private GoombaSprite goombaSprite;
        private GoombaStateMachine stateMachine;
        private Game1 myGame;
        private bool direction = true;
        private int cyclePosition = 0;
        private int cycleLength = 8;
        public Vector2 goombaLocation;

        public Goomba(Game1 game, Vector2 location)
        {
            stateMachine = new GoombaStateMachine();
            goombaSprite = new GoombaSprite(game);
            myGame = game;
            goombaLocation = location;
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }

        public void BeStomped()
        {
            goombaSprite.ChangeFrame(2, 3);
            goombaSprite.ChangeFrame(3, 4);
            stateMachine.BeStomped();
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void Draw()
        {
            goombaSprite.Draw();
        }

        public Vector2 GetCurrentXLocation()
        {
            return goombaLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                goombaSprite.Update();
                stateMachine.Update();
                if (goombaLocation.X == 480 || goombaLocation.X == 430)
                    direction = !direction;
                if (direction == true)
                    goombaLocation.X += 1;
                else if (direction == false)
                    goombaLocation.X -= 1;
            }
        }
    }
}
