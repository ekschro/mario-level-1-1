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
        List<IBlock> BlockObjects { get; set; }
        List<IEnemy> EnemyObjects { get; set; }
        List<IPickup> PickupObjects { get; set; }
        IPlayer PlayerObject { get; set; }
    }
}
