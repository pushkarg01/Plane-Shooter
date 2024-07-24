using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject bulletPrefab;
    public GameObject enemyFlash;
    public GameObject enemyExplostionPrefab;
    public GameObject effectPrefab;

    public GameObject coinPrefab;

    [SerializeField] private float spawnTime=1f;
    [SerializeField] private float speed = 1f;

    public float health = 10f;
    public float barSize = 1f;
    float damage = 0;

    public HealthBar healthBar;

    public AudioSource audioSource;
    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip explostionSound;

    void Start()
    {
        enemyFlash.SetActive(false);
        StartCoroutine(Shoot());
        damage = barSize / health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            audioSource.PlayOneShot(damageSound);
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject efftectDamage= Instantiate(effectPrefab,collision.transform.position, Quaternion.identity);
            Destroy(efftectDamage, 0.1f);
            if(health <= 0)
            {
                Instantiate(coinPrefab,transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(explostionSound,Camera.main.transform.position,0.5f);
                Destroy(gameObject);
                GameObject enemyExplostion = Instantiate(enemyExplostionPrefab, transform.position, Quaternion.identity);

                Destroy(enemyExplostion, 0.5f);
            }
            
            
        }
    }


    void DamageHealthBar()
    {
        if(health > 0)
        {
            health -= 1;
            barSize -= damage;
            healthBar.SetSize(barSize);
        }
    }

    void EnemyFire()
    {
        for (int i = 0; i < spawnPoints.Length; i++) {
            Instantiate(bulletPrefab, spawnPoints[i].position, Quaternion.identity);
        }
        /*
        Instantiate(bulletPrefab, spawnPoints[0].position, Quaternion.identity);
        Instantiate(bulletPrefab, spawnPoints[1].position, Quaternion.identity);
        */
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            EnemyFire();
            audioSource.PlayOneShot(bulletSound, 0.5f);
            enemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            enemyFlash.SetActive(false );
        }
    }
}
