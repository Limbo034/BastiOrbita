using UnityEngine;
using Scripts.GameOneControllers.PlayerLogicOne.PlayerMovement;
using Scripts.GameTwo.PlayerBall;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject gameMenu;
    [SerializeField] public GameObject deadMenu;
    [SerializeField] public GameObject stopMenu;

    private PlayerMovement playerMovement;
    private ColorBall ñolorBall;

    [SerializeField] public bool OneGame = false;
    private void Start()
    {
        if(OneGame == true)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }
        else
        {
            ñolorBall = FindObjectOfType<ColorBall>();
        }
    }
    private void Update()
    {
        if(OneGame == true)
        {
            if (playerMovement.deadPlayer == true)
            {
                gameMenu.SetActive(false);
                deadMenu.SetActive(true);
            }
        }
        else
        {
            if (ñolorBall.deadPlayer == true)
            {
                gameMenu.SetActive(false);
                deadMenu.SetActive(true);
            }
        }
    }
    public void GamePause()
    {
        Time.timeScale = 0;

        gameMenu.SetActive(false); 
        stopMenu.SetActive(true);
    }
    public void GameStart()
    {
        Time.timeScale = 1;

        gameMenu.SetActive(true);
        stopMenu.SetActive(false);
    }
    public void Restart(int restart)
    {
        SceneManager.LoadScene(restart);
    }
    public void GamePauseLoadMainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

    public void GameLoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
