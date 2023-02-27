using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMagicBall : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("MagicHited");
        Enemy enemy = target.GetComponent<Enemy>();
        switch (target.tag)
        {
            case "Enemy":
                Debug.Log("EnemyHited3");
                enemy.takeDamage(damage);
                Destroy(gameObject);
                break;
            case "Wall":
                Debug.Log("WallHited");
                Destroy(gameObject);
                break;
        }
    }
}
