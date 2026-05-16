using UnityEngine;

public class GameManager : MonoBehaviour
{
    float previousTimeScale = 1;
    public GameObject pausePanel; // UI
    public static bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
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
}