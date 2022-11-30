using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MissileCommand.Controllers;
using System.Collections.Generic;

namespace MissileCommand.Objects
{

    internal class Turret
    {
        private static int turretY = 670;

        public static List<Turret> turrets = new List<Turret> {
                new Turret(new Vector2(20, turretY), Area.left),
                new Turret(new Vector2(620, turretY),Area.middle),
                new Turret(new Vector2(1220, turretY), Area.right)
            };

        private bool isDestroyed = false;
        private int radius = 50;
        private Vector2 position;
        private Area area;
        private int maxAntiMissile = 10;
        MouseState mouse;
        private bool isMouseReleased = false;
        private bool noAmmo = false;

        public Turret(Vector2 position, Area area)
        {
            this.position = position;
            this.area = area;
        }

        public void Update(GameTime gameTime)
        {

            mouse = Mouse.GetState();
            Vector2 mousePosition = mouse.Position.ToVector2();

            if (!isDestroyed && mouse.LeftButton == ButtonState.Pressed && isMouseReleased == true)
            {


                if (turrets.Count == 3)
                {

                    if (mouse.Position.X < 320)
                    {
                        MouseController.mouseArea = Area.left;
                    }
                    else if (mouse.Position.X > 935)
                    {
                        MouseController.mouseArea = Area.right;
                    }
                    else
                    {
                        MouseController.mouseArea = Area.middle;
                    }
                }

                if (turrets.Count == 2)
                {
                    int turretRange;
                    turrets[0].Area = Area.left;
                    turrets[1].Area = Area.right;

                    if (turrets[0].position.X == 20 && turrets[1].position.X == 620)
                    {
                        turretRange = 320;
                    }
                    else if (turrets[0].position.X == 620 && turrets[1].position.X == 1220)
                    {
                        turretRange = 960;
                    }
                    else
                    {
                        turretRange = 640;
                    }

                    if (mouse.Position.X < turretRange)
                    {
                        MouseController.mouseArea = Area.left;
                    }
                    else
                    {
                        MouseController.mouseArea = Area.right;
                    }

                }

                if (turrets.Count == 1)
                {
                    turrets[0].Area = Area.middle;
                    MouseController.mouseArea = Area.middle;
                }


                foreach (Turret t in turrets)
                {
                    if (t.Area == MouseController.mouseArea)
                    {

                        AntiMissile.antiMissiles.Add(new AntiMissile(t.Position, (mouse.Position.ToVector2()) - t.Position));
                        //maxAntiMissile--;
                    }
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

        public Area Area { get { return area; } set { area = value; } }

        public bool NoAmmo { get { return noAmmo; } }
    }
}
// || MouseController.mouseArea == Area.free <--- działające sprawdzenie na hit 