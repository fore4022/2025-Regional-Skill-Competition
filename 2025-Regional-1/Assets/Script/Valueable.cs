using UnityEngine;

public class Valueable : MonoBehaviour
{
    public GameObject go;
    public GameObject particle;
    public int index;

    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 2)
        {
            go.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                //Managers.Game.Log()
            }
        }
    }
}
