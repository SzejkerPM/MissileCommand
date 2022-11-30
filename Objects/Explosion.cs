using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{
    internal class Explosion
    {
        public static int radius = 26;
        public static Vector2 position;
        public static bool isVisible = true;
        private static double timer = 3D;
        private static double maxTime = 3D;
        public static List<Explosion> explosions = new List<Explosion>();

        public Explosion(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Update(GameTime gameTime)
        {

            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {

                isVisible = false;
                /*timer = maxTime;*/
            }



        }



        public int Radius { get { return radius; } }

        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }

        public Vector2 Position { get { return position; } }

    }
}
