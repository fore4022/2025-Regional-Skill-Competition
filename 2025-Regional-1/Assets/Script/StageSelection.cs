using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSelection : MonoBehaviour
{
    public GameObject effect;
    public void Update()
    {
        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 12f)
        {
            effect.SetActive(true);

        }
        else
        {
            effect.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("StageSelection");
        }
    }
}
