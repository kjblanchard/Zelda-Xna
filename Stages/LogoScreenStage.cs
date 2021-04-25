using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.BaseClasses;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Components;
using SgEngine.Core;
using SgEngine.EKS;
using MonoGame.Extended.Tweening;

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
        //private Logos _greenRangerLogo;
        public override void Initialize()
        {
            base.Initialize();
            var _greenRangerLogo =
                new Logos(
                    new Rectangle(ZeldaGameWorld._baseConfig.Window.X / 2, ZeldaGameWorld._baseConfig.Window.Y / 2, 250,
                        500), ZeldaGraphics.GreenRangerLogo);
            _greenRangerLogo.AddTimer(new SingleFunctionTimer(2000,_greenRangerLogo, AlphaLogoTest));
            _gameObjectList.AddGameObject(_greenRangerLogo);
        }

        public override void BeginRun()
        {

            PlayBgm(ZeldaMusic.TitleTheme);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void LoadContent()
        {


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime,spriteBatch);
        }
        private void MoveLogo(Logos logoToModify)
        {

            var component = logoToModify.GetComponent(EngineComponentTypes.SpriteComponent);
            var convertedComp = (SpriteComponent)(component);
            convertedComp.Opacity = 1f;
            logoToModify.LocalPosition = Vector2.Add(logoToModify.LocalPosition, new Vector2(50, 0));
        }

        private void AlphaLogoTest(GameObject gameObjectToModify)
        {

            var component = gameObjectToModify.GetComponent(EngineComponentTypes.SpriteComponent);
            var convertedComp = (SpriteComponent)(component);
            var tweenComponent = gameObjectToModify.GetComponent(EngineComponentTypes.TweeningComponent);
            var convertedTween = (TweeningComponent) (tweenComponent);
            var tweener = new Tweener();
            tweener.TweenTo(convertedComp, opacity => convertedComp.Opacity, 0, 3, 0)
                .Easing(EasingFunctions.Linear)
                .OnEnd(tween =>
                {
                    Debug.WriteLine("it's over");
                    convertedTween.TweenEnd(tweener);
                });
            convertedTween.AddTween(tweener);
            //logoToModify.AddTimer(new TweenTimer<Logos>(convertedComp.Opacity, 0, 1000, ReduceAlphaOverTime, MoveLogoAfterTime));
        }

        private void MoveLogoAfterTime(Logos logoToModify)
        {

            //logoToModify.AddTimer(new SingleFunctionTimer(100, MoveLogo(logoToModify)));
        }

        private void ReduceAlphaOverTime(Logos logoToModify, float valueToUpdate)
        {
            var component = logoToModify.GetComponent(EngineComponentTypes.SpriteComponent);
            var convertedComp = (SpriteComponent)(component);
            convertedComp.Opacity = valueToUpdate;
        }
    }
}
