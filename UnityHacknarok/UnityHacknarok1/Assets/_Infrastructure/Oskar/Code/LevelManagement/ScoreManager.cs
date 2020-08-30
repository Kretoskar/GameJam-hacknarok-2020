using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Infrastructure.LevelManagement
{
    public class ScoreManager : MonoBehaviour
    {
        #region Singleton
        
        private static ScoreManager _instance;

        public static ScoreManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ScoreManager>();
                    if (_instance == null)
                    {
                        GameObject container = new GameObject("ScoreManager");
                        _instance = container.AddComponent<ScoreManager>();
                    }
                }

                return _instance;
            }
        }
        
        #endregion
        
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        [SerializeField] private int _requiredScore;

        void Start()
        {
            CurrentScore = 0;
        }
        
        private int _currentScore;
        
        public int CurrentScore
        {
            get
            {
                return _currentScore;
            }

            set
            {
                _currentScore = value;
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            //string builder chuju
            string scoreDisplayText = _currentScore.ToString();

            scoreDisplayText += "/";

            scoreDisplayText += _requiredScore.ToString();

            _scoreText.text = scoreDisplayText;
        }
    }
}