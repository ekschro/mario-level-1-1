using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class KoopaShell : IEnemy
    {
        public float CurrentXPos { get => koopaLocation.X; set => koopaLocation.X = value; }
        public float CurrentYPos { get => koopaLocation.Y; set => koopaLocation.Y = value; }
        private bool falling;
        private bool jumping=false;
        public bool IsFalling { get => falling; set => falling = value; }
        public bool MovingRight { get; set; }
        private static IEnemySprite koopaSprite;
        public static IEnemySprite KoopaSprite { get => koopaSprite; set => koopaSprite = value; }
        public bool IsStomped { get; set; }
        public bool IsJumping { get => jumping; }

        private KoopaSStateMachine stateMachine;
        public IEnemyStateMachine StateMachine { get => stateMachine; }
        public bool IsMoving { get => !dead; }
        private int killedNum = 0;

        public int KilledNum { get => killedNum; set => killedNum = value; }

        private bool dead;
        
        private Vector2 koopaLocation;
        private Vector2 koopaOriginalLocation;
        private EnemyPhysics physics;

        

        public KoopaShell(Game1 game, Vector2 location)
        {
            KoopaSprite = new KoopaShellSprite(game, this);
            koopaLocation = location;
            koopaOriginalLocation = location;

            
            stateMachine = new KoopaSStateMachine(koopaSprite);

            physics = new EnemyPhysics(game, this, 4);
            falling = true;
            dead = false;
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }

        public void BeStomped()
        {
            stateMachine.BeStomped();
            IsStomped = true;
            dead = !dead;
        }

        public void ChangeDirection(bool faceLeft)
        {
            stateMachine.ChangeDirection(true);
        }

        public void Draw()
        {
            KoopaSprite.Draw();
        }

        public Vector2 GameObjectLocation => koopaLocation;

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
            if (dead==false)
            {
                physics.Update();
                falling = true;
            }
        }
        public bool Dead => dead;

    }
}
