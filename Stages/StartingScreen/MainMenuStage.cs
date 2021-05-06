////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System.Diagnostics;
using Microsoft.Xna.Framework;
using MultiplayerZelda.BaseClasses;
using SgEngine.Collision;
using SgEngine.Core.Input;
using SgEngine.EKS;

namespace MultiplayerZelda.Stages.StartingScreen
{
    public class MainMenuStage : ZeldaStage
    {
        private Logos uiElement;
        private PlayerController _levelController = GameWorld.Input.PlayerControllers[0];
        public override void Initialize()
        {
            base.Initialize();
            uiElement = new Logos(new Rectangle(100, 100, 128, 128), ZeldaGraphics.BasicUiSquare);
            _gameObjectList.AddGameObject(uiElement);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var newPoint = uiElement.LocalPosition;
            if (_levelController.IsButtonHeld(ControllerButtons.Right))
                newPoint.X++;
            if (_levelController.IsButtonHeld(ControllerButtons.Left))
                newPoint.X--;
            if (_levelController.IsButtonHeld(ControllerButtons.Down))
                newPoint.Y++;
            if (_levelController.IsButtonHeld(ControllerButtons.Up))
                newPoint.Y--;
            var instance = GameWorld.Input;
            if (GameWorld.Input.LeftMouseButtonClicked())
            {
                var mousePosition = instance.MousePosition().ToPoint();
                var mouseRect = new Rectangle(mousePosition.X, mousePosition.Y, 25, 25);
                for (int i = 0; i < _gameObjectList.GameObjects.Count; i++)
                {
                    if (Collision.ShapesIntersect(mouseRect,
                        _gameObjectList.GameObjects[i].SpriteComponent.GetCurrentSpriteRect()))
                        _gameObjectList.GameObjects[i].SpriteComponent.DebugMode = !_gameObjectList.GameObjects[i].SpriteComponent.DebugMode;
                }

            }
            uiElement.LocalPosition = newPoint;

            foreach (var _gameObject in _gameObjectList.GameObjects)
            {
                if (_gameObject.SpriteComponent.DebugMode)
                {
                    var tempPoint = instance.MousePosition().ToPoint().ToVector2();
                    _gameObject.LocalPosition = tempPoint;
                }
            }
            Debug.WriteLine(newPoint);

        }
    }
}