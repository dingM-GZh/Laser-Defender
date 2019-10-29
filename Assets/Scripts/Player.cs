using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float move_speed = 10f;
    [SerializeField] private float x_padding = 1f, y_padding = 1f;
    private float x_min, x_max, y_min, y_max;
    
    // Start is called before the first frame update
    void Start() {
        SetMoveBoundaries();
    }

    private void SetMoveBoundaries() {
        Camera game_camera = Camera.main;
        x_min = game_camera.ViewportToWorldPoint(new Vector3(0,0,0)).x + x_padding;
        x_max = game_camera.ViewportToWorldPoint(new Vector3(1,0,0)).x - y_padding;

        y_min = game_camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + y_padding;
        y_max = game_camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - y_padding;
    }

    // Update is called once per frame
    void Update() {
        Movement();
    }

    private void Movement() {
        var delta_X = Input.GetAxis("Horizontal") * Time.deltaTime * move_speed;
        var delta_Y = Input.GetAxis("Vertical") * Time.deltaTime * move_speed;
        
        var new_X_pos = Mathf.Clamp(transform.position.x + delta_X, x_min, x_max);
        var new_Y_pos = Mathf.Clamp(transform.position.y + delta_Y, y_min, y_max);
        
        transform.position = new Vector2(new_X_pos, new_Y_pos);
    }
}
