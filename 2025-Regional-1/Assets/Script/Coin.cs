using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
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
            Managers.Game.Log("°ñµå È×µæ");

            gameObject.SetActive(false);
        }
    }
}
