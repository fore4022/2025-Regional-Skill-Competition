using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers Instance;
    public GameManager game = new();
    public static Managers Manager { get { Init();  return Instance; } }
    public static GameManager Game { get { return Manager.game; } }
    public static void Init()
    {
        GameObject go = GameObject.Find("@Manager");

        if(go == null)
        {
            go = new GameObject { name = "@Manager" };

            Instance = go.AddComponent<Managers>();
            DontDestroyOnLoad(Instance);
        }
    }
}
