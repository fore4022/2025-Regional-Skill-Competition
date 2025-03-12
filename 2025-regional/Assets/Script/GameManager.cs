using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager
{
    public Inventory inventory = new();

    public Player player;
    public int stageIndex = 5;
    public GameObject result;
    public List<int> hash = new();
    public bool isClear;
    public int totalCoin = 0;
    public int addCoin = 0;
    public int inventorySize = 4;

    public void GameStart()
    {
        inventory = new();

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
        inventory = new();
    }
    public void RePlay()
    {
        stageIndex = 0;
        hash = new();
        addCoin = 0;
    }
}