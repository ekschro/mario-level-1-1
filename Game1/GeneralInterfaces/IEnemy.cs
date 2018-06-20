﻿using System;
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
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void Running();

    }
}
