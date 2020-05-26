using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SteppingStone : MonoBehaviour
{
    public string grapheme;
    public TextMeshPro graphemeText;
    public int row;
    bool selectedStone = false;
    bool correctStone = false;
    Player plyr;
    NPC npc;
    Manager mngr;
    LevelFinish lvlfin;
    public GameObject bee;
    public GameObject player;
    public GameObject manager;
    public GameObject stone;
    public GameObject teleportPoint;
    public GameObject text;
    bool firstTime = true;
    bool firstTime2 = true;

    // Start is called before the first frame update
    void Start()
    {
        graphemeText.text = grapheme;
        teleportPoint.SetActive(true);
        plyr = player.GetComponent<Player>();
        npc = bee.GetComponent<NPC>();
        mngr = manager.GetComponent<Manager>();
        lvlfin = manager.GetComponent<LevelFinish>();
        CorrectStones();
        text.transform.position = stone.transform.position + new Vector3(2.6f, 4f, -2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (plyr.rowNumber > row && correctStone == false)
        {
            DestroyStone();
        }

        //if correctStone is true
        if (correctStone)
        {
            //if the players rownumber is greater than the row the steppingstone is located on 
            if (plyr.rowNumber > row)
            {
                //rotate 180 degrees on the y axis
                text.transform.rotation = Quaternion.Euler(0, 180, 0);
                text.transform.position = stone.transform.position + new Vector3(-3f, 4f, -2f);

            }
            else
            {
                //set rotation to 0
                text.transform.rotation = Quaternion.Euler(0, 0, 0);
                text.transform.position = stone.transform.position + new Vector3(2.6f, 4f, -2f);
            }
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        //if the player enters the steppingstones collider then hide the grapheme text and teleport point also update the players rownumber, playerpos variable and the steppingstones boolean selectedStone to true
        if (collider.gameObject.tag == "Player")
        {
            graphemeText.text = " ";
            teleportPoint.SetActive(false);
            plyr.rowNumber = row;
            selectedStone = true;
            npc.playerPos = stone.transform;

            //if the steppingstone is both selected and a correct steppingstone then update the correct respawn point, move the npc to the steppingstone and show the next row of steppingstones
            if (correctStone && selectedStone)
            {

                
                CorrectRespawnSet();
                npc.NPCMove();
                plyr.RespawnSetup();
                plyr.RowShow();
                
                //if its the first time the player has teleported to this correct steppingstone then show a green version of the grapheme text flying over to the otherside of the pond
                if(firstTime2)
                {
                    lvlfin.ShowFinalStone();
                    firstTime2 = false;
                }

                //if its the first time the player has teleported to this correct steppingstone then play the correct sound effect 
                if (firstTime && plyr.rowNumber != 5)
                {
                    npc.Correct();
                    firstTime = false;
                }
            }
            else
            {
                //if the steppingstone is incorrect then hide the stone, play the splash sound effect and respawn the player at the last correct steppingstone
                DestroyStone();
                npc.Splash();
                plyr.LastCorrectRespawn();
            }
        }


    }


    private void OnTriggerExit(Collider collider)
    {
        //when the player exits the steppingstones collider show the grapheme text, set the teleport point to active and set the selectedStone boolean to false
        if (collider.gameObject.tag == "Player")
        {
            graphemeText.text = grapheme;
            selectedStone = false;
            teleportPoint.SetActive(true);

            
        }
    }

    //function that hides the steppingstone 
    void DestroyStone()
    {       
        stone.SetActive(false);        
    }

    //function to set the correct respawn points value for each item in the RespawnPoints array depending on the row the correct steppingstone is located on 
    void CorrectRespawnSet()
    {
        if (row == 1)
        {
            mngr.RespawnPoints[1] = stone.transform.position;
        }

        if (row == 2)
        {
            mngr.RespawnPoints[2] = stone.transform.position;
        }

        if (row == 3)
        {
            mngr.RespawnPoints[3] = stone.transform.position;
        }

        if (row == 4)
        {
            mngr.RespawnPoints[4] = stone.transform.position;
        }

    }


    //function that sets the correct steppingstones through their grapheme text
    void CorrectStones()
    {
        //if it is the easy level and grapheme text is F,R,O or G set correctStone boolean to true
        if (mngr.EasyLevel)
        {
            if (graphemeText.text == "F")
            {
                correctStone = true;
            }

            if (graphemeText.text == "R")
            {
                correctStone = true;
            }

            if (graphemeText.text == "O")
            {
                correctStone = true;
            }

            if (graphemeText.text == "G")
            {
                correctStone = true;
            }

            if (graphemeText.text == "")
            {
                correctStone = true;
            }
        }

        //if it is the medium level and grapheme text is G,R,EE or N then set correctStone boolean to true
        if(mngr.MediumLevel)
        {
            if (graphemeText.text == "G")
            {
                correctStone = true;
            }

            if (graphemeText.text == "R")
            {
                correctStone = true;
            }

            if (graphemeText.text == "EE")
            {
                correctStone = true;
            }

            if (graphemeText.text == "N")
            {
                correctStone = true;
            }

            if (graphemeText.text == "")
            {
                correctStone = true;
            }
        }

        //if it is the hard level and grapheme text is F,L,OA or T set the correctStone boolean to true
        if(mngr.HardLevel)
        {
            if (graphemeText.text == "F")
            {
                correctStone = true;
            }

            if (graphemeText.text == "L")
            {
                correctStone = true;
            }

            if (graphemeText.text == "OA")
            {
                correctStone = true;
            }

            if (graphemeText.text == "T")
            {
                correctStone = true;
            }

            if (graphemeText.text == "")
            {
                correctStone = true;
            }
        }
    }



}
