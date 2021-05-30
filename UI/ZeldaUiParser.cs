////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

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

        /// <summary>
        /// Loads a Button controller.  This should be overridden, so that you can use game specific button controllers
        /// </summary>
        /// <param name="buttonControllerJson">The loaded json that should be used</param>
        /// <param name="parent">The parent for this guy</param>
        /// <returns>The guibuttonController that you want</returns>
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