using UnityEngine;

public class Valueable : MonoBehaviour
{
    public GameObject go;
    public GameObject particle;
    public int index;

    public void Awake()
    {
        
    }
    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 2)
        {
            Vector3 vec = transform.position - Managers.Game.player.gameObject.transform.position;
            go.transform.rotation = Quaternion.LookRotation(vec);

            go.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                go.SetActive(false);
            }
        }
        else
        {
            go.SetActive(false);
        }
    }
}
