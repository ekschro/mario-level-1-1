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

            collisionDetect = new CollisionDetect(game,this);
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

        public IPlayer GetPlayerObject()
        {
            IPlayer playerObject = null;
            foreach(IGameObject player in levelObjects)
            {
                if(player is IPlayer)
                    playerObject = (IPlayer)player;
            }
            return playerObject;
        }
        public List<IBlock> GetBlockObjects()
        {
            List<IBlock> blockObjects = new List<IBlock>();
            foreach (IGameObject block in levelObjects)
            {
                if(block is IBlock)
                    blockObjects.Add((IBlock)block);
            }
            return blockObjects;
        }
        public List<IEnemy> GetEnemyObjects()
        {
            List<IEnemy> enemyObjects = new List<IEnemy>();
            foreach (IGameObject enemy in levelObjects)
            {
                if(enemy is IEnemy)
                    enemyObjects.Add((IEnemy)enemy);
            }
            return enemyObjects;
        }
        public List<IPickup> GetPickupObjects()
        {
            List<IPickup> pickupObjects = new List<IPickup>();
            foreach (IGameObject pickup in levelObjects)
            {
                if(pickup is IPickup)
                    pickupObjects.Add((IPickup)pickup);
            }
            return pickupObjects;
        }
        public List<IGameObject> GetGameObjects()
        {
            return levelObjects;
        }
    }
}
