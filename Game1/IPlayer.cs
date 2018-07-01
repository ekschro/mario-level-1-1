using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IPlayer : IGameObject
    {
        bool IsStar { get; set; }
        ISprite MarioSprite { get; set; }
        float CurrentYPos { get; set; }
        bool CanJump { get; set; }
        bool Falling { get; set; }
        bool Bump { get; set; }
        bool Jumping { get; set; }
        float CurrentXPos { get; set; }
        //bool MovingRight { get; set; }
        bool Bounce { get; set; }
        bool Invulnerability { get; set; }
        //bool MovingLeft { get; set; }
        //bool MovingUp { get; set; }
        int TotalMarioColumns { get; set; }
        int TotalMarioRows { get; set; }
        Color MarioColor { get; set; }
        //bool MovingDown { get; set; }
        //float CurrentXPosition { get; set; }
        //float CurrentYPosition { get; set; }
        //Color MarioColor { get; set; }
    }
}