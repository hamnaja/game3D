using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter2 : MonoBehaviour
{
    public static float MAX_HEALTH = 1000f;
    public float health = MAX_HEALTH;
    public Fighter2 oponent;
    public FighterState currentState = FighterState.IDLE;
    public Rigidbody mybody;
    protected Animator animator;
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (health <= 0 && currentState != FighterState.DEAD)
        {
            animator.SetTrigger("DEAD");
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("WALK", true);
        }
        else
        {
            animator.SetBool("WALK", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("WALK_BACK", true);
        }
        else
        {
            animator.SetBool("WALK_BACK", false);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("4");
            animator.SetTrigger("DEFEND");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("5");
            animator.SetTrigger("PUNCH");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("6");
            animator.SetTrigger("KICK");
        }
        
    }
    public bool defending
    {
        get
        {
            return currentState == FighterState.DEFEND;
        }
    }

    public bool attacking => currentState == FighterState.KICK
            || currentState == FighterState.PUNCH;
    public virtual void TakeDamage2(float damage)
    {
        if (defending)
        {
            damage *= 0.2f;
        }

        if (health >= damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        if (health > 0)
        {
            Debug.Log("7");
            animator.SetTrigger("HIT");
        }
    }
}