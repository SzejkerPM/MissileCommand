using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MissileCommand.Controllers;
using MissileCommand.Objects;

namespace MissileCommand
{
    enum Area
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

        MissileController missileController = new MissileController();
        MouseController mouseController = new MouseController();


        public MissileCommand()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
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

            missileController.Update(gameTime);
            foreach (Missile m in Missile.missiles)
            {
                m.Update(gameTime);
            }

            mouseController.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);

            foreach (City c in City.cities)
            {
                spriteBatch.Draw(citySprite, new Vector2(c.Position.X - 100, c.Position.Y - 100), Color.White);
            }

            foreach (Turret t in Turret.turrets)
            {
                spriteBatch.Draw(turretSprite, new Vector2(t.Position.X - 40, t.Position.Y - 40), Color.White);
            }

            Rectangle sourceRectangle = new Rectangle(0, 0, missileSprite.Width, missileSprite.Height);
            Vector2 origin = new Vector2(0, 0);
            foreach (Missile m in Missile.missiles)
            {
                spriteBatch.Draw(missileSprite, new Vector2(m.Position.X - 20, m.Position.Y - 20), sourceRectangle, Color.White, m.Angle, origin, 1.0f, SpriteEffects.None, 1);
            }

            spriteBatch.Draw(crosshairSprite, new Vector2(mouseController.Position.X - 36, mouseController.Position.Y - 36), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}