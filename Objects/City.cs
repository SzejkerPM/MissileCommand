using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{
    internal class City
    {

        private static int cityY = 736;
        private bool isDestroyed = false;
        private int radius = 84;
        private Vector2 position;

        public static List<City> cities = new()
        {
                new City(new Vector2(175, cityY)),
                new City(new Vector2(360, cityY)),
                new City(new Vector2(545, cityY)),
                new City(new Vector2(790, cityY)),
                new City(new Vector2(975, cityY)),
                new City(new Vector2(1160, cityY))
            };

        public City(Vector2 position)
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
    }
}
