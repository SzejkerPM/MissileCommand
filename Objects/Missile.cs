using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{
    class Missile
    {

        public static List<Missile> missiles = new List<Missile>();
        private int speed = 120;
        private Vector2 position;

        public Missile(Vector2 position)
        {
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 direction = new Vector2(position.X, 800) - position;
            direction.Normalize();
            position += direction * speed * deltaTime;
        }

        public Vector2 Position { get { return position; } }

    }
}
