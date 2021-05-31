using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MultiplayerZelda.UI;
using SgEngine.Core;
using SgEngine.Core.Input;
using SgEngine.EKS;

namespace MultiplayerZelda
{
    /// <summary>
    /// The Zelda game world.  This holds the graphics, as well as others.  Inherits from the XNA gameworld class
    /// </summary>
    public class ZeldaGameWorld : GameWorld
    {
        public static ZeldaUiParser ZeldaUiParser => _instance._zeldaUiParser;
        private new static ZeldaGameWorld _instance;
        private readonly ZeldaLevel _zeldaLevel;
        private readonly ZeldaUiParser _zeldaUiParser;

        public ZeldaGameWorld()
        {
            _zeldaUiParser = new ZeldaUiParser();
            _zeldaLevel = new ZeldaLevel();
            _instance = this;
            InputSg.MouseDebugMode = true;

        }

        protected override void Initialize()
        {
            base.Initialize();
            _zeldaLevel.Initialize();
            _contentLoader = new ContentLoader(Content, ZeldaGraphicsDictionary.GameGraphicsDictionary,ZeldaFontDictionary.ZeldaFonts);
            SetupMouseCursor();
        }

        private void SetupMouseCursor()
        {
            
            InputSg.MouseSpriteSheet = ContentLoader.GetSpriteSheet(ZeldaGraphics.MainMouseCursor);
            Mouse.SetCursor(MouseCursor.FromTexture2D(InputSg.MouseSpriteSheet._texture, 0, 0));
        }


        protected override void BeginRun()
        {
            base.BeginRun();
            _zeldaLevel.BeginRun();
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
            _zeldaLevel.Update(gameTime);
            Gui.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {

            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null,
                _resolutionHelper.SpriteScale * MainCamera.GetCameraTransformMatrix());
            _zeldaLevel.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, _resolutionHelper.SpriteScale);
            Gui.Draw(gameTime, _spriteBatch);

            if(InputSg.MouseDebugMode)
                _spriteBatch.DrawRectangle(Controller.MouseBounds(),Color.White,0.5f);
            _spriteBatch.End();
        }
    }
}
