using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private string _isMovingKey = "IsMoving";
    [SerializeField] private string _horizontalKey = "Horizontal";
    [SerializeField] private string _lastHorizontalKey = "LastHorizontal";
    [SerializeField] private string _attackKey = "Attack";
    [SerializeField] private string _attackDirectionKey = "AttackDirection";

    [SerializeField] 
    [Range(0,1)]
    private float _idleAnimTransitionHardness = 0.5f;
 
    private Animator _animator;
    private PlayerInput _playerInput;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerInput = PlayerInput.Instance;

        _playerInput.AttackKeyPressed += AttackAnim;
    }

    void Update()
    {
        if (Mathf.Abs(_playerInput.HorizontalAxis) < _idleAnimTransitionHardness
            && Mathf.Abs(_playerInput.VerticalAxis) < _idleAnimTransitionHardness)
        {
            ResetMoveAnim();
            return;
        }

        MoveAnim();
    }

    private void ResetMoveAnim()
    {
        _animator.SetBool(_isMovingKey, false);
        _animator.SetFloat(_horizontalKey, 0);
    }
    
    private void MoveAnim()
    {
       _animator.SetBool(_isMovingKey, true);
       _animator.SetFloat(_horizontalKey, _playerInput.HorizontalAxis);
       _animator.SetFloat(_lastHorizontalKey, _playerInput.HorizontalAxis);
    }

    private void AttackAnim()
    {
        _animator.SetFloat(_attackDirectionKey, _playerInput.DirectionFromPlayerToMouse.x);
        _animator.SetTrigger(_attackKey);
    }
}
