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

namespace MultiplayerZelda.Stages.StartingScreen
{
    public class MainMenuStage : ZeldaStage
    {
        public override void Initialize()
        {
            base.Initialize();
            var spaceBetweenTextBoxes = 20;
            var borders = 8;
            var MainMenuUiPanel = new Panel(new Vector2(200, 100), new Point(100, 100), ZeldaGraphics.BasicUiSquare);
            TextBoxConfig newGameTextConfig = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "New Game",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders,borders),
                textBoxSize = new Point(80,10)
            };
            TextBoxConfig continueTextConfig = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "Continue",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders,borders+spaceBetweenTextBoxes),
                textBoxSize = new Point(80,10)
            };
            TextBoxConfig optionsTextBox = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "Options",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders,borders+spaceBetweenTextBoxes*2),
                textBoxSize = new Point(80,10)
            };
            var NewGameText = new GuiTextComponent(newGameTextConfig);
            var ContinueGameText = new GuiTextComponent(continueTextConfig);
            var OptionsText = new GuiTextComponent(optionsTextBox);
            MainMenuUiPanel.AddUiObject(NewGameText);
            MainMenuUiPanel.AddUiObject(ContinueGameText);
            MainMenuUiPanel.AddUiObject(OptionsText);
            GameWorld.Gui.MasterCanvas.AddPanel(MainMenuUiPanel);
        }

        public override void Update(GameTime gameTime)
        {


        }
    }
}