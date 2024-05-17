using TMPro;
using UnityEngine;

namespace Scripts.GameGeneral.ScoreGeneral.Score
{
    public class Score : MonoBehaviour
    {
        public int score;

        [SerializeField] private TMP_Text scoreText;

        void Update()
        {
            score = PlayerPrefs.GetInt("Score", score);
            scoreText.text = score.ToString();
        }
    }
}
