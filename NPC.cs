using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    AudioSource phoneme;
    public AudioClip fPhoneme;
    public AudioClip rPhoneme;
    public AudioClip oPhoneme;
    public AudioClip gPhoneme;
    public AudioClip eePhoneme;
    public AudioClip nPhoneme;
    public AudioClip lPhoneme;
    public AudioClip oaPhoneme;
    public AudioClip tPhoneme;
    public AudioClip blendedFrogPhonemes;
    public AudioClip blendedGreenPhonemes;
    public AudioClip blendedFloatPhonemes;
    public AudioClip WaterSplash1;
    public AudioClip WaterSplash2;
    public AudioClip WaterSplash3;
    public AudioClip WaterSplash4;
    public AudioClip WaterSplash5;
    public AudioClip CorrectSound;
    public Transform playerPos;
    public GameObject NP;
    Player plyr;
    Manager mngr;
    public GameObject player;
    public GameObject finalPos;
    public GameObject manager;
    public int NPCRow;
    Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        NPCRow = 0;
        plyr = player.GetComponent<Player>();
        phoneme = GetComponent<AudioSource>();
        mngr = manager.GetComponent<Manager>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //if NPCRow is 5 then move to the final position on other side of the pond
        if(NPCRow == 5)
        {
            NP.transform.position = finalPos.transform.position;
        }
    }

    //function that plays the correct sound effect audio 
    public void Correct()
    {
        phoneme.PlayOneShot(CorrectSound);
    }

    //function that plays 1 of the 5 splash sound effect audios chosen randomly through Random.Range
    public void Splash()
    {
        int random = Random.Range(0, 5);

        if(random == 0)
        {
            phoneme.PlayOneShot(WaterSplash1);
        }

        if (random == 1)
        {
            phoneme.PlayOneShot(WaterSplash2);
        }

        if (random == 2)
        {
            phoneme.PlayOneShot(WaterSplash3);
        }

        if (random == 3)
        {
            phoneme.PlayOneShot(WaterSplash4);
        }

        if (random == 4)
        {
            phoneme.PlayOneShot(WaterSplash5);
        }



    }

    //coroutine to wait for a set amount of time before loading the next level
    IEnumerator LoadLevelTimer ()
    {
        yield return new WaitForSeconds(40f);
        mngr.LoadScene();
    }


    private void OnTriggerStay(Collider collider)
    {
        //if the player stays in the NPC collider 
        if (collider.gameObject.tag == "Player")
        {
            //if Button.Four is pressed 
            if(OVRInput.Get(OVRInput.Button.Four))
            {
                //play sound for next row
                PlayPhoneme();
            }

            
        }
    }

    //function that updates the NPC position to the steppingstone the player is on as well as the NPCRow to the players row number if the NPCRow variable is less than the players rowNumber variable
    public void NPCMove()
    {
        if (NPCRow < plyr.rowNumber)
        {
            NPCRow = plyr.rowNumber;
            NP.transform.position = playerPos.transform.position + new Vector3(2f, 1f, 1f);
        }
    }

    //function to play the phoneme audio 
    void PlayPhoneme()
    {

        //if its the easy level then play phonemes for each grapheme in FROG depending on the row that the NPC is on 
        if (mngr.EasyLevel)
        {
            if (NPCRow == 0)
            {
                phoneme.PlayOneShot(fPhoneme);
            }

            if (NPCRow == 1)
            {
                phoneme.PlayOneShot(rPhoneme);
            }

            if (NPCRow == 2)
            {
                phoneme.PlayOneShot(oPhoneme);
            }

            if (NPCRow == 3)
            {
                phoneme.PlayOneShot(gPhoneme);
            }

            if (NPCRow == 4)
            {
             
            }

            if (NPCRow == 5)
            {
                //blended phoneme play
                phoneme.PlayOneShot(blendedFrogPhonemes);
                StartCoroutine(LoadLevelTimer());
            }
        }

        //if its the medium level then play phonemes for each grapheme in GREEN depending on the row that the NPC is on
        if (mngr.MediumLevel)
        {
            if (NPCRow == 0)
            {
                phoneme.PlayOneShot(gPhoneme);

            }

            if (NPCRow == 1)
            {
                phoneme.PlayOneShot(rPhoneme);
            }

            if (NPCRow == 2)
            {
                phoneme.PlayOneShot(eePhoneme);
            }

            if (NPCRow == 3)
            {
                phoneme.PlayOneShot(nPhoneme);
            }

            if (NPCRow == 4)
            {
            
            }

            if (NPCRow == 5)
            {
                //blended phoneme play
                phoneme.PlayOneShot(blendedGreenPhonemes);
                StartCoroutine(LoadLevelTimer());
            }
        }

        //if its the hard level then play phonemes for each grapheme in FLOAT depending on the row that the NPC is on
        if (mngr.HardLevel)
        {
            if (NPCRow == 0)
            {
                phoneme.PlayOneShot(fPhoneme);
               

            }

            if (NPCRow == 1)
            {
                phoneme.PlayOneShot(lPhoneme);
            }

            if (NPCRow == 2)
            {
                phoneme.PlayOneShot(oaPhoneme);
            }

            if (NPCRow == 3)
            {
                phoneme.PlayOneShot(tPhoneme);
            }

            if (NPCRow == 4)
            {
                
            }

            if (NPCRow == 5)
            {
                //blended phoneme play
                phoneme.PlayOneShot(blendedFloatPhonemes);

                
            }
        }
    }
}
