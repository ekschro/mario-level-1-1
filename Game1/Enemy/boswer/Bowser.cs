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
        private bool jumping;
        private bool moving;
        int counter = 0;
        public bool MovingRight { get; set; }
        public bool IsFalling { get => falling; set => falling = value; }
        public bool IsJumping { get => jumping; }
        private IEnemySprite bowserSprite;
        private IEnemyStateMachine stateMachine;
        public IEnemyStateMachine StateMachine { get => stateMachine; }
        private Vector2 bowserLocation;
        private Vector2 bowserOriginalLocation;
        public bool IsStomped { get; set; }
        private int bowserLife;
        public int BowserLife { get => bowserLife; set => bowserLife = value; }
        private bool dead = false;
        private IPhysics physics;
        private EnemyUtilityClass utility;
        
        private Game1 myGame;

        public Bowser(Game1 game, Vector2 location)
        {
            utility = new EnemyUtilityClass();
            bowserLocation = location;
            bowserOriginalLocation = location;
            bowserSprite = new BowserSprite(game, this);
            stateMachine = new BowserStateMachine(bowserSprite);
            physics = new EnemyPhysics(game, this, 1);
            falling = true;
            jumping = false;
            moving = false;
            myGame=game;
            bowserLife = 3;
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
        public void BeJumped()
        {
            stateMachine.BeJump();
            jumping = true;
        }

        public void ChangeDirection(bool faceLeft)
        {
            stateMachine.ChangeDirection(faceLeft);
        }

        public void Draw()
        {
            bowserSprite.Draw();
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
        private void CheckMoving()
        {
            if ((bowserLocation.X - myGame.CurrentLevel.PlayerObject.GetGameObjectLocation().X) <= 200)
                moving = true;
        }
        private void SetBowserLife( int x)
        {
            
        }
        public void Update()
        {
            CheckMoving();
            if (moving && bowserLocation.X >= 2040 || (bowserLocation.X - myGame.CurrentLevel.PlayerObject.GetGameObjectLocation().X <= 0))
            {
                physics.Update();
                utility.EnemyupCyclePosition++;
            }
            else if (moving)
            {
                utility.EnemyupCyclePosition++;
            }
            
            falling = true;
            if (utility.EnemyupCyclePosition == utility.BowserCycleLength && dead!=true)
            {
                utility.EnemyupCyclePosition = 0;
                stateMachine.Update();
                bowserSprite.Update();
                BowserThinking();
            }
        }

        public bool GetDead()
        {
            return dead;
        }
        private void BowserThinking()
        {
            if (myGame.controllerHandler.MovingUp)
            {
                BeJumped();
            }
            else if (myGame.CurrentLevel.PlayerObject.CurrentXPos > CurrentXPos && !myGame.controllerHandler.MovingUp)
            {
                jumping = false;
                ChangeDirection(true);
            }
            else if (myGame.CurrentLevel.PlayerObject.CurrentXPos < CurrentYPos && !myGame.controllerHandler.MovingUp)
            {
                jumping = false;
                ChangeDirection(false);
            }
            if (counter == 100)
            {
                myGame.CurrentLevel.EnemyObjects.Add(new BowserFireBall(myGame, this));
                counter = 0;
            } else
            {
                counter++;
            }
        }
    }
}
