using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{
    enum Direction
    {
        left,
        middle,
        right
    }
    internal class Turret
    {
        private static int turretY = 630;
        private static int ammo = 10;

        public static List<Turret> turrets = new List<Turret> {
                new Turret(new Vector2(-20, turretY)),
                new Turret(new Vector2(580, turretY)),
                new Turret(new Vector2(1180, turretY))
            };

        private bool isDestroyed = false;
        private Vector2 position;
        private int hitbox = 40; // 80/2

        public Turret(Vector2 position)
        {
            this.position = position;
        }


        public Vector2 Position { get { return position; } }
    }
}
