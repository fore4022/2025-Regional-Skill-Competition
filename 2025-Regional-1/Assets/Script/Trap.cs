using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public ParticleSystem tr1;
    public ParticleSystem tr2;

    public int index;
    public bool use = true;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(use)
            {
                use = false;
                switch(index)
                {
                    case 0:
                        tr1.gameObject.SetActive(true);
                        StartCoroutine(Set(tr1));
                        break;

                    case 1:
                        tr2.gameObject.SetActive(true);
                        StartCoroutine(Set(tr2));
                        break;
                }
            }
        }
    }
    public IEnumerator Set(ParticleSystem par)
    {
        yield return new WaitForSeconds(4);

        par.gameObject.SetActive(false);
    }
}
