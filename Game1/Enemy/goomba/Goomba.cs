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
        private static IEnemySprite goombaSprite;
        public static IEnemySprite GoombaSprite { get => goombaSprite; set => goombaSprite = value; }
        private GoombaStateMachine stateMachine;
        private Game1 myGame;
        private bool direction = true;
        private int cyclePosition = 0;
        private int cycleLength = 8;
        public Vector2 goombaLocation;
        private Vector2 goombaOriginalLocation;

        public Goomba(Game1 game, Vector2 location)
        {
            
            GoombaSprite = new GoombaSprite(game,this);
            stateMachine = new GoombaStateMachine(GoombaSprite);
            myGame = game;
            goombaLocation = location;
            goombaOriginalLocation = location;
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
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                GoombaSprite.Update();
                stateMachine.Update();
                if (goombaLocation.X == (goombaOriginalLocation.X - 20) || goombaLocation.X == (goombaOriginalLocation.X + 20))
                    ChangeDirection();
                if (direction == true)
                    goombaLocation.X += 1;
                else if (direction == false)
                    goombaLocation.X -= 1;
            }
        }
    }
}
