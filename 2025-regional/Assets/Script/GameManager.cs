using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager
{
    public List<(string name, int score)> rank = new();
    public Inventory inventory = new();

    public List<Valuable> val = new();
    public GameObject log;
    public Player player;
    public int stageIndex = 5;
    public GameObject result;
    public List<int> hash = new();
    public bool isClear;
    public int totalCoin = 500;
    public int addCoin = 0;
    public int inventorySize = 4;
    public GameObject status;
    public float air = 100;
    public Inventory_UI inven;

    public bool a1 = true;
    public bool a2 = true;
    public bool a3 = true;
    public bool a4 = true;
    public bool a5 = true;

    public void GameStart(int a = 0)
    {
        inventory = new();

        SceneManager.LoadScene($"InGame_{stageIndex - a}");
    }
    public void GameOver(bool isClear)
    {
        if(isClear)
        {
            totalCoin += addCoin;
            stageIndex++;

            if(stageIndex == 6)
            {
                stageIndex = 0;
                hash = new();
            }
        }

        status.SetActive(false);
        this.isClear = isClear;
        inventory = new();
        addCoin = 0;
        result.SetActive(true);
    }
    public void Log(string text)
    {
        GameObject go = GameObject.Instantiate(log);
        Log_UI lo = go.GetComponent<Log_UI>();

        lo.Set(text);
    }
}