using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.Stages;
using SgEngine.State;

namespace MultiplayerZelda.BaseClasses
{
    /// <summary>
    /// The zelda stagemachine, not sure yet why I have it existing, probably so that things can get from it without specifying the type param.
    /// </summary>
    class ZeldaStageMachine : StateMachine<ZeldaStage>
    {
    }
}
