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
        IPlayer GetPlayerObject();
        List<IBlock> GetBlockObjects();
        List<IEnemy> GetEnemyObjects();
        List<IPickup> GetPickupObjects();
        List<IGameObject> GetGameObjects();
    }
}
