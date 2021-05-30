using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultiplayerZelda.BaseClasses;
using MultiplayerZelda.Utils.Enums;
using SgEngine.EKS;
using SgEngine.Interfaces;
using SgEngine.Interfaces.Sound;

namespace MultiplayerZelda.Stages
{
    /// <summary>
    /// The base class for all zelda stages.  Gives you some default methods and a sound system
    /// it's also a IState, and controlled by a statemachine
    /// </summary>
    public class ZeldaStage : IState, IPlayMusic
    {
        protected GameObjectList<Logos> _gameObjectList = new GameObjectList<Logos>();
        protected IPlayMusic AsIPlayMusic => this;

        public ZeldaStage()
        {

        }
        public virtual void Initialize()
        {
            _gameObjectList.Initialize();
        }

        public virtual void LoadContent()
        {
        }

        public virtual void BeginRun()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            _gameObjectList.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _gameObjectList.Draw(gameTime,spriteBatch);
        }

        public virtual void End()
        {
        }

        /// <summary>
        /// Plays a Bgm
        /// </summary>
        /// <param name="bgmToPlay">This is the music that should be played</param>
        protected void PlayBgm(ZeldaMusic bgmToPlay)
        {
            AsIPlayMusic.PlayMusic(bgmToPlay);
        }
    }
}
