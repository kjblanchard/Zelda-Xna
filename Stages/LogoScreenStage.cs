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
            var greenRangerLogo =
                new Logos(
                    new Rectangle(GameWorld._baseConfig.Window.X / 2, GameWorld._baseConfig.Window.Y / 2, 250,
                        500), ZeldaGraphics.GreenRangerLogo);
            greenRangerLogo.AddTimer(new MultiPurposeTimer(2000, ReduceAlphaOverTime,greenRangerLogo,2.0f));
            _gameObjectList.AddGameObject(greenRangerLogo);
        }

        public override void BeginRun()
        {

            PlayBgm(ZeldaMusic.TitleTheme);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime,spriteBatch);
        }

        private void ReduceAlphaOverTime(GameObject gameObjectToModify, float timeToWait)
        {

            var spriteComponent = gameObjectToModify.GetComponent<SpriteComponent>(EngineComponentTypes.SpriteComponent);
            var tweenComponent = gameObjectToModify.GetComponent<TweeningComponent>(EngineComponentTypes.TweeningComponent);
            var tweener = new Tweener();
            tweener.TweenTo(spriteComponent, opacity => spriteComponent.Opacity, 0, timeToWait, 0)
                .Easing(EasingFunctions.Linear)
                .OnEnd(tween =>
                {
                    Debug.WriteLine("it's over");
                    tweenComponent.TweenEnd(tweener);
                });
            tweenComponent.AddTween(tweener);
        }

    }
}
