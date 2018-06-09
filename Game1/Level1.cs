using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Level1 : ILevel
    {
        public List<IGameObject> levelObjects;

        public Level1(string fileName)
        {
            levelObjects = new List<IGameObject>();
            ILoader loader = new LevelLoader();

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
    }
}
