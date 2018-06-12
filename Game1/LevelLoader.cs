using Microsoft.Xna.Framework;
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
        Game1 myGame;
        public IGameObject mario;
       
        public LevelLoader(Game1 game)
        {
            myGame = game;
            
        }

        public void Load(string fileName, List<IGameObject> gameObjects)
        {
            StreamReader LoaderInput = new StreamReader(fileName);

            while (!LoaderInput.EndOfStream)
            {
                int NextChar;
                string GameObjectString = "";
                int PositionX;
                int PositionY;
                
                while((NextChar = LoaderInput.Read()) != ',' && !LoaderInput.EndOfStream)
                {
                    GameObjectString = GameObjectString + NextChar;
                }

                if (LoaderInput.EndOfStream)
                    break;

                PositionX = Convert.ToInt32(LoaderInput.Read());
                LoaderInput.Read();
                PositionY = Convert.ToInt32(LoaderInput.Read());
                LoaderInput.Read();

                gameObjects.Add(GenerateObject(GameObjectString, PositionX, PositionY));
            }
        }

        public IGameObject GenerateObject(string objectName, int positionX, int positionY)
        {
            Vector2 Position = new Vector2(positionX, positionY);
            IGameObject GameObject = new Mario(myGame, Position);
            mario = GameObject;
            switch (objectName) {
                case "Mario" :
                    GameObject = new Mario(myGame, Position);
                    mario = GameObject;
                    break;
                case "FireFlower":
                    GameObject = new FireflowerSprite(myGame, Position);
                    break;
                case "Coin":
                    GameObject = new CoinSprite(myGame, Position);
                    break;
                case "RedMushroom":
                    GameObject = new RedMushroomSprite(myGame, Position);
                    break;
                case "GreenMushroom":
                    GameObject = new GreenMushroomSprite(myGame, Position);
                    break;
                case "Star":
                    GameObject = new StarSprite(myGame, Position);
                    break;
                case "Goomba":
                    GameObject = new GoombaSprite(myGame, Position);
                    break;
                case "Koopa":
                    GameObject = new KoopaSprite(myGame, Position);
                    break;
                case "HiddenBlock":
                    GameObject = new Block(Position, new HiddenBlockSprite());
                    break;
                case "StairBlock":
                    GameObject = new Block(new StairBlockSprite(myGame, Position));
                    break;
                case "UsedBlock":
                    GameObject = new Block(new UsedBlockSprite(myGame, Position));
                    break;
                case "QuestionBlockWithPowerUp":
                    GameObject = new Block(new QuestionBlockSprite(myGame, Position));
                    break;
                case "QuestionBlockWithCoin":
                    GameObject = new Block(new QuestionBlockSprite(myGame, Position));
                    break;
                case "BrickBlock":
                    GameObject = new Block(new BrickBlockSprite(myGame, Position));
                    break;
                case "StoneBlock":
                    GameObject = new Block(new StoneBlockSprite(myGame, Position));
                    break;
                case "TopLeftPipeBlock":
                    GameObject = new Block(new TopLeftPipeSprite(myGame, Position));
                    break;
                case "TopRightPipeBlock":
                    GameObject = new Block(new TopRightPipeSprite(myGame, Position));
                    break;
                case "BottomLeftPipeBlock":
                    GameObject = new Block(new BottomLeftPipeSprite(myGame, Position));
                    break;
                case "BottomRightPipeBlock":
                    GameObject = new Block(new BottomRightPipeSprite(myGame, Position));
                    break;
            }
            return GameObject;
        }

    }
}
