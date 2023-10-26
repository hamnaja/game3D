using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehavior2 : StateMachineBehaviour
{
    public FighterState behaviorState;
    public AudioClip soundEffect;
    public float horizontalForce;
    public float verticalForce;
    protected Fighter2 fighter2;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (fighter2 == null)
        {
            fighter2 = animator.GetComponent<Fighter2>();
        }
        fighter2.currentState = behaviorState;

        fighter2.mybody.AddRelativeForce(new Vector3(0, verticalForce, 0));
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fighter2.mybody.AddRelativeForce(new Vector3(horizontalForce, 0, 0));
    }
}
