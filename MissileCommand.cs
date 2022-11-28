using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MissileCommand.Controllers;
using MissileCommand.Objects;

namespace MissileCommand
{
    enum Direction
    {
        left,
        middle,
        right
    }
    public class MissileCommand : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D antiMissileSprite;
        private Texture2D missileSprite;
        private Texture2D turretSprite;
        private Texture2D citySprite;
        private Texture2D crosshairSprite;
        private Texture2D backgroundSprite;
        //TODO: explosion animation

        MissileController controller = new MissileController();


        public MissileCommand()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            antiMissileSprite = Content.Load<Texture2D>("anti_missile");
            missileSprite = Content.Load<Texture2D>("missile");
            turretSprite = Content.Load<Texture2D>("turret");
            citySprite = Content.Load<Texture2D>("city");
            crosshairSprite = Content.Load<Texture2D>("crosshair");
            backgroundSprite = Content.Load<Texture2D>("background");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            controller.Update(gameTime);
            foreach (Missile m in Missile.missiles)
            {
                m.Update(gameTime);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);

            foreach (City c in City.cities)
            {
                spriteBatch.Draw(citySprite, c.Position, Color.White);
            }

            foreach (Turret t in Turret.turrets)
            {
                spriteBatch.Draw(turretSprite, t.Position, Color.White);
            }

            foreach (Missile m in Missile.missiles)
            {
                spriteBatch.Draw(missileSprite, m.Position, Color.White);
            }

            // ZROBIĆ OFFSETY DO KAŻDEJ GRAFIKI

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}