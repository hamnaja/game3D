using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehavior : StateMachineBehaviour
{
    public FighterState behaviorState;
    public AudioClip soundEffect;
    public float horizontalForce;
    public float verticalForce;
    protected Fighter1 fighter1;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fighter1 == null)
        {
            fighter1 = animator.GetComponent<Fighter1>();
        }
        fighter1.currentState = behaviorState;

        fighter1.mybody.AddRelativeForce(new Vector3(0, verticalForce, 0));
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fighter1.mybody.AddRelativeForce(new Vector3(horizontalForce,0,0));
        
    }
}
