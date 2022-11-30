using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MissileCommand.Objects
{

    internal class Turret
    {
        private static int turretY = 670;

        public static List<Turret> turrets = new()
        {
                new Turret(new Vector2(20, turretY)),
                new Turret(new Vector2(620, turretY)),
                new Turret(new Vector2(1220, turretY))
            };

        private bool isDestroyed = false;
        private int radius = 50;
        private Vector2 position;
        private int maxAntiMissile = 10;
        MouseState mouse;
        private bool isMouseReleased = false;
        private bool noAmmo = false;

        public Turret(Vector2 position)
        {
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {

            mouse = Mouse.GetState();
            Vector2 mousePosition = mouse.Position.ToVector2();

            if (!isDestroyed && mouse.LeftButton == ButtonState.Pressed && isMouseReleased == true)
            {
                switch (turrets.Count)
                {
                    case 3:
                        if (Vector2.Distance(turrets[0].position, mousePosition) < Vector2.Distance(turrets[1].position, mousePosition))
                        {
                            if (Vector2.Distance(turrets[0].position, mousePosition) < Vector2.Distance(turrets[2].position, mousePosition))
                            {
                                AntiMissile.antiMissiles.Add(new AntiMissile(turrets[0].position, mouse.Position.ToVector2() - turrets[0].position));
                            }
                            else
                            {
                                AntiMissile.antiMissiles.Add(new AntiMissile(turrets[2].Position, mouse.Position.ToVector2() - turrets[2].position));
                            }
                        }
                        else if (Vector2.Distance(turrets[1].position, mousePosition) < Vector2.Distance(turrets[2].position, mousePosition))
                        {
                            AntiMissile.antiMissiles.Add(new AntiMissile(turrets[1].Position, mouse.Position.ToVector2() - turrets[1].position));
                        }
                        else
                        {
                            AntiMissile.antiMissiles.Add(new AntiMissile(turrets[2].Position, mouse.Position.ToVector2() - turrets[2].position));
                        }
                        break;
                    case 2:
                        if (Vector2.Distance(turrets[0].position, mousePosition) < Vector2.Distance(turrets[1].position, mousePosition))
                        {
                            AntiMissile.antiMissiles.Add(new AntiMissile(turrets[0].Position, mouse.Position.ToVector2() - turrets[0].position));
                        }
                        else
                        {
                            AntiMissile.antiMissiles.Add(new AntiMissile(turrets[1].Position, mouse.Position.ToVector2() - turrets[1].position));
                        }
                        break;
                    case 1:
                        AntiMissile.antiMissiles.Add(new AntiMissile(turrets[0].Position, mouse.Position.ToVector2() - turrets[0].position));
                        break;

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

        public bool NoAmmo { get { return noAmmo; } }
    }
}