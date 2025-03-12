using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager
{
    public Player player;
    public int stageIndex = 1;
    public GameObject result;
    public List<int> hash = new();
    public bool isClear;
    public int totalCoin = 0;
    public int addCoin = 0;

    public void GameStart()
    {
        SceneManager.LoadScene($"InGame_{stageIndex}");
    }
    public void GameOver(bool isClear)
    {
        if(isClear)
        {
            totalCoin += addCoin;
        }

        this.isClear = isClear;
        result.SetActive(true);
    }
    public void ReStart()
    {

    }
    public void RePlay()
    {
        stageIndex = 0;
        hash = new();
        addCoin = 0;
    }
}