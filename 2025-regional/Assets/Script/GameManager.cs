using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager
{
    public Player player;
    public int stageIndex = 1;
    public List<int> hash = new();

    public int coin = 0;

    public void GameStart()
    {
        SceneManager.LoadScene($"InGame_{stageIndex}");
    }
    public void GameOver(bool isClear)
    {

    }
    public void ReStart()
    {

    }
    public void RePlay()
    {
        stageIndex = 0;
        hash = new();
        coin = 0;
    }
}