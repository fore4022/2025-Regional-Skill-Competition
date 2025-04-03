using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject effect;
    public GameObject ui;

    public void Update()
    {

        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 10)
        {
            if (!ui.activeSelf)
            {

                effect.SetActive(true);
            }
            else

            {
                effect.SetActive(false);

            }

            if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 6)
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

    public void QQuit()
    {
        Application.Quit();
    }
    public void Nooo()
    {
        ui.SetActive(false);
    }
}
