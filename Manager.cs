using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Vector3[] SpawnPoints1;
    public GameObject[] Graphemes1;
    public Vector3[] SpawnPoints2;
    public GameObject[] Graphemes2;
    public Vector3[] SpawnPoints3;
    public GameObject[] Graphemes3;
    public Vector3[] SpawnPoints4;
    public GameObject[] Graphemes4;
    public Vector3[] RespawnPoints;
    int randomNumber;
    public GameObject initialSpawn;
    public bool EasyLevel;
    public bool MediumLevel;
    public bool HardLevel;
    public string nextScene;
    



    // Start is called before the first frame update
    void Start()
    {

        //set one of the level booleans to true depending on the name of the active scene 
        if(SceneManager.GetActiveScene().name == "Easy Prototype")
        {
            EasyLevel = true;
            MediumLevel = false;
            HardLevel = false;

        }

        if(SceneManager.GetActiveScene().name == "Medium Prototype")
        {
            EasyLevel = false;
            MediumLevel = true;
            HardLevel = false;
        }

        if(SceneManager.GetActiveScene().name == "Hard Prototype")
        {
            EasyLevel = false;
            MediumLevel = false;
            HardLevel = true;
        }

        //set up the RespawnPoints array 
        RespawnPoints = new Vector3[5];
        RespawnPoints[0] = initialSpawn.transform.position;

        //call the RandomiseGraphemes function
        RandomiseGraphemes();

        //hide row 2
        foreach (GameObject grapheme in Graphemes2)
        {
            grapheme.SetActive(false);
        }

        //hide row 3
        foreach (GameObject grapheme in Graphemes3)
        {
            grapheme.SetActive(false);

        }

        //hide row 4
        foreach (GameObject grapheme in Graphemes4)
        {
            grapheme.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    //function to load the next level
    public void LoadScene()
    { SceneManager.LoadScene(nextScene); }

    //function to show row 2
    public void Row1()
    {
        foreach (GameObject grapheme in Graphemes2)
        {
            grapheme.SetActive(true);
        }
    }

    //function to show row 3
    public void Row2()
    {
        foreach (GameObject grapheme in Graphemes3)
        {
            grapheme.SetActive(true);
        }
    }

    //function to show row 4
    public void Row3()
    {
        foreach (GameObject grapheme in Graphemes4)
        {
            grapheme.SetActive(true);
        }
    }


    //function to randomise the placement of the graphemes on each row using Random.Range
    void RandomiseGraphemes()
    {
        randomNumber = Random.Range(0, 3);
        SpawnPoints1 = new Vector3[3];
        SpawnPoints1[0] = Graphemes1[0].transform.position;
        SpawnPoints1[1] = Graphemes1[1].transform.position;
        SpawnPoints1[2] = Graphemes1[2].transform.position;

        SpawnPoints2 = new Vector3[3];
        SpawnPoints2[0] = Graphemes2[0].transform.position;
        SpawnPoints2[1] = Graphemes2[1].transform.position;
        SpawnPoints2[2] = Graphemes2[2].transform.position;

        SpawnPoints3 = new Vector3[3];
        SpawnPoints3[0] = Graphemes3[0].transform.position;
        SpawnPoints3[1] = Graphemes3[1].transform.position;
        SpawnPoints3[2] = Graphemes3[2].transform.position;

        SpawnPoints4 = new Vector3[3];
        SpawnPoints4[0] = Graphemes4[0].transform.position;
        SpawnPoints4[1] = Graphemes4[1].transform.position;
        SpawnPoints4[2] = Graphemes4[2].transform.position;

        if (randomNumber == 0)
        {
            Graphemes1[0].transform.position = SpawnPoints1[2];
            Graphemes1[1].transform.position = SpawnPoints1[1];
            Graphemes1[2].transform.position = SpawnPoints1[0];

            Graphemes2[0].transform.position = SpawnPoints2[2];
            Graphemes2[1].transform.position = SpawnPoints2[1];
            Graphemes2[2].transform.position = SpawnPoints2[0];

            Graphemes3[0].transform.position = SpawnPoints3[2];
            Graphemes3[1].transform.position = SpawnPoints3[1];
            Graphemes3[2].transform.position = SpawnPoints3[0];

            Graphemes4[0].transform.position = SpawnPoints4[2];
            Graphemes4[1].transform.position = SpawnPoints4[1];
            Graphemes4[2].transform.position = SpawnPoints4[0];
        }

        if (randomNumber == 1)
        {
            Graphemes1[0].transform.position = SpawnPoints1[1];
            Graphemes1[1].transform.position = SpawnPoints1[0];
            Graphemes1[2].transform.position = SpawnPoints1[2];

            Graphemes2[0].transform.position = SpawnPoints2[1];
            Graphemes2[1].transform.position = SpawnPoints2[0];
            Graphemes2[2].transform.position = SpawnPoints2[2];

            Graphemes3[0].transform.position = SpawnPoints3[1];
            Graphemes3[1].transform.position = SpawnPoints3[0];
            Graphemes3[2].transform.position = SpawnPoints3[2];

            Graphemes4[0].transform.position = SpawnPoints4[1];
            Graphemes4[1].transform.position = SpawnPoints4[0];
            Graphemes4[2].transform.position = SpawnPoints4[2];
        }

        if (randomNumber == 2)
        {
            Graphemes1[0].transform.position = SpawnPoints1[0];
            Graphemes1[1].transform.position = SpawnPoints1[2];
            Graphemes1[2].transform.position = SpawnPoints1[1];

            Graphemes2[0].transform.position = SpawnPoints2[0];
            Graphemes2[1].transform.position = SpawnPoints2[2];
            Graphemes2[2].transform.position = SpawnPoints2[1];

            Graphemes3[0].transform.position = SpawnPoints3[0];
            Graphemes3[1].transform.position = SpawnPoints3[2];
            Graphemes3[2].transform.position = SpawnPoints3[1];

            Graphemes4[0].transform.position = SpawnPoints4[0];
            Graphemes4[1].transform.position = SpawnPoints4[2];
            Graphemes4[2].transform.position = SpawnPoints4[1];
        }
    }
}
