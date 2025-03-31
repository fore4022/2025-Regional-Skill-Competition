using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject effect;

    public GameObject ui;
    public bool trig = false;
    

    public void Update()
    {
        if(trig)
        {
            if(ui.activeSelf)
            {

                gameObject.SetActive(false);
            }
        }

        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 2f)
        {
            effect.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                trig = true;
                ui.SetActive(true);
            }
        }
    }
}
