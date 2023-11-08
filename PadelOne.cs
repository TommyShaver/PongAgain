using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PadelOne : MonoBehaviour
{
    [SerializeField] float _padelSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _moveDirection = Vector2.zero;
   

    public InputAction _playerOneControls;
    //Start Logic ===================================================
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();  
    }

    private void OnEnable()
    {
        _playerOneControls.Enable();
    }
    private void OnDisable()
    {
        _playerOneControls.Disable();
    }

    private void Update()
    {
        _moveDirection = _playerOneControls.ReadValue<Vector2>();
        _rb.velocity = new Vector2(_moveDirection.x * _padelSpeed, _moveDirection.y * _padelSpeed);
    }
  
}   
