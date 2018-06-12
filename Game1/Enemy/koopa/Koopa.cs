using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Koopa : IEnemy
    {
        private KoopaSprite koopaSprite;
        private KoopaStateMachine stateMachine;
        private Game1 myGame;
        private bool direction = true;
        private int cyclePosition = 0;
        private int cycleLength = 8;
        public Vector2 koopaLocation;

        public Koopa(Game1 game, Vector2 location)
        {
            stateMachine = new KoopaStateMachine();
            koopaSprite = new KoopaSprite(game);
            myGame = game;
            koopaLocation = location;
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }

        public void BeStomped()
        {
            koopaSprite.ChangeFrame(4, 5);
            koopaSprite.ChangeFrame(5, 6);
            stateMachine.BeStomped();
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void Draw()
        {
            koopaSprite.Draw();
        }

        public Vector2 GetCurrentXLocation()
        {
            return koopaLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                koopaSprite.Update();
                stateMachine.Update();
                if (koopaLocation.X == 420 || koopaLocation.X == 380)
                    direction = !direction;
                if (direction == true)
                    koopaLocation.X += 1;
                else if (direction == false)
                    koopaLocation.X -= 1;
            }
        }
    }
}
