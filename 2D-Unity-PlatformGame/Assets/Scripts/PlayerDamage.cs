using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public Animator animator;
    
    [SerializeField]
    Hearts Healthscript;
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
            if (Healthscript.health <= 0)
            {
                PlayerDied();
            }
            else if(Healthscript.health > 1 )
            {
                EnemyAttckFunction();
                Healthscript.health--;
                NextEnemyAttack = Time.time + 5f /EnemyAttackRate;
            } 
        }
    }

    void PlayerDied()
    {
        Debug.Log("Player DIED " + Healthscript.health);
        SceneManager.LoadScene("SampleScene");
    }
    void EnemyAttckFunction()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Player CURRENT health " + Healthscript.health);
    }
}
