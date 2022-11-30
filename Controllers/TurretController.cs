using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MissileCommand.Objects;

namespace MissileCommand.Controllers
{
    internal class TurretController
    {
        private bool isMouseReleased = false;
        MouseState mouse;
        public void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();
            Vector2 mousePosition = mouse.Position.ToVector2();

            foreach (Turret t in Turret.turrets)
            {
                if (t.Ammunition == 0)
                {
                    t.HasAmmunition = false;
                }
            }
            if (mouse.LeftButton == ButtonState.Pressed && isMouseReleased == true)
            {
                switch (Turret.turrets.Count)
                {
                    case 3:
                        if (Vector2.Distance(Turret.turrets[0].Position, mousePosition) < Vector2.Distance(Turret.turrets[1].Position, mousePosition))
                        {
                            if (Vector2.Distance(Turret.turrets[0].Position, mousePosition) < Vector2.Distance(Turret.turrets[2].Position, mousePosition))
                            {
                                AntiMissile.antiMissiles.Add(new AntiMissile(Turret.turrets[0].Position, mouse.Position.ToVector2() - Turret.turrets[0].Position));
                                Turret.turrets[0].Ammunition--;
                            }
                            else
                            {
                                AntiMissile.antiMissiles.Add(new AntiMissile(Turret.turrets[2].Position, mouse.Position.ToVector2() - Turret.turrets[2].Position));
                                Turret.turrets[2].Ammunition--;
                            }
                        }
                        else if (Vector2.Distance(Turret.turrets[1].Position, mousePosition) < Vector2.Distance(Turret.turrets[2].Position, mousePosition))
                        {
                            AntiMissile.antiMissiles.Add(new AntiMissile(Turret.turrets[1].Position, mouse.Position.ToVector2() - Turret.turrets[1].Position));
                            Turret.turrets[1].Ammunition--;
                        }
                        else
                        {
                            AntiMissile.antiMissiles.Add(new AntiMissile(Turret.turrets[2].Position, mouse.Position.ToVector2() - Turret.turrets[2].Position));
                            Turret.turrets[2].Ammunition--;
                        }
                        break;
                    case 2:
                        if (Vector2.Distance(Turret.turrets[0].Position, mousePosition) < Vector2.Distance(Turret.turrets[1].Position, mousePosition))
                        {
                            AntiMissile.antiMissiles.Add(new AntiMissile(Turret.turrets[0].Position, mouse.Position.ToVector2() - Turret.turrets[0].Position));
                            Turret.turrets[0].Ammunition--;
                        }
                        else
                        {
                            AntiMissile.antiMissiles.Add(new AntiMissile(Turret.turrets[1].Position, mouse.Position.ToVector2() - Turret.turrets[1].Position));
                            Turret.turrets[1].Ammunition--;
                        }
                        break;
                    case 1:
                        AntiMissile.antiMissiles.Add(new AntiMissile(Turret.turrets[0].Position, mouse.Position.ToVector2() - Turret.turrets[0].Position));
                        Turret.turrets[0].Ammunition--;
                        break;
                }

                isMouseReleased = false;

            }

            if (mouse.LeftButton == ButtonState.Released)
            {
                isMouseReleased = true;
            }

        }

    }
}
