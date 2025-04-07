
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public List<(string name, int time)> ranking = new();
    public Player player;
    public GameObject Log;
    public float totalCoin = 0;
    public float totalSec = 0;
    public float sec = 0;
    public float addCoin = 0;
    public int backSize = 4;
    public int air = 100;
    public List<int> hash = new();
    public List<int> addhash = new();

    public GameObject inter;

    public int stageIndex = 1;
    public int currentIndex;

    public string name;

    public List<bool> bbb = new List<bool>() { false, false, false, false, false };

    public List<int> inven = new();
    public List<Valuable> vals = new();

    public GameObject fail;
    public GameObject clear;

    public void GameStart(int i)
    {
        currentIndex = i;
        SceneManager.LoadScene($"InGame_{i}");
        vals = new();
        inven = new();
    }
    public void GameOver(bool isClear)
    {
        inter.gameObject.SetActive(false);

        if (isClear)
        {
            foreach(int aa in addhash)
            {
                hash.Add(aa);
            }

            if (stageIndex == currentIndex)
            {
                stageIndex++;
            }

            clear.SetActive(true);
        }
        else
        {
            addhash = new();
            fail.SetActive(true);

        }

        Debug.Log(stageIndex);
    }
    public void Res()
    {
        SceneManager.LoadScene($"InGame_{currentIndex}");
        vals = new();
        inven = new();
        sec = 0;
        addCoin = 0;
    }
    public void Send(string aaa)
    {
        GameObject go = GameObject.Instantiate(Log);

        LogA a = go.GetComponent<LogA>();

        player.StartCoroutine(Util.Typeing(a.text, aaa));
    }
}
