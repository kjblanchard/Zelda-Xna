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
            var borders = new GuiBorder {Top = 10, Right = 10, Bottom = 10, Left = 13};
            var oneLineTextSize = 11;
            var fontType = GuiTextComponent.FontTypes.ChronoTypeRegular;
            var mainMenuBackgroundPanel =
                new Panel(new Vector2(GameWorld.GameWorldSize.X / 2 - 20, GameWorld.GameWorldSize.Y / 2),
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


            mainMenuBackgroundPanel.AddTextObjectToPanel(mainMenuTitleText);

            var mainMenuGuiButtonController = new GuiButtonController(MainMenuUiPanel);
            var newGameTextButton = new TitleScreenMainMenuButton(newGameTextConfig, new Point(), new Vector2());
            newGameTextButton.AutoSetSizeBasedOnText();
            mainMenuGuiButtonController.AddButton(newGameTextButton);
            MainMenuUiPanel.AddUiObject(mainMenuGuiButtonController);



            var mainmenuContinueButton = new TitleScreenMainMenuButton(continueTextConfig, new Point(), new Vector2());
            mainmenuContinueButton.AutoSetSizeBasedOnText();
            mainMenuGuiButtonController.AddButton(mainmenuContinueButton);


            var optionsTextButton = new TitleScreenMainMenuButton(optionsTextBox, new Point(), new Vector2());
            mainmenuContinueButton.AutoSetSizeBasedOnText();
            mainMenuGuiButtonController.AddButton(optionsTextButton);

            var debugButton = new TitleScreenMainMenuButton(debugOptionsTextBox, new Point(), new Vector2());
            mainmenuContinueButton.AutoSetSizeBasedOnText();
            mainMenuGuiButtonController.AddButton(debugButton);

            mainMenuGuiButtonController.AllButtonDebugMode();
            GameWorld.Gui.MasterCanvas.AddPanel(mainMenuBackgroundPanel);
            GameWorld.Gui.MasterCanvas.AddPanel(MainMenuUiPanel);
        }

        private TitleScreenMainMenuButton CreateMenuButton(int multiplier)
        {

            var buttonSize = new Point(16, 16);
            var parentOffset = new Vector2(32, 32);
            var textConfig = new TextBoxConfig
            {
                alignment = GuiTextComponent.Alignment.Left,
                displayText = "Testing Out button",
                fontType = GuiTextComponent.FontTypes.ChronoTypeRegular,
                parent = this,
                parentOffset = new Vector2(16,16*multiplier),
                textBoxSize = new Point(70, 11),

            };
            var titleMenuButton = new TitleScreenMainMenuButton(textConfig, buttonSize, parentOffset,ZeldaGraphics.BasicUiSquare);
            titleMenuButton.AutoSetSizeBasedOnText();
            return titleMenuButton;
        }
    }
}