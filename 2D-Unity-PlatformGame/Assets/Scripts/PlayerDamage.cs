using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
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
                EnemyDied();
            }
            else if(PlayerHealth > 1 )
            {
                EnemyAttckFunction();
                PlayerHealth--;
                NextEnemyAttack = Time.time + 5f /EnemyAttackRate;
            } 
        }
    }

    void EnemyDied()
    {
        Debug.Log("Player DIED " + PlayerHealth);
        SceneManager.LoadScene("SampleScene");
    }
    void EnemyAttckFunction()
    {
        Debug.Log("Player CURRENT health " + PlayerHealth);
    }
}
