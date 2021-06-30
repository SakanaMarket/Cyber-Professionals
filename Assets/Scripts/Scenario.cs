using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scenario : MonoBehaviour
{
    public string answer;
    [TextArea(0,30)]
    public string scenario;
    public int points;
    public int level;
    public GameObject scenecard;
    public GameObject infocard;
    /*public GameObject answercard;*/
    public Text answercard;

    public void ShowLevel()
    {
        if (GameObject.FindGameObjectWithTag("Scenario"))
        {
            scenecard.GetComponent<TextMeshProUGUI>().text = scenario;
            infocard.GetComponent<TextMeshProUGUI>().text = "Level " + level + ": " + points + " Points";
            /*answercard.GetComponent<TextMeshProUGUI>().text = answer;
            answercard.SetActive(false);*/
            answercard.text = answer;
            answercard.enabled = false;
        }
    }
    
}
