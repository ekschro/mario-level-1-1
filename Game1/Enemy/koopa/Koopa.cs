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
        public float CurrentXPos { get => koopaLocation.X; set => koopaLocation.X = value; }
        public float CurrentYPos { get => koopaLocation.Y; set => koopaLocation.Y = value; }
        private bool falling;
        private bool jumping;
        public bool IsFalling { get => falling; set => falling = value; }
        public bool MovingRight { get; set; }
        public bool IsJumping { get => jumping; }
        private static IEnemySprite koopaSprite;
        public static IEnemySprite KoopaSprite { get => koopaSprite; set => koopaSprite = value; }
        private KoopaStateMachine stateMachine;
        public IEnemyStateMachine StateMachine { get => stateMachine; }
        public bool IsStomped { get; set; }
        private EnemyUtilityClass utility;

        private Vector2 koopaLocation;
        private Vector2 koopaOriginalLocation;
        private IPhysics physics;
        private bool dead = false;

        public Koopa(Game1 game, Vector2 location)
        {
            utility = new EnemyUtilityClass();
            KoopaSprite = new KoopaSprite(game,this);
            stateMachine = new KoopaStateMachine(koopaSprite);
            koopaLocation = location;
            koopaOriginalLocation = location;

            physics = new EnemyPhysics(game,this,1);
            falling = true;
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }

        public void BeStomped()
        {
            stateMachine.BeStomped();
            IsStomped = true;
        }

        public void ChangeDirection(bool faceLeft)
        {
            stateMachine.ChangeDirection(true);
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
            falling = true;
            utility.EnemyupCyclePosition++;
            if (utility.EnemyupCyclePosition == utility.EnemyupCyclePosition)
            {
                utility.EnemyupCyclePosition = 0;
                stateMachine.Update();
                KoopaSprite.Update();
            }
        }
        public bool GetDead()
        {
            return dead;
        }

    }
}
