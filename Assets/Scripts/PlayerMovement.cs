using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    float minX, maxX,minY,maxY;
    [SerializeField] private float padding=0.8f;
    [SerializeField] private GameObject explostion;
    [SerializeField] private GameObject effectPrefab;


    public float health = 20f;
    float barFillAmount = 1f;
    float damage = 0;

    public HealthUIPlayer playerhealtbar;
    public CoinCount coinCountScript;

    public GameController gameController;

    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;


    void Start()
    {
        FindBound();
        damage =barFillAmount/health;
    }

    void FindBound()
    {
        Camera cam = Camera.main;
        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)).y - padding;
    }


    void Update()
    {
        /*   
           float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime *speed;
           float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

           float newXPos = Mathf.Clamp(transform.position.x + deltaX,minX,maxX);
           float newYPos = Mathf.Clamp(transform.position.y + deltaY,minY,maxY);

           transform.position= new Vector2(newXPos,newYPos);
        */

        if (Input.GetMouseButton(0))
        {
            Vector2 newPos =  Camera.main.ScreenToWorldPoint(new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
            transform.position = Vector2.Lerp(transform.position,newPos,speed*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
            DamagePlayerHealth();
            Destroy(collision.gameObject);
            GameObject efftectDamage = Instantiate(effectPrefab, collision.transform.position, Quaternion.identity);
            Destroy(efftectDamage, 0.1f);
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound,Camera.main.transform.position ,0.5f);
                gameController.GameOver();
                Destroy(gameObject);

                GameObject blast = Instantiate(explostion, transform.position, Quaternion.identity);
                Destroy(blast, .5f);
            }
           
        }
        if(collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound, 0.5f);
            Destroy(collision.gameObject) ;
            coinCountScript.AddCount();
        }

    }

    void DamagePlayerHealth()
    {
        if (health > 0)
        {
            health -= 1;
            barFillAmount -= damage;
            playerhealtbar.SetAmount(barFillAmount);
        }
    }
}
