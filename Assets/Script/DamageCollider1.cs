using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider1 : MonoBehaviour
{

    public float damage;
    public Fighter1 fighter1;

    public void OnTriggerEnter(Collider other)
    {
        Fighter1 enemy = other.GetComponent<Fighter1>();

        if (fighter1.attacking)
        {
            if (enemy != null && enemy != fighter1)
            {
                enemy.TakeDamage1(damage);
            }
        }
    }
}