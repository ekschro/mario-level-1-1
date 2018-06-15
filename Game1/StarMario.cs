using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class StarMario : IPlayer
    {
        IPlayer decoratedMario;
        IPlayer marioObject;
        Game1 myGame;
        int timer = 1000;

        public StarMario(IPlayer decoratedMario, Game1 game)
        {
            this.decoratedMario = decoratedMario;
            myGame = game;
            marioObject = myGame.PlatformerLevel.GetPlayerObject();
        }

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                RemoveStar();
            }

            decoratedMario.Update();
        }


        public void RemoveStar()
        { 
            marioObject = decoratedMario;
        }

        public void Draw()
        {
            decoratedMario.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return decoratedMario.GameObjectLocation();
        }

        public bool IsStar()
        {
            return true;
        }
    }
}
