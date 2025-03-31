
using UnityEngine;

public class DoorAnime : MonoBehaviour
{
    public GameObject go;
    public void Update()
    {
        Vector3 direction = transform.position - go.transform.position;

        transform.position += direction.normalized * 2;
    }
}
