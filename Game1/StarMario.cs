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
        int timer = 10;
        public bool IsStar { get; set; }

        public StarMario(IPlayer decoratedMario, Game1 game)
        {
            this.decoratedMario = decoratedMario;
            decoratedMario.IsStar = true;
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
            decoratedMario.IsStar = false;
        }

        public void Draw()
        {
            decoratedMario.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return decoratedMario.GameObjectLocation();
        }

        //public bool IsStar()
        //{
        //    return true;
        //}
    }
}
