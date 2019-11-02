using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour {
    [SerializeField] private List<WaveConfig> wave_configs;
    private int starting_wave = 0;
    
    

    // Start is called before the first frame update
    void Start() {
        var current_wave = wave_configs[starting_wave];
        StartCoroutine(SpawnAllEnemiesInWave(current_wave));
    }

    void Update()
    {
        
    }
    
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave_config) {

        for (int enemy_count = 0; enemy_count < wave_config.GetNumberOfEnemies(); enemy_count++) {
            Instantiate(wave_config.GetEnemyPrefab(), wave_config.GetWaypoints()[0].transform.position,
                Quaternion.identity);

            yield return new WaitForSeconds(wave_config.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    
}
