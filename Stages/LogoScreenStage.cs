using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.BaseClasses;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Components;
using SgEngine.Core;
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

        private SingleFunctionTimer _testingTimers;
        private TweenTimer _testingTweenTimer;
        private SingleFunctionTimer _testingMoveTimer;

        public override void Initialize()
        {
            base.Initialize();
            _greenRangerLogo = new Logos(new Rectangle(0, 0, 250, 250), "Graphics/Logos/KjbLogo");
            _greenRangerLogo.Initialize();
            _testingTimers = new SingleFunctionTimer(2000, AlphaLogoTest);
        }

        public override void BeginRun()
        {

            PlayBgm(ZeldaMusic.TitleTheme);
        }

        public override void Update(GameTime gameTime)
        {
            _testingTimers.Update(gameTime);
            _testingTweenTimer?.Update(gameTime);
            _testingMoveTimer?.Update(gameTime);
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
            _testingTweenTimer = new TweenTimer(convertedComp.Opacity, 0, 100, ReduceAlphaOverTime, MoveLogoAfterTime);
        }

        private void MoveLogoAfterTime()
        {

            _testingMoveTimer = new SingleFunctionTimer(100, MoveLogo);
        }

        private void ReduceAlphaOverTime(float valueToUpdate)
        {
            var component = _greenRangerLogo.GetComponent(EngineComponentTypes.SpriteComponent);
            var convertedComp = (SpriteComponent)(component);
            convertedComp.Opacity = valueToUpdate;
        }
    }
}
