using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CharacterAnimation : MonoBehaviour
{
    [Header("Additional Scripts")]
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] StarterAssetsInputs saInput;
    [HideInInspector] public bool isInteracting = false;
    private bool isInteracted = false;
    Animator animator;
    bool checkedForward = false;
    bool checkedBackward = false;
    bool checkedRight = false;
    bool checkedLeft = false;
    bool isIdle = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (saInput.move == Vector2.zero && (!isIdle || fpsController.Grounded))
        {
            animator.SetInteger("Direction", 0);
            checkedForward = false;
            checkedRight = false;
            checkedLeft = false;
            checkedBackward = false;
            isIdle = true;
        }
        if (saInput.move.y > 0 && (!checkedForward || fpsController.Grounded))
        {
            animator.SetInteger("Direction", 1);
            checkedForward = true;
            checkedRight = false;
            checkedLeft = false;
            checkedBackward = false;
            isIdle = false;
        }
        if (saInput.move.y < 0 && (!checkedBackward || fpsController.Grounded))
        {
            animator.SetInteger("Direction", 2);
            checkedForward = false;
            checkedRight = false;
            checkedLeft = false;
            checkedBackward = true;
            isIdle = false;
        }
        if (saInput.move.x > 0 && (!checkedRight || fpsController.Grounded))
        {
            animator.SetInteger("Direction", 3);
            checkedForward = false;
            checkedRight = true;
            checkedLeft = false;
            checkedBackward = false;
            isIdle = false;
        }
        if (saInput.move.x < 0 && (!checkedLeft || fpsController.Grounded))
        {
            animator.SetInteger("Direction", 4);
            checkedForward = false;
            checkedRight = false;
            checkedLeft = true;
            checkedBackward = false;
            isIdle = false;
        }

        if (!fpsController.Grounded && animator.GetInteger("Direction") != 5)
        {
            animator.SetInteger("Direction", 5);
        }
        if (saInput.move.y > 0 && checkedForward && saInput.sprint)
        {
            animator.SetInteger("Direction", 6);
        }
        if (saInput.move.y < 0 && checkedBackward && saInput.sprint)
        {
            animator.SetInteger("Direction", 7);
        }
        if (saInput.move.x > 0 && checkedRight && saInput.sprint)
        {
            animator.SetInteger("Direction", 8);
        }
        if (saInput.move.x < 0 && checkedLeft && saInput.sprint)
        {
            animator.SetInteger("Direction", 9);
        }
        if (isInteracting && !isInteracted)
        {
            animator.SetBool("isAiming", true);
            isInteracted = true;
        }
        if (!isInteracting && isInteracted)
        {
            animator.SetBool("isAiming", false);
            isInteracted = false;
        }


    }



}
