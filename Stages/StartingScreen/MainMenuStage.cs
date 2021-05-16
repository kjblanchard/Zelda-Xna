////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using MultiplayerZelda.UI.TitleScreen;

namespace MultiplayerZelda.Stages.StartingScreen
{
    public class MainMenuStage : ZeldaStage
    {
        private TitleMenuPanel titelPanel;
        public override void Initialize()
        {
            base.Initialize();
            titelPanel = new TitleMenuPanel();
            titelPanel.Initialize();
        }
        

        public override void Update(GameTime gameTime)
        {


        }
    }
}