using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public GameObject flash;
    public AudioSource audioSource;

    [SerializeField] private float bulletSpawnTime = 0.4f;
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }

    void Update()
    {
        /*  
         *  Instantiate Method
         *  
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab,spawnPoint1.position,Quaternion.identity);
            Instantiate(bulletPrefab,spawnPoint2.position,Quaternion.identity);
        }
        */

        
    }

    void Fire()
    {
        Instantiate(bulletPrefab, spawnPoint1.position, Quaternion.identity);
        Instantiate(bulletPrefab, spawnPoint2.position, Quaternion.identity);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            audioSource.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            flash.SetActive(false);
        }
    }
}
