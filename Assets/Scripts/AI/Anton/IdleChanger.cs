using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;
    [SerializeField] int animationCount;
    [SerializeField] float animationTimeChange;
    void Start()
    {
        InvokeRepeating("AnimationChanging", 0, animationTimeChange);
    }


    private void AnimationChanging()
    {
        int ranger = Random.Range(2, animationCount + 1);
        animator.SetInteger("pose", ranger);
    }
}
