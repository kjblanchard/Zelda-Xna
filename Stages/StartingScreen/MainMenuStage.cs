////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using MultiplayerZelda.UI.TitleScreen;
using MultiplayerZelda.Utils.Enums;

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

        public override void BeginRun()
        {
            base.BeginRun();
            PlayBgm(ZeldaMusic.MenuTheme);

        }


        public override void Update(GameTime gameTime)
        {


        }
    }
}