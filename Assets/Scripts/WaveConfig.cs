using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Config Menu")]
public class WaveConfig : ScriptableObject {
    [SerializeField] private GameObject enemy_prefab, path_prefab;

    [SerializeField] private float spawn_spacing = 0.5f, spawn_randomizer = 0.3f, move_speed = 2f;
    [SerializeField] private int enemy_count = 5;

    public GameObject GetEnemyPrefab() {
        return enemy_prefab;
    }

    public List<Transform> GetWaypoints() {
        var wave_waypoints = new List<Transform>();
        foreach (Transform waypoint in path_prefab.transform) {
            wave_waypoints.Add(waypoint);
        }
        
        return wave_waypoints;
    }

    public float GetTimeBetweenSpawns() {
        return spawn_spacing;
    }

    public float GetSpawnRandomFactor() {
        return spawn_randomizer;
    }

    public int GetNumberOfEnemies() {
        return enemy_count;
    }

    public float GetMoveSpeed() {
        return move_speed;
    }
}
