using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehavior2 : StateMachineBehaviour
{
    [SerializeField] private FighterState behaviorState;
    [SerializeField] private AudioClip soundEffect;
    [SerializeField] private float horizontalForce;
    [SerializeField] private float verticalForce;
    [SerializeField] private protected Fighter2 fighter2;
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
