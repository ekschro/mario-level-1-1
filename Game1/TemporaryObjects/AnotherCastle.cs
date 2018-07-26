using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class AnotherCastle : ITemporary
    {
        private int timeBeforeAppearing;
        //private Game1 myGame;

        private Vector2 position;
        private AnotherCastleSprite anotherCastleSprite;

        public float CurrentXPos { get => position.X; set => position.X = value; }
        public float CurrentYPos { get => position.Y; set => position.Y = value; }

        public AnotherCastle(Game1 game, Vector2 location)
        {
           // myGame = game;
            position = location;
            anotherCastleSprite = new AnotherCastleSprite(game, this);
           
            timeBeforeAppearing = 350;
        }
       
        public Vector2 GetGameObjectLocation()
        {
            return position;
        }

        public void Update()
        {
            anotherCastleSprite.Update();
            timeBeforeAppearing--;
        }

        public void Draw()
        {
            if(timeBeforeAppearing < 0)
                anotherCastleSprite.Draw();
        }
    }
}
