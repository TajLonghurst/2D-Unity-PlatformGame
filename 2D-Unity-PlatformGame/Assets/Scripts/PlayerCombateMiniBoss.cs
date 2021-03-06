using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombateMiniBoss : MonoBehaviour
{

    public Animator animator;

    public Transform AttackPoint;
    public float AttackRange = 0.5f; 
    public LayerMask enemyLayers;
    public int attackDamage = 100;
    public float AttackRate = 2f;
    private float NextAttackTime = 0f;

    public SoundManeger SoundManeger;

    // Update is called once per frame
    void Update()
    {
        if(Time.time  >= NextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                NextAttackTime = Time.time + 1f / AttackRate;
            }
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");  
        SoundManeger.SwordSound.Play();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
          enemy.GetComponent<MiniBossEnemy>().takeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected() 
    {
        if(AttackPoint == null)
        return;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);   
    }
}

