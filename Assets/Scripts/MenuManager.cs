using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Pause menu
    [SerializeField] GameObject pausePanel;
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
    }

    // Main menu
    public void NewGame()
    {
        SceneManager.LoadScene("Test");
    }

    public void Setting()
    {

    }

    public void Credit()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
