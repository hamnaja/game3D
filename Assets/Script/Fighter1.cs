using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class Fighter1 : MonoBehaviour
{
    [SerializeField] private int MAX_HEALTH = 100;
    public int CurrentHP1;
    [SerializeField] private Fighter1 oponent;
    [SerializeField] private GameObject playerAttackObj1;
    [SerializeField] private float attackingTime = 0.5f;
    [SerializeField] private float attackingTimeCount1;
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
        CurrentHP1 = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
        mybody = GetComponent<Rigidbody>();
        playerAttackObj1.SetActive(false);
        animator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();

    }
    void Update()
    {
        if (CurrentHP1 <= 0 && currentState != FighterState.DEAD)
        {
            ENDGAME.SetActive(true);
            animator.SetTrigger("DEAD");
            Time.timeScale = 0f;
        }
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
        if (Input.GetKeyDown(KeyCode.Keypad1) && Time.time > nextFireTime)
        {
                playerAttackObj1.SetActive(false);
                nextFireTime = (int)Time.time + cooldown;
                capsule.enabled = false;
                Debug.Log("1");
                animator.SetTrigger("DEFEND");
        }
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            capsule.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)&&Time.time >nextFireTime)
        {
            KICK.Play();
                nextFireTime =(int) Time.time + cooldown;
                playerAttackObj1.SetActive(true);
                attackingTimeCount1 = attackingTime;
                Debug.Log("2");
                animator.SetTrigger("PUNCH");
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && Time.time > nextFireTime)
        {
            KICK.Play();
            nextFireTime = (int)Time.time + cooldown;
                playerAttackObj1.SetActive(true);
                attackingTimeCount1 = attackingTime;
                Debug.Log("3");
                animator.SetTrigger("KICK");
        }
        if (attackingTimeCount1 <= 0)
        {
                playerAttackObj1.SetActive(false);
        }
        attackingTimeCount1 -= Time.deltaTime;
    }
    public void CalculateHP1(int incomingDamage)
    {
        Instantiate(effect, handTransform.position, Quaternion.identity);
        Debug.Log("incomingDamage " + incomingDamage);
        CurrentHP1 += incomingDamage;
        healthBar.SetHealth(CurrentHP1);
        animator.SetTrigger("HIT");
        PUNCH.Play();

    }
}