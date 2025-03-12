using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public static class Util
{
    private static WaitForSecondsRealtime delay = new(0.02f);

    public static IEnumerator TypeEffecting(Text txt, string str)
    {
        StringBuilder builder = new();

        for(int i = 0; i < str.Length; i++)
        {
            yield return delay;

            builder.Append(str[i]);

            txt.text = builder.ToString();
        }
    }
}