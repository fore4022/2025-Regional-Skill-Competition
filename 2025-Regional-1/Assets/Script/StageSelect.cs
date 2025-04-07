
using System.Collections.Generic;
using UnityEngine;
public class StageSelect : MonoBehaviour
{

    public GameObject effect;
    public GameObject ui;

    public GameObject bu1;
    public GameObject bu2;

    public void Start()
    {
        if(Managers.Game.stageIndex == 1)
        {
            bu1.SetActive(false);
            bu2.SetActive(false);
        }
    }
    public void Update()
    {

        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 18)
        {
            if (!ui.activeSelf)
            {

                effect.SetActive(true);
            }
            else

            {
                effect.SetActive(false);

            }

            if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 10)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ui.SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ui.SetActive(false);
                }
            }
        }
        else
        {
            effect.SetActive(false);

        }
    }
    public void NextStage()
    {
        Managers.Game.GameStart(Managers.Game.stageIndex);
    }
    public void BeforeStage()
    {
        Managers.Game.GameStart(Managers.Game.stageIndex -1);
    }
    public void NewGame()
    {
        Managers.Game.stageIndex = 1;
        Managers.Game.totalSec = 0;
        Managers.Game.totalCoin = 0;
        Managers.Game.bbb = new List<bool>() { false, false, false, false, false, false };
        Managers.Game.vals = new();
        Managers.Game.hash = new();
        Managers.Game.backSize = 4;
        Managers.Game.air = 100;
    }
}
