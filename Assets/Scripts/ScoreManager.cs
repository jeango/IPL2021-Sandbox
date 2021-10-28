using UnityEngine;

public class ScoreManager : SingletonBehaviour<ScoreManager>
{
    [SerializeField] private ScoreEvent OnScore;
    
    private int _currentScore;
    private int _hiScore;
    public int currentScore => _currentScore;
    public int hiScore => _hiScore;

    protected override void Awake()
    {
        base.Awake();
        _hiScore = PlayerPrefs.GetInt("HiScore", 0);
    }

    public void GainScore(int value)
    {
        _currentScore += value;
        if (_currentScore > _hiScore)
        {
            _hiScore = _currentScore;
            PlayerPrefs.SetInt("HiScore", _hiScore);
        }
    }
}