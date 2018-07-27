using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IEnemy : IGameObject
    {
        Vector2 GameOriginalLocation();
        void ChangeDirection(bool faceLeft);
        void BeStomped();
        void BeFlipped();
        void SetGameObjectLocation(Vector2 x);
        
        bool MovingRight { get; set; }
        bool Dead { get; }
        IEnemyStateMachine StateMachine { get; }
        bool IsFalling { get; set; }
        bool IsJumping { get; }
        bool IsStomped { get; set; }
    }
}
