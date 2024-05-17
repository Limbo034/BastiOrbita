using UnityEngine;
using UnityEngine.SceneManagement;
using Scripts.GameGeneral.ScoreGeneral.Score;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

namespace Scripts.GameTwo.PlayerBall
{
    public class ColorBall : MonoBehaviour
    {
        public bool health = true;
        private new Renderer renderer;
        public bool deadPlayer = false;

        public int levelScore = 0;
        public int score;

        [SerializeField] private TMP_Text levelScoreText;
        [SerializeField] private TMP_Text owerScoreText;
        private void Start()
        {
            renderer = GetComponent<Renderer>();
            score = PlayerPrefs.GetInt("Score", score);
        }
        void Update()
        {
            levelScoreText.text = levelScore.ToString();
            owerScoreText.text = levelScore.ToString();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("BonusGreen") || other.CompareTag("BonusRed") || other.CompareTag("BonusBlue"))
            {
                HandleBonusCollision(other);
            }
            else if (other.CompareTag("EnemyGreen") || other.CompareTag("EnemyRed") || other.CompareTag("EnemyBlue"))
            {
                HandleEnemyCollision(other);
            }
        }

        private void HandleBonusCollision(Collider2D other)
        {
            Color bonusColor = Color.clear;

            if (other.CompareTag("BonusGreen"))
            {
                bonusColor = Color.green;
            }
            else if (other.CompareTag("BonusRed"))
            {
                bonusColor = Color.red;
            }
            else if (other.CompareTag("BonusBlue"))
            {
                bonusColor = Color.blue;
            }

            renderer.material.color = bonusColor;
            Destroy(other.gameObject);
        }

        private void HandleEnemyCollision(Collider2D other)
        {
            if (health == true)
            {
                if ((other.CompareTag("EnemyBlue") && renderer.material.color != Color.blue) ||
                    (other.CompareTag("EnemyRed") && renderer.material.color != Color.red) ||
                    (other.CompareTag("EnemyGreen") && renderer.material.color != Color.green))
                {
                    health = false;
                    Debug.Log("Health: " + health);
                    Destroy(other.gameObject);

                    if (!health)
                    {
                        AudioManager.Instance.PlaySFX(AudioManager.Instance.GameOver);
                        gameObject.SetActive(false);

                        Invoke("DeadPlayer", 1.5f);
                    }
                }
                else if (renderer.material.color == Color.green || renderer.material.color == Color.red || renderer.material.color == Color.blue)
                {
                    levelScore++;
                    Debug.Log("Levelscore: " + levelScore);
                    Destroy(other.gameObject);
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.BlasterShotTwo);
                }
            }
        }

        private void DeadPlayer()
        {
            score += levelScore;
            PlayerPrefs.SetInt("Score", score);

            deadPlayer = true;
        }
    }
}
