
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{

    public GameObject effect;
    public GameObject ui;

    public InputField field;

    public void Start()
    {
        field.text = Managers.Game.name;
    }
    public void Update()
    {

        Managers.Game.name = field.text;

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
        Managers.Game.player.air = 100;
        Managers.Game.totalCoin = 0;
        Managers.Game.totalSec = 0;

        for (int i = 0; i < Managers.Game.bbb.Count; i++)
        {
            Managers.Game.bbb[i] = false;
        }

        Managers.Game.hash = new();

        Managers.Game.stageIndex = 1;
    }
}
