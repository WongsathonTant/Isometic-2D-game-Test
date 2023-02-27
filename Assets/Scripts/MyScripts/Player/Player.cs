using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] private int hp;

    private void Start()
    {
        hp = maxHp;
    }

    public void takeDamage(int damage)
    {
        hp = hp - damage;
    }
}
