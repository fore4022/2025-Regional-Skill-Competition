using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public Player player;
    public int stageIndex = 0;
    public List<GameObject> stage1 = new();
    public List<GameObject> stage2 = new();
    public List<GameObject> stage3 = new();
    public List<GameObject> stage4 = new();
    public List<GameObject> stage5 = new();

    public void GameStart()
    {
        //SceneManager.LoadScene();
    }
    public void GameOver(bool isClear)
    {

    }
}