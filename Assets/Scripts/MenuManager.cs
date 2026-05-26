using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Pause UI Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;


    // Pause menu
    public void Pause()
    {
        pausePanel.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        GameManager.isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        GameManager.isPaused = false;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        GameManager.gameEnded = false;
    }

    [Header("Upgrade UI Panels")]
    [SerializeField] private GameObject upgradePanel;
    public void UpgradeActive()
    {
        Time.timeScale = 0;
        upgradePanel.SetActive(true);
        GameManager.isPaused = true;
    }

    public void UpgradeBack()
    {
        Time.timeScale = 1;
        upgradePanel.SetActive(false);
        GameManager.isPaused = false;
    }

    [Header("MainMenu UI Panels")]
    // Main menu
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject helpPanel;
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public void NewGame()
    {
        SceneManager.LoadScene("Test");
        Time.timeScale = 1;
    }

    public void OpenHelp()
    {
        helpPanel.SetActive(true);
    }

    public void CloseHelp()
    {
        helpPanel.SetActive(false);
    }

    public void Setting()
    {

    }
    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void Credit()
    {
        creditPanel.SetActive(true);
    }

    public void Back()
    {
        creditPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
