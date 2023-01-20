using System;
using TMPro;
using UnityEngine.UI;

namespace MF
{
    public class UIDisplayBonus
    {
        public TextMeshProUGUI _pointsLabel;

        public UIDisplayBonus(TextMeshProUGUI pointsLabel)
        {
            _pointsLabel = pointsLabel;
            _pointsLabel.text = String.Empty;
        }
        public void Display(int value)
        {
            _pointsLabel.text = $"Points: {value}";
        }
    }
}

