using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MissileCommand
{
    public class MissileCommand : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D antiMissileSprite;
        private Texture2D antiMissilePathSprite;
        private Texture2D missileSprite;
        private Texture2D missilePathSprite;
        private Texture2D turretSprite;
        private Texture2D citySprite;
        private Texture2D crosshairSprite;
        private Texture2D backgroundSprite;
        //TODO: explosion animation

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
            antiMissilePathSprite = Content.Load<Texture2D>("anti_missile_path");
            missileSprite = Content.Load<Texture2D>("missile");
            missilePathSprite = Content.Load<Texture2D>("missile_path");
            turretSprite = Content.Load<Texture2D>("turret");
            citySprite = Content.Load<Texture2D>("city");
            crosshairSprite = Content.Load<Texture2D>("crosshair");
            backgroundSprite = Content.Load<Texture2D>("background");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}