using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MissileCommand.Controllers
{
    internal class MouseController
    {
        private MouseState mouse;
        private bool isReleased;
        private Vector2 position;

        public void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState(); // można te dwie linijki zapisać jako jedna, ale na razie zostawiam bo "mouse" może się przydać

            position = mouse.Position.ToVector2();
        }

        public Vector2 Position { get { return position; } }
    }
}
