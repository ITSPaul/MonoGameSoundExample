using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SoundExample
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Song BackingTrack;
        SoundEffect cymbol, kick, snare, top;
        SoundEffect _music;
        SoundEffectInstance _mplayer;
        KeyboardState oldKeyState;
        SpriteFont _font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            BackingTrack = Content.Load<Song>(@"Songs/Acruta Lao Dnor");
            cymbol = Content.Load<SoundEffect>(@"Sounds/cymbalTing");
            snare = Content.Load<SoundEffect>(@"Sounds/snare");
            kick = Content.Load<SoundEffect>(@"Sounds/kick");
            top = Content.Load<SoundEffect>(@"Sounds/top");
            _font = Content.Load<SpriteFont>(@"Fonts/message");
            //_music = Content.Load<SoundEffect>(@"Songs/Acruta Lao Dnor");


            MediaPlayer.Play(BackingTrack);
            

            
            _mplayer = top.CreateInstance();
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here
            if (oldKeyState.IsKeyDown(Keys.P) && kstate.IsKeyUp(Keys.P))
            {
                if (MediaPlayer.State == MediaState.Playing)
                    MediaPlayer.Pause();
                else MediaPlayer.Resume();
            }

            if (oldKeyState.IsKeyDown(Keys.Subtract) && kstate.IsKeyUp(Keys.Subtract))
                if (MediaPlayer.Volume > 0.2f)
                    MediaPlayer.Volume -= 0.1f;

            if (oldKeyState.IsKeyDown(Keys.Add) && kstate.IsKeyUp(Keys.Add))
                if (MediaPlayer.Volume < 1f)
                    MediaPlayer.Volume += 0.1f;

            if (oldKeyState.IsKeyDown(Keys.S) && kstate.IsKeyUp(Keys.S))
            {
                snare.Play();
            }
                oldKeyState = kstate;

            base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(_font, MediaPlayer.Volume.ToString(), new Vector2(10,10), Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
