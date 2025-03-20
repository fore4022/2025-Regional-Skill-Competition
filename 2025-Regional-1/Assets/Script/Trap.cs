using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public List<GameObject> o;
    public int index = 0;
    public bool use = true;

    public void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            if (!use)
            {
                return;
            }
            o[index].SetActive(true);
            use = false;

            StartCoroutine(trigger());
        }
    }

    private IEnumerator trigger()
    {
        o[index].SetActive(true);

        yield return new WaitForSeconds(5);
        o[index].SetActive(false);
    }
}
