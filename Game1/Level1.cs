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
        private ICollision collisionDetect;
        
        public Level1(string fileName, Game1 game)
        {
            levelObjects = new List<IGameObject>();
            ILoader loader = new LevelLoader(game);

            loader.Load(fileName, levelObjects);

            collisionDetect = new CollisionDetect(this);
        }

        public void Update()
        {
            foreach (IGameObject GameObject in levelObjects)
            {
                GameObject.Update();
            }

            collisionDetect.Update();
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
            foreach(IGameObject player in levelObjects)
            {
                if(player is IPlayer)
                    playerObject = player;
            }
            return playerObject;
        }
        public List<IGameObject> GetBlockObjects()
        {
            List<IGameObject> blockObjects = new List<IGameObject>();
            foreach (IGameObject block in levelObjects)
            {
                if(block is IBlock)
                    blockObjects.Add(block);
            }
            return blockObjects;
        }
        public List<IGameObject> GetEnemyObjects()
        {
            List<IGameObject> enemyObjects = new List<IGameObject>();
            foreach (IGameObject enemy in levelObjects)
            {
                if(enemy is IEnemy)
                    enemyObjects.Add(enemy);
            }
            return enemyObjects;
        }
        public List<IGameObject> GetPickupObjects()
        {
            List<IGameObject> pickupObjects = new List<IGameObject>();
            foreach (IGameObject pickup in levelObjects)
            {
                if(pickup is IPickup)
                    pickupObjects.Add(pickup);
            }
            return pickupObjects;
        }
    }
}
