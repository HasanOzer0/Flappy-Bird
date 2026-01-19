using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 3f;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private AudioSource flySfx;
    [SerializeField] private AudioSource dieSfx;
    [SerializeField] private AudioSource pointSfx;
    private bool active=false;
    private Rigidbody2D rb2d;
    private void Start()
    {
        Time.timeScale = 1f;
        rb2d = GetComponent<Rigidbody2D>();
        deathScreen.SetActive(false);

    }
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jumpSpeed;
            flySfx.Play();
            
        }   
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Score")
        {
            FindObjectOfType <GameManager>().increaseScore();
            pointSfx.Play();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
            dieSfx.Play();
        }
        
    }
}
