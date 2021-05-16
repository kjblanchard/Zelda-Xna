////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SgEngine.Core.Input;
using SgEngine.EKS;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class TitleMenuButton1 : GuiButton
    {
        private PlayerController currentPlayerController = GameWorld.GetPlayerController(0);
        
        public TitleMenuButton1(TextBoxConfig textBoxConfig, Point size, Vector2 parentOffset, Enum graphicToLoad = null) : base(textBoxConfig, size, parentOffset, graphicToLoad)
        {
        }

        public override void OnHover()
        {
            base.OnHover();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _guiTextComponent.TextColor = _isHovered ? Color.Blue : Color.White;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            _guiTextComponent.Draw(gameTime,spriteBatch);
        }
    }
}