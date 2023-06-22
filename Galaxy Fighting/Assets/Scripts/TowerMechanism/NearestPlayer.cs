using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestPlayer : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject player;
    [SerializeField] private float distance;
    [SerializeField] private float fixedDistance= 15;

    [Header("ShootingMechanism")]
    [SerializeField] private GameObject bombs;
    [SerializeField] private Transform firePoint;

    public Transform target;
    public float fireRate = 1f;
    public float fireCountDown = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void DistanceChecker()
    {
        distance = Vector3.Distance(tower.transform.position, player.transform.position);
    }  
    private void Shoot()
    {
        if(distance <= fixedDistance)
        {
            GameObject bulletGO = (GameObject)Instantiate(bombs, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null) bullet.Seek(target);
        }

    }
    private void Update()
    {
        DistanceChecker();
        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
       
    }
    
}
