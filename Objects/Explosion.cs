using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{
    internal class Explosion
    {

        public static int radius = 26;
        public static bool isVisible;
        private static double timer = 2D;
        private static double maxTime = 2D;
        private Vector2 position = new Vector2(0, 0);

        public static List<Explosion> explosions = new();

        public Explosion(Vector2 position)
        {
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            isVisible = true;
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                isVisible = false;
                timer = maxTime;
            }
        }


        public int Radius { get { return radius; } }

        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }

        public Vector2 Position { get { return position; } }

    }
}
