using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class HUDPoints : ITemporary
    {
        private Game1 game;
        private int points;
        private Vector2 loc;
        private float alpha;

        public float CurrentXPos { get => loc.X; set => throw new NotImplementedException(); }
        public float CurrentYPos { get => loc.Y; set => throw new NotImplementedException(); }

        public HUDPoints(Game1 game, int points, Vector2 loc)
        {
            this.game = game;
            this.points = points;
            this.loc = loc;
            this.loc.X = game.CurrentLevel.LevelCamera.PositionRelativeToCamera(loc.X);
            alpha = 0f;
        }

        public void Update()
        {
            loc.Y -= 1;
            alpha += 0.01f;
        }

        public void Draw()
        {
            game.SpriteBatch.Begin();
            game.SpriteBatch.DrawString(game.SpriteFont, points.ToString(), loc, Color.Lerp(Color.White,Color.CornflowerBlue,alpha));
            game.SpriteBatch.End();
        }

        public Vector2 GetGameObjectLocation()
        {
            return loc;
        }
    }
}
