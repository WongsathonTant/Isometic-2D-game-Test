using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] private int hp;
    [SerializeField] private int damage;
    public GameObject deathEffect;

    private void Start()
    {
        hp = maxHp;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (target.tag == "Player")
        {
            player.takeDamage(damage);
        }
    }

    public void takeDamage(int damage)
    {
        hp = hp - damage;
        if(hp < 0)
        {
            Instantiate(deathEffect, gameObject.transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
