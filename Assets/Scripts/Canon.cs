using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float speed;
    [SerializeField] private float interval;
    private bool _canShoot;
    private bool _busyShooting;
    private bool _keepShooting;

    public void Fire()
    {
        _keepShooting = true;
        if (!_busyShooting)
        {
            StartCoroutine(Shooting());
        }
        if (_canShoot)
        {
            Shoot();
        }
    }

    private IEnumerator Shooting()
    {
        _busyShooting = true;
        while (_keepShooting)
        {
            _canShoot = true;
            yield return null;
            _canShoot = false;
            yield return new WaitForSeconds(interval);
            _keepShooting = false;
            yield return null;
        }
        _busyShooting = false;
    }

    private void Shoot()
    {
        var p = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        p.AddForce(spawnPoint.forward * speed, ForceMode.VelocityChange);
    }
}