using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleHitBehaviour : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButtonDown("Fire1")) {
            animator.SetTrigger("doubleHit");
            animator.gameObject.GetComponent<Hit>().DamageHit();
        }
    }

}
