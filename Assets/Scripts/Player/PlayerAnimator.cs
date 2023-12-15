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
        if (move.magnitude <= 0)
        {
            PlayIdleAnimation();
            _animator.transform.forward = move.normalized;
        }
    }

    private void PlayRunAnimation()
    {
        _animator.SetBool("isRunning" , true);
    }
    private void PlayIdleAnimation()
    {
        _animator.SetBool("isRunning" , false);
    }
    public void PlayDeathAnimation()
    {
        _animator.SetBool("isDead" , true);
    }
}
