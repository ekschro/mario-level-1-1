using System;
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
        List<IBlock> BlockObjects { get; }
        List<IEnemy> EnemyObjects { get; }
        List<IPickup> PickupObjects { get; }
        IPlayer PlayerObject { get; set; }
    }
}
