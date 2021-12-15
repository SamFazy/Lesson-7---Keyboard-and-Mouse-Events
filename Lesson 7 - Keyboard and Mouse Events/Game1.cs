using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson_7___Keyboard_and_Mouse_Events
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState;

        Texture2D pacUpTexture;
        Texture2D pacDownTexture;
        Texture2D pacLeftTexture;
        Texture2D pacRightTexture;
        Texture2D pacSleepTexture;
        Texture2D pacTexture;

        Rectangle pacLocation;

        Texture2D pacUpDoubleTexture;
        Texture2D pacDownDoubleTexture;
        Texture2D pacLeftDoubleTexture;
        Texture2D pacRightDoubleTexture;
        Texture2D pacSleepDoubleTexture;
        Texture2D pacDoubleTexture;

        Rectangle pacDoubleLocation;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pacLocation = new Rectangle(450, 155, 75, 75);

            pacDoubleLocation = new Rectangle(300, 155, 75, 75);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            pacDownTexture = Content.Load<Texture2D>("PacDown");
            pacUpTexture = Content.Load<Texture2D>("PacUp");
            pacLeftTexture = Content.Load<Texture2D>("PacLeft");
            pacRightTexture = Content.Load<Texture2D>("PacRight");
            pacSleepTexture = Content.Load<Texture2D>("PacSleep");
            pacTexture = pacSleepTexture;

            pacDownDoubleTexture = Content.Load<Texture2D>("PacDown");
            pacUpDoubleTexture = Content.Load<Texture2D>("PacUp");
            pacLeftDoubleTexture = Content.Load<Texture2D>("PacLeft");
            pacRightDoubleTexture = Content.Load<Texture2D>("PacRight");
            pacSleepDoubleTexture = Content.Load<Texture2D>("PacSleep");
            pacDoubleTexture = pacSleepTexture;
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacTexture = pacUpTexture;
                pacLocation.Y -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacTexture = pacDownTexture;
                pacLocation.Y += 5;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacTexture = pacLeftTexture;
                pacLocation.X -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacTexture = pacRightTexture;
                pacLocation.X += 5;
            }
            if (!keyboardState.IsKeyDown(Keys.Up) && !keyboardState.IsKeyDown(Keys.Right) && !keyboardState.IsKeyDown(Keys.Left) && !keyboardState.IsKeyDown(Keys.Down))
            {
                pacTexture = pacSleepTexture;
            }

            if(pacLocation.Left < 0)
            {
                pacLocation.X = 0;
            }
            if (pacLocation.Top < 0)
            {
                pacLocation.Y = 0;
            }

            if (pacLocation.Bottom >= _graphics.PreferredBackBufferHeight)
            {
                pacLocation.Y = _graphics.PreferredBackBufferHeight - 75;
            }

            if (pacLocation.Right >= _graphics.PreferredBackBufferWidth)
            {
                pacLocation.X = _graphics.PreferredBackBufferWidth - 75;
            }




            if (keyboardState.IsKeyDown(Keys.W))
            {
                pacDoubleTexture = pacUpDoubleTexture;
                pacDoubleLocation.Y -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                pacDoubleTexture = pacDownDoubleTexture;
                pacDoubleLocation.Y += 5;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                pacDoubleTexture = pacLeftDoubleTexture;
                pacDoubleLocation.X -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                pacDoubleTexture = pacRightDoubleTexture;
                pacDoubleLocation.X += 5;
            }
            if (!keyboardState.IsKeyDown(Keys.W) && !keyboardState.IsKeyDown(Keys.A) && !keyboardState.IsKeyDown(Keys.S) && !keyboardState.IsKeyDown(Keys.D))
            {
                pacDoubleTexture = pacSleepDoubleTexture;
            }

            if (pacDoubleLocation.Left < 0)
            {
                pacDoubleLocation.X = 0;
            }
            if (pacDoubleLocation.Top < 0)
            {
                pacDoubleLocation.Y = 0;
            }

            if (pacDoubleLocation.Bottom >= _graphics.PreferredBackBufferHeight)
            {
                pacDoubleLocation.Y = _graphics.PreferredBackBufferHeight - 75;
            }

            if (pacDoubleLocation.Right >= _graphics.PreferredBackBufferWidth)
            {
                pacDoubleLocation.X = _graphics.PreferredBackBufferWidth - 75;
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);

            _spriteBatch.Draw(pacDoubleTexture, pacDoubleLocation, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
