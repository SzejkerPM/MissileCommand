using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{
    internal class AntiMissile
    {

        private int speed = 150;
        private Vector2 position;
        private Vector2 direction;
        private int radius = 13;
        private bool isDestroyed = false;

        public static List<AntiMissile> antiMissiles = new();


        public AntiMissile(Vector2 position, Vector2 direction)
        {
            this.position = position;
            this.direction = direction;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            direction.Normalize();
            position += direction * speed * deltaTime;
        }


        public Vector2 Position { get { return position; } }

        public int Radius { get { return radius; } }

        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }

    }
}
