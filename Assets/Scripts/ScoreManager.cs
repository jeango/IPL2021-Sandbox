using System;
using UnityEngine;

public class ScoreManager : SingletonBehaviour<ScoreManager>
{
    [SerializeField] private ScoreEvent OnScore;
    [SerializeField] private ScoreEvent OnScoreChanged;
    [SerializeField] private ScoreEvent OnHiScoreChanged;
    
    private int _currentScore;
    private int _hiScore;
    public int currentScore => _currentScore;
    public int hiScore => _hiScore;

    protected override void Awake()
    {
        base.Awake();
        _hiScore = PlayerPrefs.GetInt("HiScore", 0);
    }

    private void Start()
    {
        OnScoreChanged?.Invoke(_currentScore);
        OnHiScoreChanged?.Invoke(_hiScore);
    }

    public void Reset()
    {
        _currentScore = 0;
        OnScoreChanged?.Invoke(_currentScore);
    }

    public void GainScore(int value)
    {
        _currentScore += value;
        OnScore?.Invoke(value);
        OnScoreChanged?.Invoke(_currentScore);
        if (_currentScore > _hiScore)
        {
            _hiScore = _currentScore;
            OnHiScoreChanged?.Invoke(_hiScore);
            PlayerPrefs.SetInt("HiScore", _hiScore);
        }
    }
}