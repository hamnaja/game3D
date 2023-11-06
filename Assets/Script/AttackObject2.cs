using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject2 : MonoBehaviour
{
    [SerializeField] private int attackDamage2;
    
    void Start()
    {

    }
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");

        if (other.gameObject.tag == "player1")
        {
            Fighter2 monHP = other.gameObject.GetComponent<Fighter2>();
            monHP.CalculateHP2(-attackDamage2);
            
            
        }
    }

}
