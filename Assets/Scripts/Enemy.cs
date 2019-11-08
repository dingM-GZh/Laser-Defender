using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 500;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer dd = other.gameObject.GetComponent<DamageDealer>();
        DestroyEnemy(dd);
    }

    private void DestroyEnemy(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        if (health <= 0)
            Destroy(gameObject);
    }
}
