
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    public List<(string name, int score)> rank = new();
    public List<int> hash = new();
    public Player player;
    public int stage = 2;
    public int totalScore = 0;
    public int totalTime = 0;
    public int totalCoin = 0;
    public int addCoin = 0;

    public List<bool> it = new();

    public GameObject log;

    public float air = 100;

    public void GameStart()
    {
        addCoin = 0;
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
