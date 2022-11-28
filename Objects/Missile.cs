using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{
    class Missile
    {

        public static List<Missile> missiles = new List<Missile>();
        private int speed = 80;
        private Vector2 position;
        private float angle;

        public Missile(Vector2 position, float angle)
        {
            this.position = position;
            this.angle = angle;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 direction;
            if (angle > 0)
            {
                direction = new Vector2(position.X--, 2000) - position;
            }
            else if (angle < 0)
            {
                direction = new Vector2(position.X++, 2000) - position;
            }
            else
            {
                direction = new Vector2(position.X, 2000) - position;
            }

            direction.Normalize();
            position += direction * speed * deltaTime;
        }

        public Vector2 Position { get { return position; } }

        public float Angle { get { return angle; } }
    }
}
