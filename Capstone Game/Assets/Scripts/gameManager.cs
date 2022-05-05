using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Boolean for map type. Important for spawning info.
    bool centralizedDefense;

    // Wave count and difficulty modifier for each wave.
    public int wave;
    public float baseDifModifier;
    public int maxWave;

    // Current difficulty modifier to multiply enemy health and damage
    private float curDifMod;

    // Timer for break in between waves and delay for building defenses.
    public int waveTimer;
    public float buildDelay;

    // Spawner Stuff
    public GameObject spawner;
    spawnerBehavior spawnBehav;


    // Economy tracking
    public int gold;




    // Pausing and check if wave is running
    bool pause;
    bool isWaveInProgress;

    // Start is called before the first frame update
    void Start()
    {
        pause = true;
        isWaveInProgress = false;
        wave = 1;
        spawnBehav = gameObject.GetComponent<spawnerBehavior>();
        //spawner = GameObject.FindWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s") && !isWaveInProgress)
        {
            startWave(wave);
            Debug.Log("Started wave" + wave);
            isWaveInProgress = true;
        }

        if (isWaveInProgress && spawnBehav.isEverythingDead()) { EndWave(); }
    }

    // Do stuff at the end of the wave
    void startWave(int wave)
    {
        // Each wave, enemies will spawn with *curDifMod more health and do *curDifMod more damage
        curDifMod = 1 + wave * baseDifModifier;
        spawnBehav.onRoundStart(curDifMod);
    }

    // Do stuff at end of the wave
    void EndWave()
    {
        spawnBehav.onRoundEnd(wave);
        isWaveInProgress = false;
        if (wave < maxWave) wave++;

    }


    float getDifMod()
    {
        return curDifMod;
    }
}
