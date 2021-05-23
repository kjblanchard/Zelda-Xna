////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SgEngine.EKS;
using SgEngine.GUI;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;
using SgEngine.GUI.Utils;
using SgEngine.SgJson;
using SgEngine.SgJson.Parsing;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class TitleMenuPanel : Panel
    {
        private List<Panel> TotalPanels = new List<Panel>();
        public override void Initialize()
        {
            base.Initialize();
            var screenJson = ZeldaGameWorld.ZeldaUiParser.LoadUiScreenJson("MainTitleScreenUi");
            var screenPanels = ZeldaGameWorld.ZeldaUiParser.ParsePanelsFromJson(screenJson);
            foreach (var panel in screenPanels)
            {
                TotalPanels.Add(panel);
                GameWorld.Gui.MasterCanvas.AddPanel(panel);
                
            }

        }

    }
}