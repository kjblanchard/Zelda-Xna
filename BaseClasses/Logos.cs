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

        public SpriteComponent SpriteComponent;
        public TweeningComponent TweeningComponent;
        #endregion

        #region Constructor

        public Logos(Rectangle locationAndSize, Enum spriteToLoad)
        {
            SpriteComponent = new SpriteComponent(this, spriteToLoad, new Rectangle(Point.Zero, locationAndSize.Size));
            TweeningComponent = new TweeningComponent(this);
            _localPosition = locationAndSize.Location.ToVector2();
            AddComponent(SpriteComponent);
            AddComponent(TweeningComponent);
        }

        #endregion

        #region Functions

        public override void Initialize()
        {
            SpriteComponent.Initialize();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            SpriteComponent.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            TweeningComponent.Update(gameTime);
        }

        #endregion
    }

}