using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    [SerializeField] private Dictionary<string, int> Teams = new Dictionary<string, int>();
    [SerializeField] private Text response;
    [SerializeField] private float TimeToAppear = 2f;
    [SerializeField] private float TimetoDisappear;

    private void Update()
    {
        if (response.enabled && (Time.time >= TimetoDisappear))
        {
            response.enabled = false;
        }
    }
    public void SetTeamNames()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("TeamInput"))
        {
            string s = g.GetComponent<InputField>().text;
            if (!string.IsNullOrEmpty(s))
            {
                //Debug.Log(s);
                Teams.Add(g.GetComponent<InputField>().text, 0);
            }
            
        }
        EnableResponse("Teams are Set!");
    }

    public void PrintTeams()
    {
        foreach (KeyValuePair<string, int> s in Teams)
        {
            Debug.Log(s.Key + " " + s.Value);
        }
    }

    public void ResetTeams()
    {
        Teams.Clear();
        EnableResponse("Teams are Cleared!");
    }

    public void EnableResponse(string s)
    {
        response.enabled = true;
        response.text = s;
        TimetoDisappear = Time.time + TimeToAppear;
    }
}
