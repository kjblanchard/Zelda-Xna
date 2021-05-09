////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using SgEngine.EKS;
using SgEngine.GUI;

namespace MultiplayerZelda.Stages.StartingScreen
{
    public class MainMenuStage : ZeldaStage
    {
        public override void Initialize()
        {
            base.Initialize();
            var MainMenuUiPanel = new Panel();
            var UiIcon = new GuiUiImage(ZeldaGraphics.BasicUiSquare, new Point(128, 128), new Vector2(100, 100));
            MainMenuUiPanel.AddUiObject(UiIcon);
            GameWorld.Gui.MasterCanvas.AddPanel(MainMenuUiPanel);
        }

        public override void Update(GameTime gameTime)
        {
            

        }
    }
}