////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SgEngine.Core.Input;
using SgEngine.EKS;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class TitleScreenMainMenuButton : GuiButton
    {
        public TitleScreenMainMenuButton(TextBoxConfig textBoxConfig, Point size, Vector2 parentOffset, Enum graphicToLoad = null) : base(textBoxConfig, size, parentOffset, graphicToLoad)
        {
        }

        public override void OnSelected()
        {
            base.OnSelected();
            _guiTextComponent.TextColor = Color.LightBlue;
        }

        public override void OnDeselected()
        {
            base.OnDeselected();
            _guiTextComponent.TextColor = Color.White;
        }

        public override void OnClick()
        {
            base.OnClick();
            Debug.Write("This boi was just clicked" + _textBoxConfig.displayText + "\n");
        }

    }
}