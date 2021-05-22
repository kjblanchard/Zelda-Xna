////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class TitleScreenMainMenuButton : GuiButton
    {
        public TitleScreenMainMenuButton(TextBoxConfig textBoxConfig, Point size, Vector2 parentOffset, GuiComponent parent = null, Enum graphicToLoad = null) : base(size, parentOffset, parent,textBoxConfig )
        {
            DebugMode = true;
        }


        protected override void OnSelected()
        {
            base.OnSelected();
            _buttonTextComponent.TextColor = Color.LightBlue;
        }

        protected override void OnDeselected()
        {
            base.OnDeselected();
            _buttonTextComponent.TextColor = Color.White;
        }

        public override void OnClick()
        {
            base.OnClick();
            Debug.Write("This boi was just clicked " + _buttonTextComponent.DisplayText);
        }

    }
}