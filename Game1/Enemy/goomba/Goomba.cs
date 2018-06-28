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
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IEnemySprite goombaSprite;
        public IEnemySprite GoombaSprite { get => goombaSprite; set => goombaSprite = value; }
        private GoombaStateMachine stateMachine;
        private int cyclePosition = 0;
        private int cycleLength = 8;
        private Vector2 goombaLocation;
        private Vector2 goombaOriginalLocation;
        private bool running=true;
        private bool movingdown = true;

        private float yVelocity;
        private GeneralPhysics physics;
        private float delta;
        private Game1 myGame;

        public Goomba(Game1 game, Vector2 location)
        {
            goombaLocation = location;
            goombaOriginalLocation = location;
            myGame = game;

            GoombaSprite = new GoombaSprite(game, this);
            stateMachine = new GoombaStateMachine(GoombaSprite);
            yVelocity = 0;

            physics = new GeneralPhysics(myGame,this,1);
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
            GoombaSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return goombaLocation;
        }

        public void SetGameObjectLocation(Vector2 newPos)
        {
            goombaLocation = newPos;
        }

        public Vector2 GameOriginalLocation()
        {
            return goombaOriginalLocation;
        }

        public void Update()
        {
            delta = myGame.delta.ElapsedGameTime.Milliseconds;

            physics.Update();
            
            cyclePosition++;
            if (cyclePosition == cycleLength && running)
            {
                cyclePosition = 0;
                stateMachine.Update();
                GoombaSprite.Update();
                if (stateMachine.GetDirection())
                    goombaLocation.X += 1;
                else 
                    goombaLocation.X -= 1;
            }
            //if (movingdown)
                //NewPosY();
            //Falling();
        }
        public void Running()
        {
            running = true;
        }
        public void NewPosY()
        {
            
            if (yVelocity < 3.5)
            {
                yVelocity += (float)(0.5 * 0.01 * Math.Pow(delta, 2));
            }

            goombaLocation.Y += yVelocity;
        }
        public void ReachGround()
        {
            movingdown = false;
        }
        public void Falling()
        {
            movingdown = true;
        }
    }
}
