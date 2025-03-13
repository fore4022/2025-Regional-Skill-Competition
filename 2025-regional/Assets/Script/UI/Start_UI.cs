using UnityEngine;
public class Start_UI : MonoBehaviour
{
    public GameObject go;
    public GameObject ad;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 4)
        {
            go.gameObject.SetActive(true);
        }
        else
        {
            go.gameObject.SetActive(false);
        }
        if(Managers.Game.stageIndex == 1)
        {
            ad.SetActive(false);
        }
        else
        {
            ad.SetActive(true);
        }
    }

    public void S()
    {
        Managers.Game.GameStart();
    }
    public void RS()
    {
        Managers.Game.GameStart(1);
    }
}