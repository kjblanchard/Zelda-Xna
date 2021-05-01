using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.BaseClasses;
using MultiplayerZelda.Utils.Enums;
using SgEngine.EKS;
using MonoGame.Extended.Tweening;

namespace MultiplayerZelda.Stages
{
    /// <summary>
    /// This is the Screen that shows all of our logos for the game
    /// </summary>
    /// <summary>
    /// Changes Opacity
    /// </summary>
    /// <param name="gameObjectToModify"></param>
    /// <param name="timeToWait"></param>
    public class LogoScreenStage : ZeldaStage
    {
        /// <summary>
        /// The kjb green ranger logo that should be shown
        /// </summary>
        private Logos _greenRangerLogo;
        private readonly Point _greenRangerSize = new Point(250, 500);
        private Logos _superGoonLogo;
        private readonly Point _superGoonLogoSize = new Point(600, 600);

        public override void Initialize()
        {
            base.Initialize();
            CreateLogos();
            AddLogosToGameObjectList();

        }

        private void CreateLogos()
        {
            _greenRangerLogo = new Logos(new Rectangle(GameWorld.WindowCenter, _greenRangerSize), ZeldaGraphics.GreenRangerLogo);
            _superGoonLogo = new Logos(new Rectangle(GameWorld.WindowCenter, _superGoonLogoSize), ZeldaGraphics.SuperGoonLogo);
            _greenRangerLogo.SpriteComponent.Opacity = 0;
            _superGoonLogo.SpriteComponent.Opacity = 0;
        }

        private void AddLogosToGameObjectList()
        {
            _gameObjectList.AddGameObject(_greenRangerLogo);
            _gameObjectList.AddGameObject(_superGoonLogo);
        }

        public override void BeginRun()
        {

            PlayBgm(ZeldaMusic.TitleTheme);
            StartLogoFadeIn();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        private void StartLogoFadeIn()
        {
            var greenRangerTween = new Tweener();
            greenRangerTween.TweenTo(_greenRangerLogo.SpriteComponent,
                opacity => _greenRangerLogo.SpriteComponent.Opacity, 1.0f, 3.0f, 2)
                .Easing(EasingFunctions.Linear)
                .OnEnd(tween =>
                {
                    _greenRangerLogo.TweeningComponent.TweenEnd(greenRangerTween);
                    GreenRangerFadeOut();
                });

            _greenRangerLogo.TweeningComponent.AddTween(greenRangerTween);
        }

        private void GreenRangerFadeOut()
        {
            var greenRangerTween = new Tweener();
            greenRangerTween.TweenTo(_greenRangerLogo.SpriteComponent,
                opacity => _greenRangerLogo.SpriteComponent.Opacity, 0.0f, 3.0f, 2)
                .Easing(EasingFunctions.Linear)
                .OnEnd(tween =>
                {
                    _greenRangerLogo.TweeningComponent.TweenEnd(greenRangerTween);
                    SuperGoonFadeIn();
                });
            _greenRangerLogo.TweeningComponent.AddTween(greenRangerTween);
        }

        private void SuperGoonFadeIn()
        {
            var superGoonTween = new Tweener();
            superGoonTween.TweenTo(_superGoonLogo.SpriteComponent, opacity => _superGoonLogo.SpriteComponent.Opacity, 1.0f, 3, 1.0f)
                .Easing(EasingFunctions.Linear)
                .OnEnd(tween =>
                {
                    _superGoonLogo.TweeningComponent.TweenEnd(superGoonTween);
                    SuperGoonFadeOut();
                })
                ;
            _superGoonLogo.TweeningComponent.AddTween(superGoonTween);
        }

        private void SuperGoonFadeOut()
        {
            var superGoonTween = new Tweener();
            superGoonTween.TweenTo(_superGoonLogo.SpriteComponent, opacity => _superGoonLogo.SpriteComponent.Opacity, 0.0f, 3, 2.0f)
                .Easing(EasingFunctions.Linear)
                .OnEnd(tween => _superGoonLogo.TweeningComponent.TweenEnd(superGoonTween))
                ;
            _superGoonLogo.TweeningComponent.AddTween(superGoonTween);
        }

    }
}
