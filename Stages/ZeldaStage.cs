using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Core.Sounds;
using SgEngine.EKS;
using SgEngine.Interfaces;

namespace MultiplayerZelda.Stages
{
    /// <summary>
    /// The base class for all zelda stages.  Gives you some default methods and a sound system
    /// </summary>
    public class ZeldaStage : IState
    {
        private static SoundSystem _soundSystem;

        public ZeldaStage()
        {
            _soundSystem ??= GameWorld.SoundSystem;
        }
        public virtual void Initialize()
        {

        }

        public virtual void LoadContent()
        {
        }

        public virtual void BeginRun()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        /// <summary>
        /// Plays a Bgm
        /// </summary>
        /// <param name="bgmToPlay">This is the music that should be played</param>
        protected void PlayBgm(ZeldaMusic bgmToPlay)
        {
            _soundSystem.PlayBgm(bgmToPlay);
        }
    }
}
