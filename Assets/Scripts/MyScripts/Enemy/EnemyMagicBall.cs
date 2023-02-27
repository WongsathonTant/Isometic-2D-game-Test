using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagicBall : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float speed;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y) * speed;

        float rot = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("Hited");
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        switch (target.tag)
        {
            case "Player":
                Debug.Log("PlayerHited");
                player.takeDamage(damage);
                Destroy(gameObject);
                break;
            case "Wall":
                Debug.Log("WallHited");
                Destroy(gameObject);
                break;
        }
    }
}
