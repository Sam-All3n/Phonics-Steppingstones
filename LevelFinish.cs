using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public GameObject finalTeleport;
    public GameObject finalText1;
    public GameObject finalText2;
    public GameObject finalText3;
    public GameObject finalText4;
    Player plyr;
    public GameObject player;
    public Vector3 startPosition;
    public Vector3 endPosition;
    bool correct1 = false;
    bool correct2 = false;
    bool correct3 = false;
    bool correct4 = false;
    float speed;
    public GameObject finalText1StartPos;
    public GameObject finalText1EndPos;
    public GameObject finalText2StartPos;
    public GameObject finalText2EndPos;
    public GameObject finalText3StartPos;
    public GameObject finalText3EndPos;
    public GameObject finalText4StartPos;
    public GameObject finalText4EndPos;



    // Start is called before the first frame update
    void Start()
    {
        plyr = player.GetComponent<Player>();

        finalTeleport.SetActive(false);
        finalText1.SetActive(false);
        finalText2.SetActive(false);
        finalText3.SetActive(false);
        finalText4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if the correct1 boolean is true then lerp the first green grapheme from the steppingstone to the other side of the pond 
        if (correct1)
        {
            speed += 0.01f;
            finalText1.transform.position = Vector3.Lerp(startPosition, endPosition, speed);          
        }

        //if the correct2 boolean is true then lerp the second green grapheme from the steppingstone to the other side of the pond 
        if (correct2)
        {
            speed += 0.01f;
            finalText2.transform.position = Vector3.Lerp(startPosition, endPosition, speed);
        }

        //if the correct3 boolean is true then lerp the third green grapheme from the steppingstone to the other side of the pond 
        if (correct3)
        {
            speed += 0.01f;
            finalText3.transform.position = Vector3.Lerp(startPosition, endPosition, speed);
        }

        //if the correct4 boolean is true then lerp the last green grapheme from the steppingstone to the other side of the pond 
        if (correct4)
        {
            speed += 0.01f;
            finalText4.transform.position = Vector3.Lerp(startPosition, endPosition, speed);
        }
    }
  

 
    //function to set the start and end positions of the lerp for green grapheme depending on the players row number 
    public void ShowFinalStone()
    {
        if (plyr.rowNumber == 1)
        {
            finalText1.SetActive(true);
            startPosition = finalText1StartPos.transform.position;
            endPosition = finalText1EndPos.transform.position;
            correct1 = true;           
        }

        if (plyr.rowNumber == 2)
        {
            correct1 = false;
            speed = 0;
            finalText2.SetActive(true);
            startPosition = finalText2StartPos.transform.position;
            endPosition = finalText2EndPos.transform.position;
            correct2 = true;
        }


        if (plyr.rowNumber == 3)
        {
            correct2 = false;
            speed = 0;
            finalText3.SetActive(true);
            startPosition = finalText3StartPos.transform.position;
            endPosition = finalText3EndPos.transform.position;
            correct3 = true;
        }

        if (plyr.rowNumber == 4)
        {
            correct3 = false;
            speed = 0;
            finalText4.SetActive(true);
            finalTeleport.SetActive(true);
            startPosition = finalText4StartPos.transform.position;
            endPosition = finalText4EndPos.transform.position;
            correct4 = true;
        }
    }
}
