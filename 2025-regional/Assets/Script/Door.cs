using UnityEngine;
public class Door : MonoBehaviour
{
    public GameObject anime;
    public GameObject go;
    public GameObject ui;
    public bool f = false;
    public bool open = false;
    private void Update()
    {
        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 3.5f)
        {
            go.SetActive(true);

            Vector3 direction = transform.position - Managers.Game.player.cam.transform.position;
            go.transform.rotation = Quaternion.LookRotation(direction);

            if (Input.GetKeyDown(KeyCode.F))
            {
                go.SetActive(false);
                ui.SetActive(true);
                f = true;
            }
        }
        else
        {
            go.SetActive(false);
        }
        if(!open && !ui.activeSelf && f)
        {
            anime.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}