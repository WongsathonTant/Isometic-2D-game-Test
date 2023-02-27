using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemyFollow : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Distance;

    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
    }
}
