////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Xna.Framework;
using SgEngine.Core;

namespace MultiplayerZelda
{
    public enum ZeldaGraphics
    {
        GreenRangerLogo = 0,
        SuperGoonLogo = 1,
        BasicUiSquare = 2


    }

    public static class ZeldaGraphicsDictionary
    {
        public static Spritesheet[] GameGraphicsDictionary =
        {
            new Spritesheet("Graphics/Logos/KjbLogo"),
            new Spritesheet("Graphics/Logos/SggLogo"),
            new Spritesheet("Graphics/Ui/Core/BaseUi")
        };

    }
}