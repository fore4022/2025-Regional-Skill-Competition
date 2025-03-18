
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    public List<int> hash = new();
    public Player player;
    public int stage = 1;
    public int totalScore = 0;
    public int totalTime = 0;
    public int totalCoin = 0;
    public int addCoin = 0;

    public GameObject log;

    public void GameStart()
    {

    }
    public void ReStart()
    {

    }
    public void GameOver()
    {

    }
    public void Log(string te)
    {
        GameObject go = GameObject.Instantiate(log);

        go.GetComponent<LogA>().text.text = te;
    }
}
