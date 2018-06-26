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

        public Goomba(Game1 game, Vector2 location)
        {
            goombaLocation = location;
            goombaOriginalLocation = location;

            GoombaSprite = new GoombaSprite(game, this);
            stateMachine = new GoombaStateMachine(GoombaSprite);
            //myGame = game;
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

        public Vector2 GameObjectLocation()
        {
            return goombaLocation;
        }
        public Vector2 GameOriginalLocation()
        {
            return goombaOriginalLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength && running)
            {
                cyclePosition = 0;
                stateMachine.Update();
                GoombaSprite.Update();
                
                //if (goombaLocation.X == (goombaOriginalLocation.X - 5) || goombaLocation.X == (goombaOriginalLocation.X + 5))
                    //ChangeDirection();
                if (stateMachine.GetDirection())
                    goombaLocation.X += 1;
                else 
                    goombaLocation.X -= 1;
            }
        }
        public void Running()
        {
            running = true;
        }
    }
}
