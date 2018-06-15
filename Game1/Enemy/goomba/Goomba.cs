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
            stateMachine = new GoombaStateMachine();
            GoombaSprite = new GoombaSprite(game,this);
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
            GoombaSprite.ChangeFrame(2, 3);
            GoombaSprite.ChangeFrame(3, 4);
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
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                GoombaSprite.Update();
                stateMachine.Update();
                if (goombaLocation.X == (goombaOriginalLocation.X-20) || goombaLocation.X == (goombaOriginalLocation.X + 20))
                    direction = !direction;
                if (direction == true)
                    goombaLocation.X += 1;
                else if (direction == false)
                    goombaLocation.X -= 1;
            }
        }
    }
}
