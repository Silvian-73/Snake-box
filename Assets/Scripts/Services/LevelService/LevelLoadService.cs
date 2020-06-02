﻿using System;
using UnityEngine;

namespace Snake_box
{
    public class LevelLoadService : Service
    {
        public event Action LevelLoaded;

        private GameObject _currentLevel;

        public void LoadLevel(string name)
        {
            if (_currentLevel != null)
                GameObject.Destroy(_currentLevel);
            _currentLevel = GameObject.Instantiate(Data.Instance.LevelPrefabs[name]);
            Services.Instance.LevelService.CurrentLevelName = name;
            LevelLoaded?.Invoke();
        }
    } 
}
