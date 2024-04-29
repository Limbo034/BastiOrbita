using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.GameTwo.PlayerBall
{
    public class ColorBall : MonoBehaviour
    {
        public static int health = 3;
        public static int score = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("BonusGreen") || other.CompareTag("BonusRed") || other.CompareTag("BonusBlue"))
            {
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    if (other.CompareTag("BonusGreen") && renderer.material.color != Color.green)
                    {
                        renderer.material.color = Color.green;
                        health++;
                    }
                    else if (other.CompareTag("BonusRed") && renderer.material.color != Color.red)
                    {
                        renderer.material.color = Color.red;
                        health++;
                    }
                    else if (other.CompareTag("BonusBlue") && renderer.material.color != Color.blue)
                    {
                        renderer.material.color = Color.blue;
                        health++;
                    }
                    else
                    {
                        health--;
                    }
                    Debug.Log(health);
                    Destroy(other.gameObject);
                }
            }
            else if (other.CompareTag("EnemyGreen") || other.CompareTag("EnemyRed") || other.CompareTag("EnemyBlue"))
            {
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    if (other.CompareTag("EnemyGreen") && renderer.material.color != Color.green)
                    {
                        if (health <= 0)
                        {
                            PlayerPrefs.SetInt("Score", score);
                            SceneManager.LoadScene(2);
                            Debug.Log(health);
                        }
                        else
                        {
                            health--;
                            Debug.Log(health);
                        }
                        Destroy(other.gameObject);
                    }
                    else if (other.CompareTag("EnemyRed") && renderer.material.color != Color.red)
                    {
                        if (health <= 0)
                        {
                            PlayerPrefs.SetInt("Score", score);
                            SceneManager.LoadScene(2);
                            Debug.Log(health);
                        }
                        else
                        {
                            health--;
                            Debug.Log(health);
                        }
                        Destroy(other.gameObject);
                    }
                    else if (other.CompareTag("EnemyBlue") && renderer.material.color != Color.blue)
                    {
                        if (health <= 0)
                        {
                            PlayerPrefs.SetInt("Score", score);
                            SceneManager.LoadScene(2);
                            Debug.Log(health);
                        }
                        else
                        {
                            health--;
                            Debug.Log(health);
                        }
                        Destroy(other.gameObject);
                    }

                    else if (renderer.material.color == Color.green || renderer.material.color == Color.red || renderer.material.color == Color.blue)
                    {
                        score++;
                        Debug.Log("score" + score);
                        Destroy(other.gameObject);
                    }
                }
            }
        }
    }
}
