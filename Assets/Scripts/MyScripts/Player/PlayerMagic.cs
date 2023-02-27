using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{
    public Image cooldownImage;
    public Transform firePoint;
    public GameObject magicPrefab;
    public float cooldown = 0f;
    public float firerate = 1f;

    void Update()
    {
        if(cooldownImage.fillAmount > 0)
        {
            cooldownImage.fillAmount = cooldown;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        cooldown -= Time.deltaTime;
    }
    public void Shoot()
    {
        if (cooldown <= 0f)
        {
            cooldownImage.fillAmount = 1;
            Instantiate(magicPrefab, firePoint.position, firePoint.rotation);
            cooldown = firerate;
        }
    }
}
