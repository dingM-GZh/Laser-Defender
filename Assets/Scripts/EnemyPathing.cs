using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    [SerializeField] private WaveConfig wave_config;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float move_speed = 2f;

    private int waypoint_index = 0;
    // Start is called before the first frame update
    void Start() {
        waypoints = wave_config.GetWaypoints();
        transform.position = waypoints[waypoint_index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoint_index <= waypoints.Count - 1) {
            var target_position = waypoints[waypoint_index].transform.position;
            var frame_movement = move_speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,target_position, frame_movement);

            if (transform.position == target_position)
                waypoint_index++;
        }
        else {
            Destroy(gameObject);
        }
    }
}
