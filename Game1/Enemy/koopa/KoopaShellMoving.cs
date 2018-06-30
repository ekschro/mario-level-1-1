using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class KoopaShellMoving : IEnemy
    {
        public float CurrentXPos { get => koopaLocation.X; set => koopaLocation.X = value; }
        public float CurrentYPos { get => koopaLocation.Y; set => koopaLocation.Y = value; }
        private bool falling;
        public bool IsFalling { get => falling; set => falling = value; }

        private static IEnemySprite koopaSprite;
        public static IEnemySprite KoopaSprite { get => koopaSprite; set => koopaSprite = value; }
        public bool IsStomped { get; set; }

        public IEnemyStateMachine GetStateMachine => new KoopaStateMachine(KoopaSprite);

        private bool dead;
        
        private Vector2 koopaLocation;
        private Vector2 koopaOriginalLocation;
        private GeneralPhysics physics;

        private Game1 myGame;
        public bool isLeft;

        public KoopaShellMoving(Game1 game, KoopaShell shell, bool isLeft)
        {
            KoopaSprite = new KoopaShellSprite(game,this);
            koopaLocation = shell.GetGameObjectLocation();
            koopaOriginalLocation = shell.GetGameObjectLocation();

            physics = new GeneralPhysics(game,this,4);
            falling = true;

            myGame = game;
            this.isLeft = isLeft;
        }

        public void BeFlipped()
        {
        }

        public void BeStomped()
        {
            new GeneralPhysics(myGame, this, 4);
        }

        public void ChangeDirection()
        {
        }

        public void Draw()
        {
            KoopaSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return koopaLocation;
        }

        public void SetGameObjectLocation(Vector2 newPos)
        {
            koopaLocation = newPos;
        }

        public Vector2 GameOriginalLocation()
        {
            return koopaOriginalLocation;
        }

        public void Update()
        {
            physics.Update();
            falling = true;
        }
        public bool GetDead()
        {
            return dead;
        }

    }
}
