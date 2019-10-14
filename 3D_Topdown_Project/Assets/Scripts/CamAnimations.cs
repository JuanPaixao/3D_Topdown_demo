using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnimations : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void TriggerShake()
    {
        animator.SetTrigger("camShake");
    }
}
