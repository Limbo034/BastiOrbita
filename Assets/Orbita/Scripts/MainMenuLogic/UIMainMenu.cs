using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gamesMenu;
    [SerializeField] private GameObject optionsMenu; 
    [SerializeField] private GameObject scroleMenu;

    [SerializeField] private GameObject[] panels; 
    private int currentPanelIndex = 0; 

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
    }

    public void CloseOptionsPanel()
    {
        ToggleMenus(mainMenu, optionsMenu);
    }
    #endregion

    #region ScrolePanel
    public void OpenScrolePanel()
    {
        ToggleMenus(scroleMenu, mainMenu);
    }

    public void CloseScrolePanel()
    {
        ToggleMenus(mainMenu, scroleMenu);
    }
    #endregion

    private void ToggleMenus(GameObject showMenu, GameObject hideMenu)
    {
        showMenu.SetActive(true);
        hideMenu.SetActive(false);
    }
    #endregion
}