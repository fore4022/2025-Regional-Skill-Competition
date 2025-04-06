using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject effect;
    public GameObject puz;
    public bool trig = false;
    public GameObject exit;

    public void Update()
    {
        if(trig && !puz.activeSelf)
        {
            exit.SetActive(true);
            gameObject.SetActive(false);
        }

        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 3)
        {
            effect.SetActive(true);

            Vector3 vec = transform.position - Managers.Game.player.gameObject.transform.position;

            effect.transform.rotation = Quaternion.LookRotation(vec);

            if(Input.GetKeyDown(KeyCode.F) && trig == false)
            {
                trig = true;
                puz.SetActive(true);
            }
        }
        else
        {
            effect.SetActive(false);

        }
    }

}
