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
        List<ITemporary> TemporaryObjects { get; }
        IPlayer PlayerObject { get; set; }
        ICamera LevelCamera { get; set; }
        PersistentData PersistentData { get; }
        int EndLocation { get; }
    }
}
