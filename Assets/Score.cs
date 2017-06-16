
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    static public int score = 0;
    static int highScore = 0;

    public Text ScoreText;
    public Text HighScoreText;
  static public void AddPoint()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
        }
            
    }
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    void Update()
    {
        ScoreText.text = string.Format("Score {0}", +score);
       HighScoreText.text = string.Format("HighScore {0}", +highScore);

    }
}
