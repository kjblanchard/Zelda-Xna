using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.BaseClasses;
using System.Diagnostics;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Core;
using SgEngine.Interfaces;

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

        private Timer _testingTimers;
        public LogoScreenStage() : base()
        {
            
        }

        private void testFunc()
        {
            var temploc = _greenRangerLogo.LocalPosition;
            temploc.X += 5;
            _greenRangerLogo.LocalPosition = temploc;
        }
        public override void Initialize()
        {
            base.Initialize();
            Debug.WriteLine("going to the store");
            
            _greenRangerLogo = new Logos(new Rectangle(0, 0, 250, 250), "Graphics/Logos/KjbLogo");
            _greenRangerLogo.Initialize();
            PlayBgm(ZeldaMusic.TitleTheme);
            _testingTimers = new Timer(7000, testFunc);
        }

        public override void Update(GameTime gameTime)
        {
            _testingTimers.Update(gameTime);
        }

        public override void LoadContent()
        {


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _greenRangerLogo.Draw(gameTime, spriteBatch);
        }

    }
}
