﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface ILevel
    {
        void Update();
        void Draw();
        IGameObject GetPlayerObject();
        List<IGameObject> GetBlockObjects();
        List<IGameObject> GetEnemyObjects();
        List<IGameObject> GetPickupObjects();
    }
}
