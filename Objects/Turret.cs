using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{

    internal class Turret
    {
        private static int turretY = 670;
        private static int ammo = 10;

        public static List<Turret> turrets = new List<Turret> {
                new Turret(new Vector2(20, turretY)),
                new Turret(new Vector2(620, turretY)),
                new Turret(new Vector2(1220, turretY))
            };

        private bool isDestroyed = false;
        private Vector2 position;

        public Turret(Vector2 position)
        {
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            if (!isDestroyed)
            {

            }
        }


        public Vector2 Position { get { return position; } }
    }
}
