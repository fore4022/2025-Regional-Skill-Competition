
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Managers.Game.GameOver(true);
        }
    }
}
