using UnityEngine;
public class Coin : MonoBehaviour
{
    public float value = 0;
    void Start()
    {
        value += Random.Range(0, 360);
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, value * Time.deltaTime, 0));

        value += 10 * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}