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

    [Header("MainMenu UI Panels")]
    // Main menu
    [SerializeField] private GameObject creditPanel;
    public void NewGame()
    {
        SceneManager.LoadScene("Test");
        Time.timeScale = 1;
    }

    public void Setting()
    {

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
