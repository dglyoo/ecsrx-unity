using EcsRx.Blueprints;
using EcsRx.Entities;
using Game.Components;
using UnityEngine;

using System.Collections.Generic;
using EcsRx.Components;

namespace Game.Blueprints
{
    public class LevelBlueprint : IBlueprint
    {
        private readonly int _minWalls = 4;
        private readonly int _maxWalls = 9;
        private readonly int _minFood = 1;
        private readonly int _maxFood = 5;
        private readonly int _level;

        public LevelBlueprint(int level = 1)
        {
            _level = level;
        }

        public void Apply(IEntity entity)
        {
            List<IComponent> components = new List<IComponent>();
            var levelComponent = new LevelComponent();
            UpdateLevel(levelComponent, _level);
            components.Add(levelComponent);
            entity.AddComponents(components.AsReadOnly());
        }

        public void UpdateLevel(LevelComponent levelComponent, int level)
        {
            levelComponent.EnemyCount = (int) Mathf.Log(level, 2f);
            levelComponent.FoodCount = Random.Range(_minFood, _maxFood);
            levelComponent.WallCount = Random.Range(_minWalls, _maxWalls);
            levelComponent.Level.Value = level;
        }
    }
}