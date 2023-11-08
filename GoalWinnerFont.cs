using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalWinnerFont : MonoBehaviour
{
    public static GoalWinnerFont goalWinnerTextIntance { get; private set; }
    public GameObject goalWinnerTextObject;
    public TextMeshPro goalFontText;

    private float xPostionForText = 5;
    private void Awake()
    {
        if (goalWinnerTextIntance != null && goalWinnerTextIntance != this)
        {
            Destroy(this);
        }
        else
        {
            goalWinnerTextIntance = this;
        }
        goalWinnerTextObject.transform.localScale = new Vector3(0, 0, 0);
        goalFontText = GetComponentInChildren<TextMeshPro>();   
    }
    public void PlayerGoalLeft()
    {
        goalFontText.text = "Goal!!!";
        float zRotation = Random.Range(-25f, 25f);
        goalWinnerTextObject.transform.position = new Vector3(xPostionForText, 0, 0);
        goalWinnerTextObject.transform.Rotate(0, 0, zRotation);
        goalWinnerTextObject.transform.localScale = new Vector3(1, 1, 0);
        StartCoroutine(PlayerScored(3,goalWinnerTextObject));
    }
    public void PlayerGoalRight()
    {
        goalFontText.text = "Goal!!!";
        float zRotation = Random.Range(-25f, 25f);
        goalWinnerTextObject.transform.position = new Vector3(-xPostionForText, 0, 0);
        goalWinnerTextObject.transform.Rotate(0, 0, zRotation);
        goalWinnerTextObject.transform.localScale = new Vector3(1, 1, 0);
        StartCoroutine(PlayerScored(3, goalWinnerTextObject));
    }

    public void PlayerWinner()
    {
        goalFontText.text = "Winner!!!";
        goalWinnerTextObject.transform.position = new Vector3(0, 0, 0);
        goalWinnerTextObject.transform.Rotate(0, 0, 0);
        goalWinnerTextObject.transform.localScale = new Vector3(1, 1, 0);
    }

    private IEnumerator PlayerScored(int timer, GameObject goal)
    {
        int i = 0;
        while (i < timer)
        {
            if(i == 2)
            {
                goal.transform.localScale = new Vector3(0, 0, 0);
            }
            i++;
            yield return new WaitForSeconds(1);
        }
    }

}
