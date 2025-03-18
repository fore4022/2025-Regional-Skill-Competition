
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{
    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 8)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("StageSelect");
            }
        }
    }
}
