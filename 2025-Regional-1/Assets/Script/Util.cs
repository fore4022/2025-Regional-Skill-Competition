using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public static class Util
{
    public static IEnumerator Texting(Text txt, string t)
    {
        StringBuilder b = new();

        for(int i = 0; i < t.Length; i++)
        {
            b.Append(t[i]);

            txt.text = b.ToString();

            yield return new WaitForSeconds(0.02f);
        }
    }
}
