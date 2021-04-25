using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.BaseClasses;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Components;
using SgEngine.Core;
using SgEngine.Models;

namespace MultiplayerZelda.Stages
{
    /// <summary>
    /// This is the Screen that shows all of our logos for the game
    /// </summary>
    public class LogoScreenStage : ZeldaStage
    {
        /// <summary>
        /// The kjb green ranger logo that should be shown
        /// </summary>
        private Logos _greenRangerLogo;
        public override void Initialize()
        {
            base.Initialize();
            _greenRangerLogo =
                new Logos(
                    new Rectangle(ZeldaGameWorld._baseConfig.Window.X / 2, ZeldaGameWorld._baseConfig.Window.Y / 2, 250,
                        500), ZeldaGraphics.GreenRangerLogo);
            _greenRangerLogo.Initialize();
            _greenRangerLogo.AddTimer(new SingleFunctionTimer(2000, AlphaLogoTest));
        }

        public override void BeginRun()
        {

            PlayBgm(ZeldaMusic.TitleTheme);
        }

        public override void Update(GameTime gameTime)
        {
            _greenRangerLogo.Update(gameTime);
        }

        public override void LoadContent()
        {


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _greenRangerLogo.Draw(gameTime, spriteBatch);
        }
        private void MoveLogo()
        {

            var component = _greenRangerLogo.GetComponent(EngineComponentTypes.SpriteComponent);
            var convertedComp = (SpriteComponent)(component);
            convertedComp.Opacity = 1f;
            _greenRangerLogo.LocalPosition = Vector2.Add(_greenRangerLogo.LocalPosition, new Vector2(50, 0));
        }

        private void AlphaLogoTest()
        {

            var component = _greenRangerLogo.GetComponent(EngineComponentTypes.SpriteComponent);
            var convertedComp = (SpriteComponent)(component);
            _greenRangerLogo.AddTimer(new TweenTimer(convertedComp.Opacity, 0, 1000, ReduceAlphaOverTime, MoveLogoAfterTime));
        }

        private void MoveLogoAfterTime()
        {

            _greenRangerLogo.AddTimer(new SingleFunctionTimer(100, MoveLogo));
        }

        private void ReduceAlphaOverTime(float valueToUpdate)
        {
            var component = _greenRangerLogo.GetComponent(EngineComponentTypes.SpriteComponent);
            var convertedComp = (SpriteComponent)(component);
            convertedComp.Opacity = valueToUpdate;
        }
    }
}
