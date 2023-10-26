using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter1 : MonoBehaviour
{
    public static float MAX_HEALTH = 1000f;
    public float health = MAX_HEALTH;
    public Fighter1 oponent;
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
                animator.SetBool("WALK", true);
        }
        else
        {
                animator.SetBool("WALK", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
                animator.SetBool("WALK_BACK", true);
        }
        else
        {
                animator.SetBool("WALK_BACK", false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
                Debug.Log("1");
                animator.SetTrigger("DEFEND");
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
                Debug.Log("2");
                animator.SetTrigger("PUNCH");
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
                Debug.Log("3");
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
    public virtual void TakeDamage1(float damage)
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