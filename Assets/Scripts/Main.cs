using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MF
{
    public class Main : MonoBehaviour
    {
        private int _bonusCount;
        IEnumerator interactiveEnum;

        [SerializeField] private Unit _player;
        [SerializeField] private LevelObjView[] _bonusView;
        [SerializeField] private Additions[] _additObj = new Additions[3];
        [SerializeField] private TextMeshProUGUI _pointLabel;
        [SerializeField] private TextMeshProUGUI _gameOverLabel;
        [SerializeField] private Button _restartButton;


        private InputConroller _inputController;
        private ListExecutiveObjectsController _executiveObject;
        private CameraController _camController;
        private UIDisplayBonus _dispayBonus;
        private UIDisplayGameOver _displayGameOver;


        private void Awake()
        {
            Time.timeScale = 1f;
            
            for (int i = 0; i < _bonusView.Length; i++)
            {
                _additObj[i] = new Buff(_bonusView[i]);
            }

            _inputController = new InputConroller(_player);
            _executiveObject = new ListExecutiveObjectsController(_additObj);
            _dispayBonus = new UIDisplayBonus(_pointLabel);
            _displayGameOver = new UIDisplayGameOver(_gameOverLabel);
            _camController = new CameraController(_player._transform , Camera.main.transform);

            
            _executiveObject.AddExecutiveObject(_inputController);
            _executiveObject.AddExecutiveObject(_camController);
            interactiveEnum = _executiveObject.GetEnumerator();

            _restartButton.onClick.AddListener(RestartGame);
            //_restartButton.gameObject.SetActive = false;
            

            
            foreach (var item in _additObj)
            {
                if (item is Buff buff)
                {
                    buff.AddPoints += AddPoints;
                }
                else if (item is Debuff debuff)
                {
                    continue;
                    //debuff.CoughtPlayer += CoughtPlayer;
                    //debuff.CoughtPlayer += _displayGameOver.GameOver;
                }
            }
        }
        private void AddPoints(int value)
        {
            _bonusCount += value;
            _dispayBonus.Display(_bonusCount);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        void Update()
        {
            if (_executiveObject.MoveNext())
            {
                IExecute temp = (IExecute)_executiveObject.Current;
                temp.Update();
            }
            else
            {
                _executiveObject.Reset();
            }
        }
    }
}

