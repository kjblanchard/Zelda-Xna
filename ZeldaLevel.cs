using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.BaseClasses;
using MultiplayerZelda.Stages;
using SgEngine.EKS;
using SgEngine.Interfaces;

namespace MultiplayerZelda
{
    class ZeldaLevel : IUpdate
    {
        private readonly ZeldaStageMachine _zeldaStageMachine;

        public ZeldaLevel()
        {
            _zeldaStageMachine = new ZeldaStageMachine();
        }
        
        public void Initialize()
        {
            _zeldaStageMachine.AddGameState(ZeldaStages.LogoScreens, new LogoScreenStage());
        }

        public void BeginRun()
        {
            _zeldaStageMachine.ChangeState(ZeldaStages.LogoScreens);
        }

        public void Update(GameTime gameTime)
        {
            _zeldaStageMachine.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _zeldaStageMachine.Draw(gameTime,spriteBatch);
        }

    }
}
