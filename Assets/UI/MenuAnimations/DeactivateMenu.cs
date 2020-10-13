using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateMenu : StateMachineBehaviour
{
    //in start menu, set menu to inactive when it slides out of the screen
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.SetActive(false);
    }
}
