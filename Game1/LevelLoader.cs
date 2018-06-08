using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class LevelLoader : ILoader
    {
        public LevelLoader()
        {

        }

        public void Load(string fileName, List<IGameObject> gameObjects)
        {
            FileStream LoaderInput = new FileStream(fileName, FileMode.Open, FileAccess.Read,
   FileShare.Read);

        }
    }
}
