////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Core.Sounds;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;
using SgEngine.Interfaces;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class TitleScreenMainMenuButton : GuiButton
    {
        public TitleScreenMainMenuButton(TextBoxConfig textBoxConfig, Point size, Vector2 parentOffset, GuiComponent parent, int graphicToLoad) : base(size, parentOffset, parent,textBoxConfig )
        {
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