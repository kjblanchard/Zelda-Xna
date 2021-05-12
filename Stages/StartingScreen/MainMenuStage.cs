////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using SgEngine.EKS;
using SgEngine.GUI;
using SgEngine.GUI.Components;
using SgEngine.GUI.Utils;

namespace MultiplayerZelda.Stages.StartingScreen
{
    public class MainMenuStage : ZeldaStage
    {
        public override void Initialize()
        {
            base.Initialize();
            var _mainMenuBoxSize = new Point(90, 90);
            var _mainMenuBoxLocation = new Vector2(200, 100);
            var spaceBetweenTextBoxes = 20;
            var borders = new GuiBorder {Top = 10, Right = 10, Bottom = 10, Left = 10};

            var MainMenuUiPanel = new Panel(_mainMenuBoxLocation, _mainMenuBoxSize, ZeldaGraphics.BasicUiSquare);
            TextBoxConfig newGameTextConfig = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "New Game",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders, borders),
                textBoxSize = new Point(_mainMenuBoxSize.X -=  borders*2, 10),
            };
            TextBoxConfig continueTextConfig = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "Continue",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders, borders + spaceBetweenTextBoxes),
                textBoxSize = new Point(80, 10),
            };
            TextBoxConfig optionsTextBox = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "Options",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders, borders + spaceBetweenTextBoxes * 2),
                textBoxSize = new Point(80, 10),
            };
            TextBoxConfig debugOptionsTextBox = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "Debug Mode",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders, borders + spaceBetweenTextBoxes * 3),
                textBoxSize = new Point(80, 10),
            };
            var NewGameText = new GuiTextComponent(newGameTextConfig);
            var ContinueGameText = new GuiTextComponent(continueTextConfig);
            var OptionsText = new GuiTextComponent(optionsTextBox);
            var DebugText = new GuiTextComponent(debugOptionsTextBox);
            MainMenuUiPanel.AddUiObject(NewGameText);
            MainMenuUiPanel.AddUiObject(ContinueGameText);
            MainMenuUiPanel.AddUiObject(OptionsText);
            MainMenuUiPanel.AddUiObject(DebugText);
            MainMenuUiPanel.ModifyDebugForPanel(true);
            GameWorld.Gui.MasterCanvas.AddPanel(MainMenuUiPanel);
        }

        public override void Update(GameTime gameTime)
        {


        }
    }
}