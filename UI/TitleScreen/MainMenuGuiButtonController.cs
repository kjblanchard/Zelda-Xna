////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda 
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class MainMenuGuiButtonController : GuiButtonController
    {
        public MainMenuGuiButtonController(GuiComponent parent, Vector2 offset = new Vector2(), Point size = new Point()) : base(parent, offset, size)
        {
            CursorGuiImageComponent =
                new GuiImageComponent(this, ZeldaGraphics.RightPointFingerCursor, new Point(16, 16))
                {
                    LocationOverride = true,
                    IsVisible = false
                };
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            CursorGuiImageComponent.LocalPosition = UpdateCursorPosition();
        }
        private Vector2 UpdateCursorPosition()
        {
            var tempLocation = ButtonsToManage[CurrentSelection].GlobalPosition;
            tempLocation -= _parent.Origin;
            tempLocation.X -= 10;
            tempLocation.Y += ButtonsToManage[CurrentSelection].Size.Y / 2;
            return tempLocation;
        }
    }
}