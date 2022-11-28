using Microsoft.Xna.Framework;
using MissileCommand.Objects;
using System;

namespace MissileCommand.Controllers
{
    class MissileController
    {

        private double timer = 5D;
        private double maxTime = 5D;
        private Random random = new Random();

        public void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                Missile.missiles.Add(new Missile(new Vector2(random.Next(0, 1280), -100)));

                timer = maxTime;
                if (maxTime > 2)
                {
                    maxTime -= 0.05;
                }
            }
        }
    }
}
