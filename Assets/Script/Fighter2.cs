using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class Fighter2 : MonoBehaviour
{
    [SerializeField] private int MAX_HEALTH = 100;
    public int CurrentHP2;
    [SerializeField] private Fighter2 oponent;
    [SerializeField] private GameObject playerAttackObj2;
    [SerializeField] private float attackingTime = 0.5f;
    [SerializeField] private float attackingTimeCount2;
    public FighterState currentState = FighterState.IDLE;
    public Rigidbody mybody;
    [SerializeField] private protected Animator animator;
    [SerializeField] private int cooldown = 1;
    [SerializeField] private int nextFireTime = 0;
    [SerializeField] private HealthBar healthBar;
    public CapsuleCollider capsule;
    [SerializeField] private GameObject ENDGAME;
    [SerializeField] private AudioSource PUNCH;
    [SerializeField] private AudioSource KICK;
    [SerializeField] private GameObject effect;

    [SerializeField] private Transform handTransform;
    void Start()
    {
        
        ENDGAME.SetActive(false);
        CurrentHP2 = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
        mybody = GetComponent<Rigidbody>();
        playerAttackObj2.SetActive(false);
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        if (CurrentHP2 <= 0 && currentState != FighterState.DEAD)
        { 
            ENDGAME.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.G) && Time.time > nextFireTime)
        {
            nextFireTime = (int)Time.time + cooldown;
            capsule.enabled = false;
            Debug.Log("Collider.enabled = " + capsule);
            animator.SetTrigger("DEFEND");
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            capsule.enabled = true;
        }
            
        if (Input.GetKeyDown(KeyCode.H) && Time.time > nextFireTime)
        {
            KICK.Play();
            nextFireTime = (int)Time.time + cooldown;
            playerAttackObj2.SetActive(true);
            attackingTimeCount2 = attackingTime;
            Debug.Log("5");
            animator.SetTrigger("PUNCH");
        }
        if (Input.GetKeyDown(KeyCode.J)&& Time.time > nextFireTime)
        {
            KICK.Play();
            nextFireTime = (int)Time.time + cooldown;
            playerAttackObj2.SetActive(true);
            attackingTimeCount2 = attackingTime;
            Debug.Log("6");
            animator.SetTrigger("KICK");
        }
        if (attackingTimeCount2 <= 0)
        {
            playerAttackObj2.SetActive(false);
        }
        attackingTimeCount2 -= Time.deltaTime;
        
    }
    public void CalculateHP2(int incomingDamage)
    {
        Instantiate(effect, handTransform.position, Quaternion.identity);
        Debug.Log("incomingDamage " + incomingDamage);
        CurrentHP2 += incomingDamage;
        healthBar.SetHealth(CurrentHP2);
        animator.SetTrigger("HIT");
        PUNCH.Play();
        
    }
}