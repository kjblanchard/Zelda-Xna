using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.BaseClasses;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Components;
using SgEngine.Core;
using SgEngine.EKS;
using MonoGame.Extended.Tweening;
using SgEngine.Core.Input;

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
        private readonly PlayerController _playerController = new PlayerController();

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
            _greenRangerLogo.AddTimer(new MultiPurposeTimer(2000, DisplayLogos, _greenRangerLogo, 2.0f));
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
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (_playerController.IsButtonPressed(ControllerButtons.A))
            {
                Debug.WriteLine("button is pressed" + System.DateTime.Now);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        /// <summary>
        /// Changes Opacity
        /// </summary>
        /// <param name="gameObjectToModify"></param>
        /// <param name="timeToWait"></param>
        private void DisplayLogos(GameObject gameObjectToModify, float timeToWait)
        {

            var tweener = new Tweener();
            tweener.TweenTo(_greenRangerLogo.SpriteComponent, opacity => _greenRangerLogo.SpriteComponent.Opacity, 0, timeToWait, 0)
                .Easing(EasingFunctions.Linear)
                .OnEnd(tween =>
                {
                    _greenRangerLogo.TweeningComponent.TweenEnd(tweener);
                    var sgTweener = new Tweener();
                    sgTweener.TweenTo(_superGoonLogo.SpriteComponent, opacity => _superGoonLogo.SpriteComponent.Opacity, 1.0f, 4 ,2.0f)
                        .Easing(EasingFunctions.SineOut)
                        .AutoReverse()
                        .OnEnd(sgTween =>
                        {
                            _superGoonLogo.TweeningComponent.TweenEnd(sgTweener);
                        })
                        ;
                    _superGoonLogo.TweeningComponent.AddTween(sgTweener);
                });
            _superGoonLogo.TweeningComponent.AddTween(tweener);
        }

    }
}
