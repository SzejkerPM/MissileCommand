using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MissileCommand.Objects
{

    internal class Turret
    {
        private static int turretY = 670;

        public static Turret[] turrets = new Turret[3] {
                new Turret(new Vector2(20, turretY), Area.left),
                new Turret(new Vector2(620, turretY),Area.middle),
                new Turret(new Vector2(1220, turretY), Area.right)
            };

        private bool isDestroyed = false;
        private int radius = 40;
        private Vector2 position;
        private Area area;
        private int maxAntiMissile = 10;
        MouseState mouse;
        private bool isMouseReleased = false;

        public Turret(Vector2 position, Area area)
        {
            this.position = position;
            this.area = area;
        }

        public void Update(GameTime gameTime)
        {

            mouse = Mouse.GetState();

            if (!isDestroyed && mouse.LeftButton == ButtonState.Pressed && isMouseReleased == true)
            {
                if (mouse.Position.X < 426 && area == Area.left)
                {
                    AntiMissile.antiMissiles.Add(new AntiMissile(turrets[0].position, (mouse.Position.ToVector2()) - position));
                }
                else if (mouse.Position.X < 854 && area == Area.middle)
                {
                    AntiMissile.antiMissiles.Add(new AntiMissile(turrets[1].position, (mouse.Position.ToVector2()) - position));
                }
                else
                {
                    AntiMissile.antiMissiles.Add(new AntiMissile(turrets[2].position, (mouse.Position.ToVector2()) - position));
                }
                isMouseReleased = false;
            }

            if (mouse.LeftButton == ButtonState.Released)
            {
                isMouseReleased = true;
            }
        }


        public Vector2 Position { get { return position; } }

        public int Radius { get { return radius; } }

        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }

        // public Area Area { get { return area; } }
    }
}
