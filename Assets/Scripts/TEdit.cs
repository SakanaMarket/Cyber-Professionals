using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEdit : MonoBehaviour
{
    [SerializeField] Text t;
    public bool b;

    void Update()
    {
        StartCoroutine(ChangeText());
    }

    public IEnumerator ChangeText()
    {
        yield return new WaitForSeconds(2);
        StopAllCoroutines();
        if (b)
        {
            b = false;
            t.text = "CP@CC: >";
        }
        else
        {
            b = true;
            t.text = "CP@CC: >_";
        }
    }
}
