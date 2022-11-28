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

            int side = random.Next(3);

            if (timer <= 0)
            {
                switch (side)
                {
                    case 0: // leci w lewo
                        Missile.missiles.Add(new Missile(new Vector2(random.Next(650, 1280), -100), 0.6f));
                        break;
                    case 1:
                        Missile.missiles.Add(new Missile(new Vector2(random.Next(0, 1280), -100), 0));
                        break;
                    case 2://leci w prawo
                        Missile.missiles.Add(new Missile(new Vector2(650, -100), -0.6f));
                        break;
                }

                timer = maxTime;
                if (maxTime > 2)
                {
                    maxTime -= 0.05;
                }
            }
        }
    }
}
