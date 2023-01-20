using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MF
{
    public sealed class UIDisplayGameOver
    {
        private TextMeshProUGUI _gameOverLabel;

        public UIDisplayGameOver(TextMeshProUGUI gameOverLabel)
        {
            _gameOverLabel = gameOverLabel;
            _gameOverLabel.text = String.Empty;
        }
        public void GameOver(object obj)
        {
            _gameOverLabel.text = "Game is over";
        }
    }
}

