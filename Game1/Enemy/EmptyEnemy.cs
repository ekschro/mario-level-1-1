using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Empty : IEnemy
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private static IEnemySprite emptySprite;
        public static IEnemySprite EmptySprite { get => emptySprite; set => emptySprite = value; }
        //private Game1 myGame;

        private Vector2 emptyLocation;
        private Vector2 emptyOriginalLocation;

        public Empty(Game1 game, Vector2 location)
        {

            EmptySprite = new EmptySprite(game, this);
            //myGame = game;
            emptyLocation = location;
            emptyOriginalLocation = location;
        }

        public void BeFlipped()
        {
            //stateMachine.BeFlipped();
        }

        public void BeStomped()
        {
            //stateMachine.BeStomped();
        }

        public void ChangeDirection()
        {
            //stateMachine.ChangeDirection();
            //direction = !direction;
        }

        public void Draw()
        {
            EmptySprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return emptyLocation;
        }
        public Vector2 GameOriginalLocation()
        {
            return emptyOriginalLocation;
        }

        public void Update()
        {
        }
        public void Running()
        {

        }
    }
}
