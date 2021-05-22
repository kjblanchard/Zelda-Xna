////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using SgEngine.Core;

namespace MultiplayerZelda
{


    /// <summary>
    /// All of the spritesheets that can be loaded into the game.  Corresponds to the dictionary below line for line
    /// </summary>
    public enum ZeldaFonts
    {
        ChronoRegular = 0,
    }

    /// <summary>
    /// The actual content files that will be loaded when you choose to load a spritesheet
    /// </summary>
    public static class ZeldaFontDictionary
    {
        public static FontSheet[] ZeldaFonts =
        {
            new FontSheet("Fonts/ChronoType",11)
        };

    }
}