using UnityEngine;
public class Valuable : MonoBehaviour
{
    public GameObject go;
    public string id;

    public int index;
    private void Awake()
    {
        foreach (int i in Managers.Game.hash)
        {
            Debug.Log(i);
            if (index == i)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void Update()
    {
        Debug.Log(Managers.Game.hash.Count);
        if(Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 2)
        {
            go.gameObject.SetActive(true);

            Vector3 direction = transform.position - Managers.Game.player.cam.transform.position;
            go.transform.rotation = Quaternion.LookRotation(direction);

            if(Input.GetKeyDown(KeyCode.F))
            {
                Managers.Game.inventory.Add(id);
                Managers.Game.hash.Add(index);
                gameObject.SetActive(false);
            }
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }
}