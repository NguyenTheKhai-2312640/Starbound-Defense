using UnityEngine;

public class GameManager : MonoBehaviour
{
    float previousTimeScale = 1;
    [Header("UI Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    public static bool isPaused;
    public static bool gameEnded;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            AudioListener.pause = true;
            pausePanel.SetActive(true);
            isPaused = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = previousTimeScale;
            AudioListener.pause = false;
            pausePanel.SetActive(false);
            isPaused = false;
        }
    }

    public void WinGame()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
        AudioListener.pause = true;

        winPanel.SetActive(true);
        gameEnded = true;
    }

    public void LoseGame()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
        AudioListener.pause = true;

        losePanel.SetActive(true);
        gameEnded = true;
    }
}