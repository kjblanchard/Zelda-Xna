////////////////////////////////////////////////////////////
//
// Super Goon Games - Multiplayer Zelda
// Copyright (C) 2020-2021 - Kevin Blanchard
//
////////////////////////////////////////////////////////////

using System.Diagnostics;
using Microsoft.Xna.Framework;
using MultiplayerZelda.BaseClasses;
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
            uiElement.LocalPosition = newPoint;
            Debug.WriteLine(newPoint);

        }
    }
}