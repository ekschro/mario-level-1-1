using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IPlayer : IGameObject
    {
        bool IsStar { get; set; }
        ITestMario TestMario { get; set; }
        bool CanJump { get; set; }
        bool Falling { get; set; }
        bool Bump { get; set; }
        bool Jumping { get; set; }
        bool Bounce { get; set; }
        bool Invulnerability { get; set; }
        int TotalMarioColumns { get; set; }
        int TotalMarioRows { get; set; }
        Color MarioColor { get; set; }
    }
}