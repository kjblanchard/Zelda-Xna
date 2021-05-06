////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System.Diagnostics;
using Microsoft.Xna.Framework;
using MultiplayerZelda.BaseClasses;
using SgEngine.Collision;
using SgEngine.Core.Input;
using SgEngine.EKS;
using SgEngine.UI;

namespace MultiplayerZelda.Stages.StartingScreen
{
    public class MainMenuStage : ZeldaStage
    {
        public override void Initialize()
        {
            base.Initialize();
            var MainMenuUiPanel = new Panel();
            var UiIcon = new UiImage(ZeldaGraphics.BasicUiSquare, new Point(128, 128), new Vector2(100, 100));
            MainMenuUiPanel.AddUiObject(UiIcon);
            GameWorld.Ui.MasterCanvas.AddPanel(MainMenuUiPanel);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}