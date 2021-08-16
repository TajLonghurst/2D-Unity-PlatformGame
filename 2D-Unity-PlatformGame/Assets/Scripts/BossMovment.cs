using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMovment : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float moveSpeedChange;

    Rigidbody2D rb2d;

    private float dazeTime;
    public float startDazedTime;

    public Animator animator;
    public int maxHealth = 0;
    int currentHealth;
    public Text Healthtext;

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

        Healthtext.text =  "" + currentHealth;
            if (currentHealth  <= 100)
            {
                Healthtext.text = "Dead";
            }


        if (currentHealth < 900)
        {
            moveSpeedChange = 5;

        }
        else
        {
            moveSpeedChange = 1;
        }

        if (dazeTime <= 0 )
        {
            moveSpeed = moveSpeedChange;
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
            if (currentHealth < 900)
            {
                animator.SetBool("Running", true);
                rb2d.velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(6, 6);
            }
            else
            {
                animator.SetBool("Walking", true);
                rb2d.velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(5, 5);
            }
            
        }
        else if (transform.position.x > player.position.x)
        {
            if (currentHealth < 900)
            {
                animator.SetBool("Running", true);
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(-6, 6);
            }
            else
            {
                animator.SetBool("Walking", true);
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(-5, 5);
            }

        }
    }
    
    
    public void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
        animator.SetBool("Walking", false);
    }

    public void BosstakeDamage( int damage)
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

        Debug.Log("Boss Killed Killed");
        
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        this.enabled = false;
    }
}
