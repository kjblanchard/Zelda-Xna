using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using FMOD.Studio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Core;
using SgEngine.Core.Sounds;

namespace MultiplayerZelda
{
    public class ZeldaGame : ExtendedGame
    {

        public ZeldaGame()
        {


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void BeginRun()
        {
            base.BeginRun();
            SoundSystem.PlayBgm(ZeldaMusic.TitleTheme);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);

        }
        

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);

        }
    }
}
