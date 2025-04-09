using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class aaaaaaaaa : MonoBehaviour
{
    public Transform target;
    public Transform tar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);

        if (Vector3.Distance(tar.position, transform.position) <= 0.1f)
        {
            return;
        }
        Vector3 dir = (tar.position - transform.position).normalized;
        transform.position += dir * 20 * Time.deltaTime;
    }
}
