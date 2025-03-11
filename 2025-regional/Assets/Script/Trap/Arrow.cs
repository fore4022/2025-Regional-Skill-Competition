using UnityEngine;
public class Arrow : MonoBehaviour
{
    private Collider col;
    private bool a = true;
    private void Awake()
    {
        col = GetComponent<Collider>();
    }
    public void Update()
    {
        if(a)
        {
            transform.position += new Vector3(0, -30, 0) * Time.deltaTime;
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if(!a)
        {
            return;
        }

        if (collision.gameObject.CompareTag("terrain"))
        {
            a = false;
            col.enabled = false;
        }
    }
}