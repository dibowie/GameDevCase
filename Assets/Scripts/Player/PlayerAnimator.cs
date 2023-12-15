using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    public void ManageAnimations(Vector3 move)
    {
        if (move.magnitude > 0)
        {
            PlayRunAnimation();
            _animator.transform.forward = move.normalized;
        }
        else
        {
            PlayIdleAnimation();
        }
    }

    private void PlayRunAnimation()
    {
        _animator.Play("Run");
    }
    private void PlayIdleAnimation()
    {
        _animator.Play("Idle");
    }
    private void PlayDeathAnimation()
    {
        _animator.Play("Death");
    }
}
