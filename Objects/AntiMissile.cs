using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{
    internal class AntiMissile
    {
        private int speed = 150;
        private Vector2 position;
        private Vector2 direction;
        private float angle;
        private int radius = 10;
        private bool isDestroyed = false;
        public static List<AntiMissile> antiMissiles = new List<AntiMissile>();

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

        public float Angle { get { return angle; } }

        public int Radius { get { return radius; } }

        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }
    }
}
