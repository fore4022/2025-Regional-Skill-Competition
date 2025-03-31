using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject effect;
    public GameObject ui;

    public void Update()
    {
        

        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 12f)
        {
            effect.SetActive(true);
        }
        else
        {
            effect.SetActive(false);
        }
            
        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 2f)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                ui.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ui.SetActive(false);
            }
        }
    }
}
