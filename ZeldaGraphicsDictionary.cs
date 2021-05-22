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
    public enum ZeldaGraphics
    {
        GreenRangerLogo = 0,
        SuperGoonLogo = 1,
        BasicUiSquare = 2,
        MainMenuBackground = 3,
        RightPointFingerCursor = 4,
        MainMouseCursor = 5
    }

    /// <summary>
    /// The actual content files that will be loaded when you choose to load a spritesheet
    /// </summary>
    public static class ZeldaGraphicsDictionary
    {
        public static Spritesheet[] GameGraphicsDictionary =
        {
            new Spritesheet("Graphics/Logos/KjbLogo"),
            new Spritesheet("Graphics/Logos/SggLogo"),
            new Spritesheet("Graphics/Ui/Core/BaseUi"),
            new Spritesheet("Graphics/Logos/MainMenuBackground"),
            new Spritesheet("Graphics/Ui/Core/singleFinger"),
            new Spritesheet("Graphics/Ui/Core/mouseCursor"),

        };

    }
}