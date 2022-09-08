using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private bool isTopdown;

    private float initialSpeed;

    private bool _isRunning;  
    private bool _isAttack;  
    private bool _canWalk;

    private Rigidbody2D rig;

    private Vector2 _direction;

    public Vector2 Direction { get => _direction; set => _direction = value; }
    public bool IsRunning { get => _isRunning; set => _isRunning = value; }
    public bool CanWalk { get => _canWalk; set => _canWalk = value; }
    public bool IsAttack { get => _isAttack; set => _isAttack = value; }
    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = Speed;
        _canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTopdown) OnInputTopDown();
        else OnInput();
        OnRun();
        OnAttack();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isAttack = true;
            Speed = 0f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsAttack = false;
            Speed = initialSpeed;
        }
    }

    void OnInputTopDown()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    void OnMove()
    {
        if (_canWalk)
        {
            rig.MovePosition(rig.position + _direction * Speed * Time.fixedDeltaTime);
        }
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = runSpeed;
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = initialSpeed;
            _isRunning = false;
        }
    }

    #endregion
}
