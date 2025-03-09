using UnityEngine;
public class Managers : MonoBehaviour
{
    public static Managers managers;

    public GameManager Game = new();
    public MainSceneManager Main = new();

    public static Managers Manager { get { Init(); return managers; } }
    public static void Init()
    {
        GameObject go = GameObject.Find("@Managers");

        if(go == null)
        {
            go = new GameObject { name = "@Managers" };

            managers =  go.AddComponent<Managers>();
        }
    }
}
