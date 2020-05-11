using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // needed because we're using text

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public Beatscroller theBS;

    // for other scripts to easily reach gamemanager by using GameManager.instance.function()
    public static GameManager instance;

    // scoring
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    // multiplying
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThreshholds; // make it harder to get to next multiplier level

    // score text shown on screen
    public Text scoreText;
    public Text multiText;



    // rank
    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // score text start from 0
        scoreText.text = "Score: 0";

        // multiplier start from 1
        currentMultiplier = 1;
        multiText.text = "Multiplier: x1";

        var note_u = FindObjectsOfType<Noteobj_u>();
        var note_d = FindObjectsOfType<Noteobj_d>();
        var note_l = FindObjectsOfType<Noteobj_l>();
        var note_r = FindObjectsOfType<Noteobj_r>();

        totalNotes = note_u.Length + note_d.Length + note_l.Length + note_r.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.GetKeyDown("space"))
            {
                startPlaying = true;
                // tell Beatscroller it has started
                theBS.hasStarted = true;

                // set the music to play
                theMusic.Play();
            }
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                startPlaying = false;
                theBS.hasStarted = false;
                theMusic.Pause();
            }
        }
    }

    public void NoteHit()
    {
        // Debug.Log("Hit on time");

        if (currentMultiplier - 1 < multiplierThreshholds.Length) // make sure multiplier doesn't exceed the length of the threshold array
        {
            multiplierTracker++;

            // checking if multiplierTracker passed next level of threshold
            if (multiplierThreshholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        // multiplier text shown on screen
        multiText.text = "Multiplier: x" + currentMultiplier;

        // scoring
        //currentScore += scorePerNote * currentMultiplier;

        // score text shown on screen
        scoreText.text = "Score: " + currentScore;

    }


    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;

    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");

        // reset multiplier
        currentMultiplier = 1;
        multiplierTracker = 0;

        // multiplier text shown on screen
        multiText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;

    }
}