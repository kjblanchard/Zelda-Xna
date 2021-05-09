using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SgEngine.Core;
using SgEngine.EKS;

namespace MultiplayerZelda
{
    /// <summary>
    /// The Zelda game world.  This holds the graphics, as well as others.  Inherits from the XNA gameworld class
    /// </summary>
    public class ZeldaGameWorld : GameWorld
    {
        private ZeldaLevel _zeldaLevel;

        public ZeldaGameWorld()
        {
            _zeldaLevel = new ZeldaLevel();

        }

        protected override void Initialize()
        {
            base.Initialize();
            _zeldaLevel.Initialize();
            _contentLoader = new ContentLoader(Content, ZeldaGraphicsDictionary.GameGraphicsDictionary);
            Gui.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Gui.LoadContent();

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
            //_spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,null,null,null,null,_resolutionHelper.SpriteScale);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,null,null,null,null,_resolutionHelper.SpriteScale * MainCamera.GetCameraTransformMatrix());
            _zeldaLevel.Draw(gameTime, _spriteBatch);
            Gui.Draw(gameTime,_spriteBatch);
            _spriteBatch.End();
            _zeldaLevel.Initialize();
        }
    }
}
