using System.Collections.Generic;
using UnityEngine;
public class Trap : MonoBehaviour
{
    public List<GameObject> objs;
    public int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objs[index].SetActive(true);
        }
    }
}