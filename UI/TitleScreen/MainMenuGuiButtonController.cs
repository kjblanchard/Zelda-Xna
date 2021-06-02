////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda 
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using MultiplayerZelda.Utils.Enums;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;
using SgEngine.Interfaces;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class MAIN_MENU_GUI_BUTTON_CONTROLLER : GuiButtonController
    {
        public MAIN_MENU_GUI_BUTTON_CONTROLLER(GuiComponent parent, Vector2 offset = new Vector2(), Point size = new Point()) : base(parent, offset, size)
        {
            CursorGuiImageComponent =
                new GuiImageComponent(this, ZeldaGraphics.RightPointFingerCursor, new Point(16, 16))
                {
                    LocationOverride = true,
                    IsVisible = false
                };
            _moveSoundEffect = _selectSoundEffect = ZeldaSfx.CursorMove;
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