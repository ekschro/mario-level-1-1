using System;

namespace Game1
{
    public interface IPlayer : IGameObject
    {
        bool IsStar { get; set; }
    }
}