using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Wave count and difficulty modifier for each wave.
    public int wave;
    public int baseDifModifier;
    public int maxWave;

    // Current difficulty modifier to multiply enemy health and damage
    private float curDifMod;

    // Timer for break in between waves and delay for building defenses.
    public int waveTimer;
    public float buildDelay;

    // Economy tracking
    public int gold;


    // Pausing
    bool pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        wave = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Do stuff at the end of the wave
    void startWave(int wave)
    {
        // Each wave, enemies will spawn with *curDifMod more health and do *curDifMod more damage
        curDifMod = 1 + wave / baseDifModifier;
    }

    // Do stuff at end of the wave
    void EndWave()
    {

    }

    // Spawn Enemies
    void SpawnEnemy(gameObject enemy)
    {

    }

    float getDifMod()
    {
        return curDifMod;
    }
}
