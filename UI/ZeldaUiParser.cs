////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System;
using Microsoft.Xna.Framework;
using MultiplayerZelda.UI.TitleScreen;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;
using SgEngine.Models.Ui;
using SgEngine.SgJson.Parsing;

namespace MultiplayerZelda.UI
{
    public class ZeldaUiParser : UiParser
    {

        /// <summary>
        /// To load guibuttons, this needs to be overridden
        /// </summary>
        /// <param name="buttonModel"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public override GuiButton CreateButton(Button buttonModel, GuiComponent parent)
        {
            var buttonOffset = new Vector2(buttonModel.Location.X, buttonModel.Location.Y);
            var buttonSize = new Point(buttonModel.Size.X, buttonModel.Size.Y);

            var textConfig = PopulateTextConfig(buttonModel.TextComponent, parent);

            return buttonModel.Type switch
            {
                0 => new TitleScreenMainMenuButton(textConfig, buttonSize, buttonOffset, parent, buttonModel.Graphic),
                _ => null
            };
        }

        public override GuiButtonController CreateButtonController(ButtonController buttonControllerJson, GuiComponent parent)
        {
            return buttonControllerJson.Type switch
            {
                0 => new MainMenuGuiButtonController(parent),
                _ => null
            };
        }
    }
}