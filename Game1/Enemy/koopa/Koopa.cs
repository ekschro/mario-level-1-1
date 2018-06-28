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
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private static IEnemySprite koopaSprite;
        public static IEnemySprite KoopaSprite { get => koopaSprite; set => koopaSprite = value; }
        private KoopaStateMachine stateMachine;

        private int cyclePosition = 0;
        private int cycleLength = 8;
        private Vector2 koopaLocation;
        private Vector2 koopaOriginalLocation;
        private GeneralPhysics physics;
        private bool dead = false;

        public Koopa(Game1 game, Vector2 location)
        {
            KoopaSprite = new KoopaSprite(game,this);
            stateMachine = new KoopaStateMachine(koopaSprite);
            //myGame = game;
            koopaLocation = location;
            koopaOriginalLocation = location;

            physics = new GeneralPhysics(game,this,1);
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
        }

        public void Draw()
        {
            KoopaSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return koopaLocation;
        }

        public void SetGameObjectLocation(Vector2 newPos)
        {
            koopaLocation = newPos;
        }

        public Vector2 GameOriginalLocation()
        {
            return koopaOriginalLocation;
        }

        public void Update()
        {
            physics.Update();

            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                KoopaSprite.Update();
                stateMachine.Update();
                if (stateMachine.GetDirection())
                    koopaLocation.X += 1;
                else
                    koopaLocation.X -= 1;
            }
            //qif (movingdown)
            //NewPosY();
        }
        public bool GetDead()
        {
            return dead;
        }

    }
}
