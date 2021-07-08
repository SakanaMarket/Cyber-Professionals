using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Manager : MonoBehaviour
{

    [SerializeField] private Dictionary<string, int> Teams = new Dictionary<string, int>();
    //[SerializeField] private Text response;
    [SerializeField] private float TimeToAppear = 2f;
    [SerializeField] private float TimetoDisappear;
    [SerializeField] GameObject playCanvas;
    [SerializeField] GameObject scorecard;
    [SerializeField] GameObject teaminput;
    [SerializeField] GameObject teampoints;

    private void Update()
    {

    }
    public void SetTeamNames(Text r)
    {
        int count = 0;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("TeamInput"))
        {
            string s = g.GetComponent<InputField>().text;
            if (!string.IsNullOrEmpty(s))
            {
                //Debug.Log(s);
                Teams.Add(g.GetComponent<InputField>().text.ToUpper(), 0);
            }
            else
            {
                count += 1;
            }

        }
        if (count >= 4)
        {
            EnableResponse("Invalid Teams!", r);
        }
        else
        {
            EnableResponse("Teams are Set!", r);
        }
        
    }

    public void PrintTeams(Text r)
    {
        if (Teams.Count > 0)
        {
            string All_Teams = "";
            foreach (KeyValuePair<string, int> s in Teams)
            {
                Debug.Log(s.Key + " " + s.Value);
                All_Teams += "< " + s.Key + " >";
            }
            EnableResponse(All_Teams, r);
        }
        else
        {
            EnableResponse("There Are No Teams!", r);
        }

        
    }

    public void ResetTeams(Text r)
    {
        Teams.Clear();
        EnableResponse("Teams are Cleared!", r);
    }

    public void EnableResponse(string s, Text r)
    {
        r.enabled = true;
        r.text = s;
        TimetoDisappear = Time.time + TimeToAppear;
        StartCoroutine(WaitResponse(r));
    }

    public IEnumerator WaitResponse(Text r)
    {
        yield return new WaitForSeconds(2);
        if (r.enabled && (Time.time >= TimetoDisappear))
        {
            r.enabled = false;
        }
    }

    public void Play(Text r)
    {
        if (Teams.Count > 0)
        {
            playCanvas.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCanvas").SetActive(false);
        }
        else
        {
            EnableResponse("Teams Must Be Setup!", r);
        }
    }

    public void EnableCanvas(GameObject c)
    {
        c.SetActive(true);
    }

    public void DisableCanvas(GameObject c)
    {
        c.SetActive(false);
    }

    public void UpdateScore()
    {
        //string s = scorecard.GetComponent<TextMeshProUGUI>().text;
        scorecard.transform.parent.gameObject.SetActive(!scorecard.transform.parent.gameObject.activeSelf);
        string s = "";
        foreach (KeyValuePair<string, int> item in Teams.OrderBy(key=>key.Value))
        {
            s += item.Key + ":\t" + item.Value + "\n";
        }

        scorecard.GetComponent<TextMeshProUGUI>().text = s;
    }

    public void DisableButton(Button b)
    {
        b.interactable = false;
        b.GetComponentInChildren<Text>().text = "0";
    }

    public void ReturnToLevels()
    {
        GameObject.FindGameObjectWithTag("Scenario").SetActive(false);
        playCanvas.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void RevealAnswer(Text a)
    {
        EnableResponse(a.text, a);
    }

    public void ClearInputFields(GameObject i)
    {
        i.GetComponent<TMP_InputField>().text = "";
    }
    public void ClearRegularInputFields(GameObject i)
    {
        i.GetComponent<InputField>().text = "";
    }

    public void CommunicatePoints(Text t)
    {
        string inp = teaminput.GetComponent<TMP_InputField>().text.ToUpper(); //team name
        string pts = teampoints.GetComponent<TMP_InputField>().text; // points
        int npts;
        if (Teams.ContainsKey(inp) && int.TryParse(pts, out npts))
        {
            Teams[inp] += npts;
            string s = pts + " points added to Team " + inp;
            EnableResponse(s, t);
        }
        else
        {
            EnableResponse("Invalid Team Name or Point Distribution", t);
        }


    }

    public void InverseActive(GameObject g)
    {
        g.SetActive(!g.activeSelf);
    }
}
