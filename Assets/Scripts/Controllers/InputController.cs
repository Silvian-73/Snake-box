﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake_box
{
    public sealed class InputController : IExecute
    {
        #region Private Data

        private KeyCode _left = KeyCode.A;
        private KeyCode _right = KeyCode.D;
        private KeyCode _up = KeyCode.W;
        private KeyCode _down = KeyCode.S;

        #endregion

        private readonly CharacterData _characterData;

        public InputController()
        {
            _characterData = Data.Instance.Character;           
        }

        #region IExecute

        public void Execute()
        {
            Direction direction = Direction.None;          
            if (Input.GetKeyDown(_left))
            {
                direction = Direction.Left;
            }
            if (Input.GetKeyDown(_right))
            {
                direction = Direction.Right;
            }
            if (Input.GetKeyDown(_up))
            {
                direction = Direction.Up;
            }
            if (Input.GetKeyDown(_down))
            {
                direction = Direction.Down;
            }
            _characterData._characterBehaviour.Move(direction);
            _characterData._characterBehaviour.TeleportIfOutOfBorder();
            if (Input.GetKeyDown(AxisManager.SPACE))
            {               
                _characterData._characterBehaviour.SetDamage(50);/// добавление ячейки - хвост
            }
            if (Input.GetKey(AxisManager.ESCAPE))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKey( KeyCode.H))
            {
                Wallet.PutLocalCoins(30);
            }
            if (Input.GetKey(KeyCode.J))
            {
                Wallet.TakeLocalCoins(50);
            }
            if (Input.GetKey(KeyCode.K))
            {
                Wallet.PutWorldCoins(30);
            }
            if (Input.GetKey(KeyCode.L))
            {
                Wallet.TakeWorldCoins(50);
            }
        }

        #endregion
    }
}
