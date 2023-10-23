using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter2 : MonoBehaviour
{
    public static float MAX_HEALTH = 1000f;
    public float health = MAX_HEALTH;//ค่าพลังชีวิตปัจจุบัน 1000/1000 => 900/1000
    public string fighterName;//ตั้งชื่อให้กับผู้เล่น
    public Fighter2 oponent;//อ้างอิง Object 

    public bool enable;//กำหนดสถานะผู้เล่น 
    //ต้นเริ่มต้นให้ยืน
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
        animator.SetFloat("HEALTH", healthPercent);
        if (oponent != null)
        {
            animator.SetFloat("OPPONENT", oponent.healthPercent);
        }
        else
        {
            animator.SetFloat("OPPONENT", 1);
        }

        if (health <= 0 && currentState != FighterState.DEAD)
        {
            animator.SetTrigger("DEAD");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("WALK", true);
        }
        else
        {
            animator.SetBool("WALK", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("WALK_BACK", true);
        }
        else
        {
            animator.SetBool("WALK_BACK", false);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("1");
            animator.SetTrigger("DEFEND");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("2");
            animator.SetTrigger("PUNCH");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("3");
            animator.SetTrigger("KICK");
        }

    }

    //ดึงพลังชีวิต 1000/1000 => 950/1000
    public float healthPercent
    {
        get
        {
            return health / MAX_HEALTH;
            //1000/1000 = 1
        }
    }

    public Rigidbody body
    {
        get
        {
            return this.mybody;
        }
    }
    //ลดพลังชีวิตตาม damage ที่ได้รับ
    //1000 -50 = 950
    //1000 = 950


}