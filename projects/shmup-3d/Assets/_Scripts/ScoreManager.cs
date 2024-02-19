using TMPro;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    [SerializeField] private int score;

    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateScore(int newScore)
    {
        score += newScore;
        scoreText.text = $"Score: {score}";
    }
}
