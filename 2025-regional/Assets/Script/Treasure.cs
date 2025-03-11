using UnityEngine;
public class Treasure : MonoBehaviour
{
    public GameObject go;
    public int index;
    private void Awake()
    {
        foreach(int i in Managers.Game.hash)
        {
            if(index == i)
            {
                gameObject.SetActive(false);
            }
        }

        Managers.Game.hash.Add(index);
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 2)
        {
            go.gameObject.SetActive(true);

            Vector3 direction = transform.position - Managers.Game.player.cam.transform.position;
            go.transform.rotation = Quaternion.LookRotation(direction);

            if (Input.GetKeyDown(KeyCode.F))
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }
}