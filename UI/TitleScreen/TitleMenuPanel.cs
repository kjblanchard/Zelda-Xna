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
using SgEngine.GUI.Types;
using SgEngine.GUI.Utils;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class TitleMenuPanel : Panel
    {
        public override void Initialize()
        {
            base.Initialize();

            var mainMenuBoxSize = new Point(90, 90);
            var mainMenuBoxLocation = new Vector2(300, 150);
            var spaceBetweenTextBoxes = 20;
            var borders = new GuiBorder { Top = 10, Right = 10, Bottom = 10, Left = 13 };
            var oneLineTextSize = 11;
            var fontType = GuiTextComponent.FontTypes.ChronoTypeRegular;
            var buttonSize = new Point(mainMenuBoxSize.X - borders.Left - borders.Right, oneLineTextSize);

            var mainMenuBackgroundPanel = new Panel(new Vector2(GameWorld.GameWorldSize.X / 2 - 20, GameWorld.GameWorldSize.Y / 2),
                GameWorld.GameWorldSize, ZeldaGraphics.MainMenuBackground);
            TextBoxConfig mainMenuTitleText = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Center,
                displayText = "Welcome to our Zelda Maker / Multiplayer!",
                fontType = fontType,
                parent = mainMenuBackgroundPanel,
                parentOffset = new Vector2(20, 10),
                textBoxSize = new Point(mainMenuBackgroundPanel.Size.X, oneLineTextSize)

            };
            mainMenuBackgroundPanel.AddUiObject(new GuiTextComponent(mainMenuTitleText));

            
            
            var MainMenuUiPanel = new Panel(mainMenuBoxLocation, mainMenuBoxSize, ZeldaGraphics.BasicUiSquare);

            TextBoxConfig newGameTextConfig = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "New Game",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders.Left, borders.Top),
                textBoxSize = new Point(mainMenuBoxSize.X - (borders.Left + borders.Right), oneLineTextSize),
            };
            TextBoxConfig continueTextConfig = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "Continue",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders.Left, (borders.Top + spaceBetweenTextBoxes)),
                textBoxSize = new Point(mainMenuBoxSize.X - (borders.Left + borders.Right), oneLineTextSize)
            };
            TextBoxConfig optionsTextBox = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "Options",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders.Left, borders.Top + spaceBetweenTextBoxes * 2),
                textBoxSize = new Point(mainMenuBoxSize.X - (borders.Left + borders.Right), oneLineTextSize),
            };
            TextBoxConfig debugOptionsTextBox = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "Debug Mode",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = MainMenuUiPanel,
                parentOffset = new Vector2(borders.Left, borders.Top + spaceBetweenTextBoxes * 3),
                textBoxSize = new Point(mainMenuBoxSize.X - (borders.Left + borders.Right), oneLineTextSize),
            };


            var mainMenuGuiButtonController = new MainMenuGuiButtonController(MainMenuUiPanel);
            MainMenuUiPanel.AddUiObject(mainMenuGuiButtonController);

             CreateMainMenuButtonForMainMenuUi(newGameTextConfig, buttonSize, MainMenuUiPanel,mainMenuGuiButtonController);
            
                CreateMainMenuButtonForMainMenuUi(continueTextConfig, buttonSize, MainMenuUiPanel,mainMenuGuiButtonController);
            CreateMainMenuButtonForMainMenuUi(optionsTextBox, buttonSize, MainMenuUiPanel,mainMenuGuiButtonController);
            CreateMainMenuButtonForMainMenuUi(debugOptionsTextBox, buttonSize, MainMenuUiPanel,mainMenuGuiButtonController);

            GameWorld.Gui.MasterCanvas.AddPanel(mainMenuBackgroundPanel);
            GameWorld.Gui.MasterCanvas.AddPanel(MainMenuUiPanel);

            mainMenuGuiButtonController.ButtonsActive = true;
        }


        private void CreateMainMenuButtonForMainMenuUi(TextBoxConfig textConfigForButton, Point buttonSize, GuiComponent buttonParent, GuiButtonController buttonControllerToaddTo)
        {
            var newButton = new TitleScreenMainMenuButton(textConfigForButton, buttonSize, textConfigForButton.parentOffset,
                buttonParent);
            buttonControllerToaddTo.AddButton(newButton);
            //newButton.AutoSetSizeBasedOnText();
        }

    }
}