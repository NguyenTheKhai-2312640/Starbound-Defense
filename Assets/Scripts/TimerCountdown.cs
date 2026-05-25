using UnityEngine;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    [SerializeField] public float countDownTime;
    [SerializeField] private GameManager gameManager;
    private float currentTime;
    private bool isCounting = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = countDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCounting) return;

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimeText();
        }
        else
        {
            isCounting = false;
            currentTime = 0;
            UpdateTimeText();
            Feature();
        }
    }

    void UpdateTimeText()
    {
        int minutes = ((int)currentTime / 60);
        int secords = ((int)currentTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, secords);
    }

    public void StopTimer()
    {
        isCounting = false;
    }

    void Feature()
    {
        gameManager.WinGame();
    }
}
