using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int rowNumber;
    Manager manager;
    OVRScreenFade fader;
    public GameObject codeManager;
    public Vector3 lastCorrectPosition;
    public GameObject Playr;
    bool row1FirstTime;
    bool row2FirstTime;
    bool row3FirstTime;

    // Start is called before the first frame update
    void Start()
    {
        rowNumber = 0;
        manager = codeManager.GetComponent<Manager>();
        lastCorrectPosition = manager.initialSpawn.transform.position;
        row1FirstTime = true;
        row2FirstTime = true;
        row3FirstTime = true;
        Playr.transform.position = lastCorrectPosition;
        fader = GetComponent<OVRScreenFade>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    //when this function is called the screen fades out, the player is teleported to the last correct steppingstone and then the screen fades back in 
    public void LastCorrectRespawn()
    {
        fader.FadeOut();
        Playr.transform.position = lastCorrectPosition + new Vector3(0f, 4.5f, 0f);
        fader.FadeIn();

    }


    //when this function is called the last correct position variable is set depending on which row the player is currently on 
    public void RespawnSetup()
    {
        if (rowNumber == 0)
        {
            lastCorrectPosition = manager.RespawnPoints[0];
        }

        if (rowNumber == 1)
        {
            lastCorrectPosition = manager.RespawnPoints[1];
        }

        if (rowNumber == 2)
        {
            lastCorrectPosition = manager.RespawnPoints[2];
        }

        if (rowNumber == 3)
        {
            lastCorrectPosition = manager.RespawnPoints[3];
        }

        if (rowNumber == 4)
        {
            lastCorrectPosition = manager.RespawnPoints[4];
        }

    }


    //when this function is called if the correct conditions are fulfilled the next row of steppingstones will become visible
    public void RowShow()
    {
        if (rowNumber == 1 && row1FirstTime)
        {
            manager.Row1();
            row1FirstTime = false;
        }

        if (rowNumber == 2 && row2FirstTime)
        {
            manager.Row2();
            row2FirstTime = false;
        }

        if (rowNumber == 3 && row3FirstTime)
        {
            manager.Row3();
            row3FirstTime = false;
        }
    }

}
