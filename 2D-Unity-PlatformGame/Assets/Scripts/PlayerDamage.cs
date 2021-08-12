using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public Animator animator;
    public int PlayerHealth = 5;
    public float EnemyAttackRate = 2f;
    public float NextEnemyAttack = 0f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(Time.time  >= NextEnemyAttack)
        {
            if (PlayerHealth <= 1)
            {
                PlayerDied();
            }
            else if(PlayerHealth > 1 )
            {
                EnemyAttckFunction();
                PlayerHealth--;
                NextEnemyAttack = Time.time + 5f /EnemyAttackRate;
            } 
        }
    }

    void PlayerDied()
    {
        Debug.Log("Player DIED " + PlayerHealth);
        SceneManager.LoadScene("SampleScene");
    }
    void EnemyAttckFunction()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Player CURRENT health " + PlayerHealth);
    }
}
