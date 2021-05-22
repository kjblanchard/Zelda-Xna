////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda 
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SgEngine.GUI.Components;
using SgEngine.GUI.Types;

namespace MultiplayerZelda.UI.TitleScreen
{
    public class MainMenuGuiButtonController : GuiButtonController
    {
        public GuiImageComponent CursorGuiImageComponent;
        public MainMenuGuiButtonController(GuiComponent parent, Vector2 offset = new Vector2(), Point size = new Point()) : base(parent, offset, size)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            CursorGuiImageComponent =
                new GuiImageComponent(this, ZeldaGraphics.RightPointFingerCursor, new Point(16, 16))
                {
                    LocationOverride = true
                };
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            CursorGuiImageComponent.LocalPosition = UpdateCursorPosition();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            CursorGuiImageComponent.Draw(gameTime,spriteBatch);
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