using UnityEngine;

public class GameManagerProxy : MonoBehaviour, IGameManager
{
    public void Quit()
    {
        GameManager.instance.Quit();
    }

    public void StartGame()
    {
        GameManager.instance.StartGame();
    }

    public void EndGame()
    {
        GameManager.instance.EndGame();
    }
}
