using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class GeneralPhysics
    {
        private Game1 game;
        private IEnemy obj;
        private float delta;
        private int velCap;
        private float xVelocity;
        private float yVelocity;

        public GeneralPhysics(Game1 game,IEnemy obj,int velCap)
        {
            this.game = game;
            this.obj = obj;

            this.velCap = velCap;
            xVelocity = (float)1;
            yVelocity = (float)2;
        }

        public void Update()
        {
            delta = game.delta.ElapsedGameTime.Milliseconds;
            NewPosX();
            NewPosY();
        }

        public void NewPosX()
        {
            if (obj.GetStateMachine.GetDirection())
                obj.SetGameObjectLocation(new Vector2(obj.GetGameObjectLocation().X + xVelocity, obj.GetGameObjectLocation().Y));
            else
                obj.SetGameObjectLocation(new Vector2(obj.GetGameObjectLocation().X - xVelocity, obj.GetGameObjectLocation().Y));
        }

        public void NewPosY()
        {
            obj.SetGameObjectLocation(new Vector2(obj.GetGameObjectLocation().X,obj.GetGameObjectLocation().Y + yVelocity));
        }


    }
}
