using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gamesMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject scinMenu;

    [SerializeField] private GameObject[] panels;

    [SerializeField] private GameObject soundButton;
    [SerializeField] private GameObject soundButtonClose;

    [SerializeField] Animator animationPlayer;
    private int currentPanelIndex = 0;
    [SerializeField] private bool sonnd = true;
    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    #region LogicPanelMainMenu
    #region GamesPanel
    public void OpenGamesPanel()
    {
        ToggleMenus(gamesMenu, mainMenu);
    }

    public void CloseGamesPanel()
    {
        ToggleMenus(mainMenu, gamesMenu);
    }

    public void ToggleNextPanel()
    {
        panels[currentPanelIndex].SetActive(false);

        currentPanelIndex = (currentPanelIndex + 1) % panels.Length;

        panels[currentPanelIndex].SetActive(true);
    }

    public void TogglePreviousPanel()
    {
        panels[currentPanelIndex].SetActive(false);

        currentPanelIndex = (currentPanelIndex - 1 + panels.Length) % panels.Length;

        panels[currentPanelIndex].SetActive(true);
    }
    #endregion

    #region OptionsPanel
    public void OpenOptionsPanel()
    {
        ToggleMenus(optionsMenu, mainMenu);
        animationPlayer.SetBool("isRun", true);
    }

    public void CloseOptionsPanel()
    {
        ToggleMenus(mainMenu, optionsMenu);
    }
    #endregion

    #region ScinPanel
    public void OpenScinMenuPanel()
    {
        ToggleMenus(scinMenu, mainMenu);
    }

    public void CloseScinMenuPanel()
    {
        ToggleMenus(mainMenu, scinMenu);
    }
    #endregion

    public void Sound()
    {
        if (sonnd == true)
        {
            ToggleMenus(soundButton, soundButtonClose);
            sonnd = false;
        }
        else if (sonnd == false)
        {
            ToggleMenus(soundButtonClose, soundButton);
            sonnd = true;
        }

    }

    private void ToggleMenus(GameObject showMenu, GameObject hideMenu)
    {
        showMenu.SetActive(true);
        hideMenu.SetActive(false);
    }
    #endregion

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
