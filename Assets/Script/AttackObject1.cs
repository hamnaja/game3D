using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject1 : MonoBehaviour
{
    [SerializeField] private int attackDamage1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //  void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log("Hit");

    //     if (other.gameObject.tag == "Enemy")
    //     {
    //         MonsterHP monHP = other.gameObject.GetComponent<MonsterHP>();
    //         monHP.CalculateHP(attackDamage);
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        
        if (other.gameObject.tag == "player2")
        {
            Fighter1 monHP = other.gameObject.GetComponent<Fighter1>();
            monHP.CalculateHP1(-attackDamage1);
            
        }
    }

}
