using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public GameObject ui;
    public Text gold;
    public Text tt;
    public Text log;

    public void Start()
    {
        Managers.Game.clearUI = gameObject;

        gameObject.SetActive(false);
    }
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ui.SetActive(true);
        }
    }
    public void Update()
    {
        if(ui.activeSelf)
        {
            gold.text = $"+ {Managers.Game.addCoin:D2}G";
            tt.text = $"00 : {((int)Managers.Game.player.totalTime / 60):D2} : {((int)Managers.Game.player.totalTime % 60):D2}";
            if(Managers.Game.clear)
            {

                log.text = "Clear";
                Managers.Game.stage++;

            }
            else
            {
                log.text = "Fair";
            }
        }
    }
    public void Press()
    {
        Managers.Game.clearUI = null;
        SceneManager.LoadScene("Main");
    }
}
