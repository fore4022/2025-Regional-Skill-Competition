using System.Collections.Generic;
using UnityEngine;

public class GameManagers 
{
    public List<(string name, int score)> rank = new();
    public List<int> hash = new();
    public List<Valuable> val = new();

    public Player player;
    public int stagetIndex = 1;
    public int totalCoin = 1500;
    public int addCoin = 0;
    public int air = 100;
    public int packSize = 4;
    public List<int> inven = new();

    public GameObject log;
    
    public void GameStart()
    {
        val = new();
    }
    public void GameOver(bool isClear)
    {
        if(isClear)
        {

        }
        else
        {

        }
    }
    public void Log(string str)
    {
        GameObject go = GameObject.Instantiate(log);
        LogA lo = go.GetComponentInChildren<LogA>();


        lo.Logging(str);
    }
}
