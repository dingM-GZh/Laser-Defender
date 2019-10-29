using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    // configuration parameters
    [SerializeField] private float move_speed = 10f;
    [SerializeField] private float x_padding = 1f, y_padding = 1f;
    [SerializeField] private GameObject laser;
    [SerializeField] private float projectile_speed = 10f,
        projectile_firing_period = 1f;
    private float x_min, x_max, y_min, y_max;
    private Coroutine firing_coroutine;
    
    // Start is called before the first frame update
    void Start() {
        SetMoveBoundaries();
        
    }
    
    // Update is called once per frame
    void Update() {
        Movement();
        
        Fire();
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            firing_coroutine = StartCoroutine(nameof(FireContinuously));
        }

        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firing_coroutine);
        }
    }

    IEnumerator FireContinuously() {
        while (true) {
            GameObject projectile = Instantiate(laser, transform.position, Quaternion.identity); //as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectile_speed);

            yield return new WaitForSeconds(projectile_firing_period);
            //Fire();
        }
    }

    private void Movement() {
        var delta_X = Input.GetAxis("Horizontal") * Time.deltaTime * move_speed;
        var delta_Y = Input.GetAxis("Vertical") * Time.deltaTime * move_speed;
        
        var new_X_pos = Mathf.Clamp(transform.position.x + delta_X, x_min, x_max);
        var new_Y_pos = Mathf.Clamp(transform.position.y + delta_Y, y_min, y_max);
        
        transform.position = new Vector2(new_X_pos, new_Y_pos);
    }
    
    private void SetMoveBoundaries() {
        Camera game_camera = Camera.main;
        x_min = game_camera.ViewportToWorldPoint(new Vector3(0,0,0)).x + x_padding;
        x_max = game_camera.ViewportToWorldPoint(new Vector3(1,0,0)).x - y_padding;

        y_min = game_camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + y_padding;
        y_max = game_camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - y_padding;
    }
}
