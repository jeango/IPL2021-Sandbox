using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>, IGameManager
{
    [SerializeField] private string startScene;
    [SerializeField] private UnityEvent OnEndGame;
    [SerializeField] private UnityEvent OnStartGame;

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine(SwitchScene(startScene, () => OnStartGame?.Invoke()));
    }

    private IEnumerator SwitchScene(string newScene, Action callback = null)
    {
        if (SceneManager.sceneCount > 1)
        {
            var currentScene = SceneManager.GetActiveScene().name;
            yield return SceneManager.UnloadSceneAsync(currentScene);
        }
        yield return SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newScene));
        callback?.Invoke();
    }

    public void EndGame()
    {
        OnEndGame?.Invoke();
    }
}
