using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int scoreValue;
    [SerializeField] private ScoreEvent OnScore;
    
    public void ScorePoints()
    {
        ScoreManager.instance?.GainScore(scoreValue);
    }
}