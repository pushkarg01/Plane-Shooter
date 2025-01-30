using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    #region Bullet Variables

    public GameObject bulletPrefab, flash;

    public Transform spawnPoint1, spawnPoint2;

    public AudioSource audioSource;

    [SerializeField] private float bulletSpawnTime = 0.4f;
    #endregion

    #region Start Logic
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }
    #endregion

    #region Firing Coroutine
    void Fire()
    {
        Instantiate(bulletPrefab, spawnPoint1.position, Quaternion.identity, transform);
        Instantiate(bulletPrefab, spawnPoint2.position, Quaternion.identity, transform);
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
 #endregion

}
