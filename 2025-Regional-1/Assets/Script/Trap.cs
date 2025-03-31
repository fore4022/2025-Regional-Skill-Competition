using UnityEngine;
public class Trap : MonoBehaviour
{
    public bool index;
    public GameObject a;
    public GameObject b;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Active();
        }
    }
    public void Active()
    {
        if(index)
        {
            a.SetActive(true);
        }
        else
        {
            b.SetActive(true);

        }
    }
}