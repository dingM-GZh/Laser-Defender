using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour {
    [SerializeField] private List<WaveConfig> wave_configs;
    [SerializeField] private int starting_wave = 0;
    [SerializeField] private bool looping = false;
    

    // Start is called before the first frame update
    IEnumerator Start() {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves() {
        for (int index = starting_wave; index < wave_configs.Count; index++) {
            var current_wave = wave_configs[index];
            yield return StartCoroutine(SpawnAllEnemiesInWave(current_wave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave_config) {

        for (int enemy_count = 0; enemy_count < wave_config.GetNumberOfEnemies(); enemy_count++) {
            var new_enemy = Instantiate(wave_config.GetEnemyPrefab(), wave_config.GetWaypoints()[0].transform.position,
                Quaternion.identity);

            new_enemy.GetComponent<EnemyPathing>().SetWaveConfig(wave_config);
            
            yield return new WaitForSeconds(wave_config.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    
}
