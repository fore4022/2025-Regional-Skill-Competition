using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public static class TTT
{
    public static IEnumerator Typeing(Text text, string te)
    {
        StringBuilder builder = new();


        for(int i =0; i < te.Length; i++)
        {
            builder.Append(te[i]);

            text.text = $"{builder.ToString()}";

            yield return new WaitForSeconds(0.02f);
        }
    }
}