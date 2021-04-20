////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

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
    #endregion

    #region Constructor

    public Logos(Rectangle locationAndSize, string spriteToLoad)
    {
        _spriteComponent = new SpriteComponent(this, spriteToLoad,new Rectangle(Point.Zero, locationAndSize.Size));
        _localPosition = locationAndSize.Location.ToVector2();
        AddComponent(_spriteComponent);
    }

    #endregion

    #region Functions

    public override void Initialize()
    {
        _spriteComponent.Initialize();
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _spriteComponent.Draw(gameTime,spriteBatch);
    }

    #endregion
    }

}