using UnityEngine;
public class Trap : MonoBehaviour
{
    public GameObject go;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            go.SetActive(true);
        }
    }
}
