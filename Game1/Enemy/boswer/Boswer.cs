using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Bowser : IEnemy
    {
        public float CurrentXPos { get => bowserLocation.X; set => bowserLocation.X = value; }
        public float CurrentYPos { get => bowserLocation.Y; set => bowserLocation.Y = value; }
        private bool falling;
        public bool MovingRight { get; set; }
        public bool IsFalling { get => falling; set => falling = value; }
        private IEnemySprite bowserSprite;
        public IEnemySprite BowserSprite { get => bowserSprite; set => bowserSprite = value; }
        private IEnemyStateMachine stateMachine;
        public IEnemyStateMachine StateMachine { get => stateMachine; }
        private Vector2 bowserLocation;
        private Vector2 bowserOriginalLocation;
        public bool IsStomped { get; set; }

        private bool dead = false;
        private IPhysics physics;
        private EnemyUtilityClass utility;

        public Bowser(Game1 game, Vector2 location)
        {
            utility = new EnemyUtilityClass();
            bowserLocation = location;
            bowserOriginalLocation = location;
            BowserSprite = new BowserSprite(game, this);
            stateMachine = new BowserStateMachine(BowserSprite);
            physics = new EnemyPhysics(game, this, 1);
            falling = true;
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
            dead = true;
        }
        public void BeStomped()
        {
            stateMachine.BeStomped();
        }

        public void ChangeDirection()
        {
        }

        public void Draw()
        {
            BowserSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return bowserLocation;
        }
        public void SetGameObjectLocation(Vector2 newPos)
        {
            bowserLocation = newPos;
        }

        public Vector2 GameOriginalLocation()
        {
            return bowserOriginalLocation;
        }
        public void Update()
        {
            physics.Update();
            falling = true;
            utility.EnemyupCyclePosition++;
            if (utility.EnemyupCyclePosition == utility.EnemyCycleLength)
            {
                utility.EnemyupCyclePosition = 0;
                stateMachine.Update();
                BowserSprite.Update();
                if (dead)
                {
                }
            }
        }

        public bool GetDead()
        {
            return dead;
        }
    }
}
