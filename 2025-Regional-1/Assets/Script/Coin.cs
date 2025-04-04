
using UnityEngine;
using UnityEngine.UIElements;

public class Coin : MonoBehaviour
{
    public int hash;

    public void Start()
    {
        foreach (int i in Managers.Game.hash)
        {
            if (i == hash)
            {
                gameObject.SetActive(false);
            }
        }
        transform.Rotate(0, Random.Range(0, 360), 0);
    }
    public void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Managers.Game.addCoin += 10;
            gameObject.SetActive(false);
        }
    }
}
