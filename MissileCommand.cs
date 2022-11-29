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
        private Texture2D explosionSprite;

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
            explosionSprite = Content.Load<Texture2D>("explosion");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseController.Update(gameTime);

            missileController.Update(gameTime);

            foreach (AntiMissile a in AntiMissile.antiMissiles) { a.Update(gameTime); }

            foreach (Missile m in Missile.missiles) { m.Update(gameTime); }

            foreach (Turret t in Turret.turrets) { t.Update(gameTime); }

            foreach (Missile m in Missile.missiles)
            {
                foreach (AntiMissile a in AntiMissile.antiMissiles)
                {
                    int antiMissileHitbox = m.Radius + a.Radius; // do poprawy potem hitboxy
                    if (Vector2.Distance(a.Position, m.Position) < antiMissileHitbox)
                    {
                        m.IsDestroyed = true;
                        a.IsDestroyed = true;
                    }
                }

                foreach (City c in City.cities)
                {
                    int cityHitbox = m.Radius + c.Radius;
                    if (Vector2.Distance(m.Position, c.Position) < cityHitbox)
                    {
                        m.IsDestroyed = true;
                        c.IsDestroyed = true;
                    }

                }
                foreach (Turret t in Turret.turrets)
                {
                    int turretHitbox = m.Radius + t.Radius;
                    if (Vector2.Distance(m.Position, t.Position) < turretHitbox)
                    {
                        m.IsDestroyed = true;
                        t.IsDestroyed = true;
                    }
                }
            }

            Missile.missiles.RemoveAll(m => m.IsDestroyed);
            City.cities.RemoveAll(c => c.IsDestroyed);
            Turret.turrets.RemoveAll(t => t.IsDestroyed);
            AntiMissile.antiMissiles.RemoveAll(a => a.IsDestroyed);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);

            foreach (City c in City.cities)
            {
                if (!c.IsDestroyed)
                {
                    spriteBatch.Draw(citySprite, new Vector2(c.Position.X - c.Radius, c.Position.Y - c.Radius), Color.White);
                }

            }

            foreach (Turret t in Turret.turrets)
            {
                if (!t.IsDestroyed)
                {
                    spriteBatch.Draw(turretSprite, new Vector2(t.Position.X - t.Radius, t.Position.Y - t.Radius), Color.White);
                }
            }

            Rectangle sourceRectangle = new Rectangle(0, 0, missileSprite.Width, missileSprite.Height);
            Vector2 origin = new Vector2(0, 0);
            foreach (Missile m in Missile.missiles)
            {
                if (!m.IsDestroyed)
                {
                    spriteBatch.Draw(missileSprite, new Vector2(m.Position.X - m.Radius, m.Position.Y - m.Radius), sourceRectangle, Color.White, m.Angle, origin, 1.0f, SpriteEffects.None, 1);
                }
            }

            foreach (AntiMissile a in AntiMissile.antiMissiles)
            {
                if (!a.IsDestroyed)
                {
                    spriteBatch.Draw(antiMissileSprite, new Vector2(a.Position.X - a.Radius, a.Position.Y - a.Radius), Color.White);
                }
            }

            spriteBatch.Draw(crosshairSprite, new Vector2(mouseController.Position.X - 36, mouseController.Position.Y - 36), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}//TODO:
 //
 //
 //
 //
 //
 //poprawki kodu
 //wzorce projektowe
 //ograniczona amunicja
 //
 //wybuchy, które będą niszczyć swoim zasięgiem zamiast pociskami
 //Strzelanie z różnych wieżyczek w zależności od pozycji myszki
 //Dopasować lepiej hitboxy
