using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public Text _finishGameLabel;
        private DisplayEndGame _displayEndGame;

        private void Awake()
        {
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
        }

        private void CaughtPlayer(object value)
        {
            Time.timeScale = 0.0f;
        }

        private void Update()
        {
        }

        public void Dispose()
        {
        }
    }
}