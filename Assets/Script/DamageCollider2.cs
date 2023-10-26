using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider2 : MonoBehaviour
{

    public float damage;
    public Fighter2 fighter2;
    public void OnTriggerEnter(Collider other)
    {
        Fighter2 enemy = other.GetComponent<Fighter2>();

        if (fighter2.attacking)
        {
            if (enemy != null && enemy != fighter2)
            {
                enemy.TakeDamage2(damage);
            }
        }
    }
}