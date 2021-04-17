using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.Stages;
using SgEngine.State;

namespace MultiplayerZelda.BaseClasses
{
    class ZeldaStageMachine : StateMachine<ZeldaStage>
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
