using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public static class Util
{
    public static IEnumerator Typeing(Text text, string str)
    {
        StringBuilder builder = new();

        for (int i = 0; i < str.Length; i++)
        {
            builder.Append(str[i]);

            text.text = $"{builder}";

            yield return new WaitForSeconds(0.01f);
        }
    }
}
