using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Level1 : ILevel
    {
        private List<IGameObject> levelObjects;
        
        public Level1(string fileName, Game1 game)
        {
            levelObjects = new List<IGameObject>();
            ILoader loader = new LevelLoader(game);

            loader.Load(fileName, levelObjects);
        }

        public void Update()
        {
            foreach (IGameObject GameObject in levelObjects)
            {
                GameObject.Update();
            }
        }

        public void Draw()
        {
            foreach (IGameObject GameObject in levelObjects)
            {
                GameObject.Draw();
            }
        }

        public IGameObject GetPlayerObject()
        {
            IGameObject playerObject = null;
            foreach(IPlayer player in levelObjects)
            {
                playerObject = player;
            }
            return playerObject;
        }
        public List<IGameObject> GetBlockObjects()
        {
            List<IGameObject> blockObjects = new List<IGameObject>();
            foreach (IBlock block in levelObjects)
            {
                blockObjects.Add(block);
            }
            return blockObjects;
        }
        public List<IGameObject> GetEnemyObjects()
        {
            List<IGameObject> enemyObjects = new List<IGameObject>();
            foreach (IEnemy enemy in levelObjects)
            {
                enemyObjects.Add(enemy);
            }
            return enemyObjects;
        }
        public List<IGameObject> GetPickupObjects()
        {
            List<IGameObject> pickupObjects = new List<IGameObject>();
            foreach (IPickup pickup in levelObjects)
            {
                pickupObjects.Add(pickup);
            }
            return pickupObjects;
        }
    }
}
