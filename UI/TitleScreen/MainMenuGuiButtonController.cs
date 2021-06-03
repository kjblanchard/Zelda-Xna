////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda 
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System;
using Microsoft.Xna.Framework;
using MultiplayerZelda.Utils.Enums;
using SgEngine.Core.Input;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;
using SgEngine.Interfaces.Input;
using SgEngine.Interfaces.Sound;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class MainMenuGuiButtonController : GuiButtonController, IHandleAButtonPressed, IHandleUpButtonPressed, IHandleDownButtonPressed, IPlaySfx
    {
        protected Enum _moveSoundEffect;
        protected Enum _selectSoundEffect;
        protected IPlaySfx AsIPlaySfx => this;
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
            CursorGuiImageComponent?.Initialize();
            SubScribeToButtons();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            CursorGuiImageComponent.LocalPosition = UpdateFingerCursorIcon();
        }
        /// <summary>
        /// Calculates where the cursor icon should be on the screen
        /// </summary>
        /// <returns>Returns the location that the cursor should go to</returns>
        private Vector2 UpdateFingerCursorIcon()
        {
            var tempLocation = ButtonsToManage[CurrentSelection].GlobalPosition;
            tempLocation -= _parent.Origin;
            tempLocation.X -= 10;
            tempLocation.Y += ButtonsToManage[CurrentSelection].Size.Y / 2;
            return tempLocation;
        }

        protected override void SelectButton(int newSelection, bool selectedByMouse = false)
        {
            base.SelectButton(newSelection, selectedByMouse);
            if (!selectedByMouse && _moveSoundEffect != null)
                AsIPlaySfx.PlaySfx(_moveSoundEffect);
        }

        protected override void PressButton(int buttonToPress, bool pressedByMouse = false)
        {
            base.PressButton(buttonToPress, pressedByMouse);
            if (_selectSoundEffect != null)
                AsIPlaySfx.PlaySfx(_selectSoundEffect);
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
            var asISubscribeToButton = (ISubscribeToButton)this;
            asISubscribeToButton.SubscribeToButtonPressed(0, ControllerButtons.A, AButtonEventHandler);
            asISubscribeToButton.SubscribeToButtonPressed(0, ControllerButtons.Up, UpButtonEventHandler);
            asISubscribeToButton.SubscribeToButtonPressed(0, ControllerButtons.Down, DownButtonEventHandler);
        }
    }
}