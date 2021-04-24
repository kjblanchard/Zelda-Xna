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

    }

    public static class ZeldaGraphicsDictionary
    {
        public static Spritesheet[] GameGraphicsDictionary =
        {
            new Spritesheet("Graphics/Logos/KjbLogo"),
        };

    }
}