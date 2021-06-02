////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda 
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Core.Input;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;
using SgEngine.Interfaces.Input;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class MainMenuGuiButtonController : GuiButtonController,ISubscribeToButton.IHandleAButtonPressed, ISubscribeToButton.IHandleUpButtonPressed, ISubscribeToButton.IHandleDownButtonPressed
    {
        public MainMenuGuiButtonController(GuiComponent parent, Vector2 offset = new Vector2(), Point size = new Point()) : base(parent, offset, size)
        {
            CursorGuiImageComponent =
                new GuiImageComponent(this, ZeldaGraphics.RightPointFingerCursor, new Point(16, 16))
                {
                    LocationOverride = true,
                    IsVisible = false
                };
            _moveSoundEffect = _selectSoundEffect = ZeldaSfx.CursorMove;
        }

        public override void Initialize()
        {
            base.Initialize();
            SubScribeToButtons();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            CursorGuiImageComponent.LocalPosition = UpdateFingerCursorIcon();
        }
        /// <summary>
        /// Updates the cursor icon to the correct place on the screen
        /// </summary>
        /// <returns></returns>
        private Vector2 UpdateFingerCursorIcon()
        {
            var tempLocation = ButtonsToManage[CurrentSelection].GlobalPosition;
            tempLocation -= _parent.Origin;
            tempLocation.X -= 10;
            tempLocation.Y += ButtonsToManage[CurrentSelection].Size.Y / 2;
            return tempLocation;
        }
        public void AButtonEventHandler(object sender, ControllerButtons buttonPressed, ButtonActions actionPerformed)
        {
            PressButton(CurrentSelection);
        }

        public void UpButtonEventHandler(object sender, ControllerButtons buttonPressed, ButtonActions actionPerformed)
        {
            SelectButton(CurrentSelection - 1);
        }

        public void DownButtonEventHandler(object sender, ControllerButtons buttonPressed, ButtonActions actionPerformed)
        {
            SelectButton(CurrentSelection + 1);
        }

        public void SubScribeToButtons()
        {
            var asISubscribeToButton = (ISubscribeToButton) this;
            asISubscribeToButton.SubscribeToButtonPressed(0, ControllerButtons.A, AButtonEventHandler);
            asISubscribeToButton.SubscribeToButtonPressed(0, ControllerButtons.Up, UpButtonEventHandler);
            asISubscribeToButton.SubscribeToButtonPressed(0, ControllerButtons.Down, DownButtonEventHandler);

        }
    }
}