using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MissileCommand.Controllers
{
    internal class MouseController
    {
        private Vector2 position;

        public void Update(GameTime gameTime)
        {
            position = Mouse.GetState().Position.ToVector2();
        }

        public Vector2 Position { get { return position; } }
    }
}
