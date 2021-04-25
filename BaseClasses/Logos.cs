////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SgEngine.Components;
using SgEngine.EKS;

namespace MultiplayerZelda.BaseClasses
{
    public class Logos : GameObject
    {

        #region State

        private SpriteComponent _spriteComponent;
        private TweeningComponent _tweeningComponent;
        #endregion

        #region Constructor

        public Logos(Rectangle locationAndSize, Enum spriteToLoad)
        {
            _spriteComponent = new SpriteComponent(this, spriteToLoad, new Rectangle(Point.Zero, locationAndSize.Size));
            _tweeningComponent = new TweeningComponent(this);
            _localPosition = locationAndSize.Location.ToVector2();
            AddComponent(_spriteComponent);
            AddComponent(_tweeningComponent);
        }

        #endregion

        #region Functions

        public override void Initialize()
        {
            _spriteComponent.Initialize();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteComponent.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _tweeningComponent.Update(gameTime);
        }

        #endregion
    }

}