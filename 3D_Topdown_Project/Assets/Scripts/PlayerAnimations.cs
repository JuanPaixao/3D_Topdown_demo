using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void IsShooting(bool isShooting)
    {
        animator.SetBool("isShooting", isShooting);
    }
    public void IsMoving(bool isMoving)
    {
        animator.SetBool("isMoving", isMoving);
    }
    public void IsDead()
    {
        animator.SetTrigger("Dead");
    }
}
