
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameObject effect;
    public InputField putt;

    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 3)
        {
            effect.SetActive(true);
        }
        else
        {
            effect.SetActive(false);

        }
    }
    public void EEnd()
    {
        Managers.Game.ranking.Add((putt.text, (int)Managers.Game.totalSec));
        Managers.Game.stageIndex = 1;
        Managers.Game.totalSec = 0;
        Managers.Game.totalCoin = 0;
        Managers.Game.bbb = new List<bool>() { false, false, false, false, false, false };
        Managers.Game.vals = new();
        Managers.Game.hash = new();
        Managers.Game.backSize = 4;
        Managers.Game.air = 100;
        SceneManager.LoadScene("Main");
    }
}
