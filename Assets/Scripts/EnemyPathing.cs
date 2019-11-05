using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    private WaveConfig wave_config;
    private List<Transform> waypoints;

    private int waypoint_index = 0;
    // Start is called before the first frame update
    void Start() {
        waypoints = wave_config.GetWaypoints();
        transform.position = waypoints[waypoint_index].transform.position;
    }

    // Update is called once per frame
    void Update() {
        Movement();
    }

    public void SetWaveConfig(WaveConfig wave_config) {
        this.wave_config = wave_config;
    }

    private void Movement() {
        if (waypoint_index <= waypoints.Count - 1) {
            var target_position = waypoints[waypoint_index].transform.position;
            var frame_movement = wave_config.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target_position, frame_movement);

            if (transform.position == target_position)
                waypoint_index++;
        }
        else {
            Destroy(gameObject);
        }
    }
}
