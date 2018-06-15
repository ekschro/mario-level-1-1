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
        private static IEnemySprite koopaSprite;
        public static IEnemySprite KoopaSprite { get => koopaSprite; set => koopaSprite = value; }
        private KoopaStateMachine stateMachine;

        private Game1 myGame;
        private bool direction = true;
        private int cyclePosition = 0;
        private int cycleLength = 8;
        public Vector2 koopaLocation;
        private Vector2 koopaOriginalLocation;



        public Koopa(Game1 game, Vector2 location)
        {
            KoopaSprite = new KoopaSprite(game,this);
            stateMachine = new KoopaStateMachine(koopaSprite);
            myGame = game;
            koopaLocation = location;
            koopaOriginalLocation = location;
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }

        public void BeStomped()
        {
            stateMachine.BeStomped();
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
            direction = !direction;
        }

        public void Draw()
        {
            KoopaSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return koopaLocation;
        }
        public Vector2 GameOriginalLocation()
        {
            return koopaOriginalLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                KoopaSprite.Update();
                stateMachine.Update();
                if (koopaLocation.X == (koopaOriginalLocation.X - 20) || koopaLocation.X == koopaOriginalLocation.X + 20)
                    ChangeDirection();
                if (direction == true)
                    koopaLocation.X += 1;
                else if (direction == false)
                    koopaLocation.X -= 1;
            }
        }
    }
}
