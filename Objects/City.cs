using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MissileCommand.Objects
{
    internal class City
    {

        private static int cityY = 636;

        public static List<City> cities = new List<City> {
                new City(new Vector2(50, cityY)),
                new City(new Vector2(250, cityY)),
                new City(new Vector2(450, cityY)),
                new City(new Vector2(680, cityY)),
                new City(new Vector2(880, cityY)),
                new City(new Vector2(1080, cityY))
            };

        private bool isDestroyed = false;
        private Vector2 position;
        private int hitbox = 100; // sprawdzić czy będzie okej

        public City(Vector2 position)
        {
            this.position = position;
        }


        public Vector2 Position { get { return position; } }
    }
}
