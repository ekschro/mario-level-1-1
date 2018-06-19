using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IPlayer : IGameObject
    {
        bool IsStar { get; set; }
        //Color MarioColor { get; set; }
    }
}