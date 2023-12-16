using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string IsRunningParam = "isRunning";
    private const string IsDeadParam = "isDead";

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void ManageAnimations(Vector3 move)
    {
        if (move.magnitude > 0)
        {
            SetAnimatorParameter(IsRunningParam, true);
        }
        else
        {
            SetAnimatorParameter(IsRunningParam, false);
        }

        _animator.transform.forward = move.normalized;
    }

    public void PlayDeathAnimation()
    {
        SetAnimatorParameter(IsDeadParam, true);
    }

    private void SetAnimatorParameter(string paramName, bool value)
    {
        if (_animator != null)
        {
            _animator.SetBool(paramName, value);
        }
    }
}