
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers _instance;
    public static Managers Manager { get { Init(); return _instance; } }
    public GameManager game = new();
    public static GameManager Game { get { return Manager.game; } }
    public static void Init()
    {
        if(_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if(go == null)
            {
                go = new GameObject { name = "@Managers" };

                _instance = go.AddComponent<Managers>();

                DontDestroyOnLoad(go);
            }
        }
    }
}
