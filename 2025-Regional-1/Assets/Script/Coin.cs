
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 180 * Time.deltaTime, 0));
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
