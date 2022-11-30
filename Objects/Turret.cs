using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{

    internal class Turret
    {
        private static int turretY = 676;

        public static List<Turret> turrets = new()
        {
                new Turret(new Vector2(30, turretY)),
                new Turret(new Vector2(630, turretY)),
                new Turret(new Vector2(1230, turretY))
            };

        private bool isDestroyed = false;
        private int radius = 50;
        private Vector2 position;
        private int ammunition = 10;
        private bool hasAmmunition = true;

        public Turret(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 Position { get { return position; } }

        public int Radius { get { return radius; } }

        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }
        public int Ammunition { get { return ammunition; } set { ammunition = value; } }
        public bool HasAmmunition { get { return hasAmmunition; } set { hasAmmunition = value; } }
    }
}