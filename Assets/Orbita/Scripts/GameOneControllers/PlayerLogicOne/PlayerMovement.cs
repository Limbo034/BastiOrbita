using UnityEngine;
using Scripts.GameGeneral.ScoreGeneral.Score;
using TMPro;

namespace Scripts.GameOneControllers.PlayerLogicOne.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] public GameObject wave;
        private Animator playerAnimator;
        public bool deadPlayer = false;
        private bool isDeadHandled = false; // Новый флаг

        public int levelScore = 0;
        public int score;
        [SerializeField] private TMP_Text levelScoreText;
        [SerializeField] private TMP_Text owerScoreText;

        private void Start()
        {
            playerAnimator = GetComponentInChildren<Animator>();

            playerAnimator.SetBool("isRun", true);
            score = PlayerPrefs.GetInt("Score", score);
        }

        void Update()
        {
            levelScoreText.text = levelScore.ToString();
            owerScoreText.text = levelScore.ToString();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Metior"))
            {
                AudioManager.Instance.PlaySFX(AudioManager.Instance.GameOver);
                playerAnimator.SetTrigger("isDead");
                wave.SetActive(false);

                Invoke("DeadPlayer", 1.5f);
            }
            else if (collision.CompareTag("Cookie"))
            {
                levelScore++;
                Debug.Log("score" + levelScore);
                Destroy(collision.gameObject);
            }
        }

        private void DeadPlayer()
        {
            if (isDeadHandled) return; // Проверяем флаг

            score += levelScore;
            PlayerPrefs.SetInt("Score", score);

            gameObject.SetActive(false);
            deadPlayer = true;
            isDeadHandled = true; // Устанавливаем флаг
        }

        public void Freeze()
        {
            playerAnimator.SetTrigger("isFreeze");
        }
    }
}
