﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab; // Enemy Object to Spawn.
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;

    private int waveIndex= 1;

    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI waveNumText;
    void Awake(){
        waveNumText.text = "Wave " + waveIndex;
    }
    void Update(){
        if (countdown <= 0f) { // Loop for every wave. Could change this later... Just for testing purposes rn.
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = "Next Wave In: " + Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave() {
        waveNumText.text = "Wave " + waveIndex;
        Debug.Log("Wave" + waveIndex + "Incoming!");
        // Spawns enemies based on the current wave number. ( ie. first wave = 1 enemy, second wave = 2 enemies etc...)
        // Could change this later... 
        for (int i = 0; i < waveIndex; i++) {
             SpawnEnemy();
            yield return new WaitForSeconds(0.5f); // Spaced every .5 secs   - Might need to adjust for game feel.  
        }
        waveIndex++;
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); 
    }
}
