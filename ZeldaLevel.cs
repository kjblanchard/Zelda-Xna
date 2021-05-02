using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.BaseClasses;
using MultiplayerZelda.Stages;
using MultiplayerZelda.Stages.StartingScreen;
using SgEngine.EKS;

namespace MultiplayerZelda
{
    public class ZeldaLevel : GameLevel
    {
        private static ZeldaStageMachine _zeldaStageMachine;

        public ZeldaLevel()
        {
            _zeldaStageMachine = new ZeldaStageMachine();
        }
        
        public void Initialize()
        {
            _zeldaStageMachine.AddGameState(ZeldaStages.LogoScreens, new LogoScreenStage());
            _zeldaStageMachine.AddGameState(ZeldaStages.MainMenuStage,new MainMenuStage());
        }

        public void LoadContent()
        {
            throw new NotImplementedException();
        }

        public void BeginRun()
        {
            _zeldaStageMachine.ChangeState(ZeldaStages.LogoScreens);
        }

        public void Update(GameTime gameTime)
        {
            _zeldaStageMachine.Update(gameTime);
        }

        public void HandleInput()
        {
            throw new NotImplementedException();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _zeldaStageMachine.Draw(gameTime,spriteBatch);
        }

        public void OnActivate()
        {
            throw new NotImplementedException();
        }

        public void OnDeactivate()
        {
            throw new NotImplementedException();
        }

        public static void ChangeZeldaStage(ZeldaStages stageToChangeTo)
        {
            _zeldaStageMachine.ChangeState(stageToChangeTo);
        }
    }
}
