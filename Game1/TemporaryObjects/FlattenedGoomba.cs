﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FlattenedGoomba : ITemporary
    {
        public float CurrentXPos { get => goombaOriginalLocation.X; set => goombaOriginalLocation.X = value; }
        public float CurrentYPos { get => goombaOriginalLocation.Y; set => goombaOriginalLocation.Y = value; }
        private ITemporarySprite goombaSprite;
        public ITemporarySprite GoombaSprite { get => goombaSprite; set => goombaSprite = value; }
        private Vector2 goombaOriginalLocation;
        private int timeBeforeDisappearing;
        Game1 myGame;

        public FlattenedGoomba(Game1 game, Vector2 location)
        {
            myGame = game;
            goombaOriginalLocation = location;
            GoombaSprite = new FlattenedGoombaSprite(game, this);
            timeBeforeDisappearing = 10;
        }
       
        public Vector2 GetGameObjectLocation()
        {
            return goombaOriginalLocation;
        }

        public void Update()
        {
            GoombaSprite.Update();

            timeBeforeDisappearing--;

            if (timeBeforeDisappearing <= 0)
                myGame.CurrentLevel.TemporaryObjects.Remove(this);
        }

        public void Draw()
        {
            GoombaSprite.Draw();
        }
    }
}