using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{


    



    public class ExitGameCommand : ICommand
    {
        private Game1 myGame;

        public ExitGameCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }

    public class UpCommand : ICommand
    {
        private Game1 myGame;

        public UpCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        { 
            myGame.marioSprite.UpCommandCalled();
        }
    }

    public class DownCommand : ICommand
    {
        private Game1 myGame;

        public DownCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.DownCommandCalled();
        }
    }

    public class LeftCommand : ICommand
    {
        private Game1 myGame;

        public LeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.LeftCommandCalled();
        }
    }

    public class RightCommand : ICommand
    {
        private Game1 myGame;

        public RightCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.RightCommandCalled();
        }
    }

    public class SmallMarioCommand : ICommand
    {
        private Game1 myGame;

        public SmallMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.SmallMarioCommandCalled();
        }
    }

    public class BigMarioCommand : ICommand
    {
        private Game1 myGame;

        public BigMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.BigMarioCommandCalled();
        }
    }

    public class FireMarioCommand : ICommand
    {
        private Game1 myGame;

        public FireMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.FireMarioCommandCalled();
        }
    }

    public class DeadMarioCommand : ICommand
    {
        private Game1 myGame;

        public DeadMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.DeadMarioCommandCalled();
        }
    }

    public class QuestionToUsedCommand : ICommand
    {
        private Game1 myGame;

        public QuestionToUsedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Block3Sprite.QuestionToUsed();
        }
    }

    public class BrickDisappearCommand : ICommand
    {
        private Game1 myGame;

        public BrickDisappearCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Block4Sprite.BrickToEmpty();
        }
    }

    public class HiddenToUsedCommand : ICommand
    {
        private Game1 myGame;

        public HiddenToUsedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Block6Sprite.HiddenToUsed();
        }
    }

    public class ResetCommand : ICommand
    {
        private Game1 myGame;

        public ResetCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Reset();
        }
    }

    public class GoombaStompedCommand : ICommand
    {
        private Game1 myGame;

        public GoombaStompedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.GoombaSprite.BeStomped();
        }
    }

    public class KoopaStompedCommand : ICommand
    {
        private Game1 myGame;

        public KoopaStompedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.KoopaSprite.BeStomped();
        }
    }
}
    