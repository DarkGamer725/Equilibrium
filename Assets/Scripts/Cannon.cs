using Microsoft.Win32.SafeHandles;
using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootingSpot;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletCooldown;
    [SerializeField] float burstCooldown;
    [SerializeField] int burstCount;
    [SerializeField] Switch trigger;

    bool activated;

    float timer;
    int bulletsShot;

    Vector3 shootingDirection;

    private void Start()
    {
        activated = true;
        StartCoroutine(CannonSequence());
        trigger.RegisterOnActivate(Trigger);
        //timer = burstCooldown;
    }

    private void Update()
    {
        /*timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Shoot();
            ++bulletsShot;
            timer = bulletCooldown;
            if (bulletsShot >= burstCount)
            {
                timer = burstCooldown;
                bulletsShot = 0;
            }
        }*/
    }

    private void Trigger(bool activate)
    {
        activated = !activate;
        if (activated)
        {
            StartCoroutine(CannonSequence());
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shootingSpot.position, shootingSpot.rotation);
        bulletInstance.GetComponent<Bullet>().SetSpeed(bulletSpeed);
        bulletInstance.transform.SetParent(transform, true);
    }

    IEnumerator CannonSequence()
    {
        while (activated)
        {
            for (int counter = 0; counter < burstCount; ++counter)
            {
                if (activated) 
                { 
                    Shoot();
                }
                yield return new WaitForSeconds(bulletCooldown);
            }
            yield return new WaitForSeconds(burstCooldown);
        }
    }
}

