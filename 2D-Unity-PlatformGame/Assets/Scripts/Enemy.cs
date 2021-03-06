using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    private float dazeTime;
    public float startDazedTime;

    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    public SoundManeger SoundManeger;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (dazeTime <= 0 )
        {
            moveSpeed = 3;
        }
        else
        {
            moveSpeed = 0;
            dazeTime -= Time.deltaTime;
        }

        float distPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distPlayer < agroRange)
        {
           ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            animator.SetBool("IsRunningBool", true);
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            animator.SetBool("IsRunningBool", true);
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }
    
    
    public void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
        animator.SetBool("IsRunningBool", false);
    }

    public void takeDamage( int damage)
    {
        animator.SetTrigger("Hurt");
        dazeTime = startDazedTime;
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }

    }
    void Die() 
    {
        
        SoundManeger.EnemyDeathSound.Play();
        
        animator.SetBool("IsDead", true);

        StopChasingPlayer();

        Debug.Log("Enemy Killed");
        
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        this.enabled = false;
    }
}
