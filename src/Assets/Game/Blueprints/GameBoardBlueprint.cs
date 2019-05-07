﻿using EcsRx.Blueprints;
using EcsRx.Entities;
using EcsRx.Plugins.Views.Components;
using Game.Components;

using System.Collections.Generic;
using EcsRx.Components;

namespace Game.Blueprints
{
    public class GameBoardBlueprint : IBlueprint
    {
        private readonly int _width;
        private readonly int _height;

        public GameBoardBlueprint(int width = 8, int height = 8)
        {
            _width = width;
            _height = height;
        }

        public void Apply(IEntity entity)
        {
            var gameBoardComponent = new GameBoardComponent
            {
                Width = _width,
                Height = _height
            };

            var components = new List<IComponent>();
            components.Add(gameBoardComponent);

            components.Add(new ViewComponent());

            entity.AddComponents(components.AsReadOnly());
        }
    }
}