using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private float score;
    [SerializeField] private float highScore;
    [SerializeField] private TextMeshProUGUI highScoreWin;
    [SerializeField] private TextMeshProUGUI highScoreLose;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;

        highScore = PlayerPrefs.GetFloat("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        highScoreWin.text = highScore.ToString();
        highScoreLose.text = highScore.ToString();
    }

    public void AddScore(float enemyScore)
    {
        score += enemyScore;
        // Debug.Log(score);
        if (score > highScore)
        {
            //change our highscore number
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
    }
}