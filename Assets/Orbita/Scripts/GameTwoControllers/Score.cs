using Scripts.GameTwo.PlayerBall;
using TMPro;
using UnityEngine;

namespace TestUI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;
        [SerializeField] TMP_Text healthText;
        void Update()
        {
            scoreText.text = "Score: " + ColorBall.score.ToString() + "\nHealth: " + ColorBall.health.ToString();
        }
    }
}
