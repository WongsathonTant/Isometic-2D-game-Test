using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagic : MonoBehaviour
{
    [SerializeField] private float Shootdistance;
    private Transform target;
    public Transform firePoint;
    public GameObject magicPrefab;
    public float cooldown = 0f;
    public float firerate = 1f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (cooldown < 0f)
        { 
            if (Vector2.Distance(transform.position, target.position) <= Shootdistance)
            {
                Shoot();
                cooldown = firerate;
            }
        }
        cooldown -= Time.deltaTime;
    }
    void Shoot()
    {
        Instantiate(magicPrefab, firePoint.position, firePoint.rotation);
    }
}
