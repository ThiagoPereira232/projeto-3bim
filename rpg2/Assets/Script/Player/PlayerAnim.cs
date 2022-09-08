using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Attack settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;

    private Player player;
    private Animator anim;

    public bool isHitting;
    private float recoveryTime = 1.5f;
    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
        OnAttackAnim();

        if (isHitting)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }
    }

    #region Movement
    
    void OnMove()
    {
        Debug.Log(player.Direction.sqrMagnitude);

        if (player.Direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 1);
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.Direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);

        }

        if (player.Direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
     
    }

    void OnRun()
    {
        if(player.IsRunning && player.Direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion

    #region Life
    public void OnHit(){
        if (!isHitting)
        {
            anim.SetTrigger("hit");
            FindObjectOfType<GameController>().life--;
            isHitting = true;
        }
    }
    #endregion

    #region Attack

    void OnAttackAnim()
    {
        if (player.IsAttack)
        {
            anim.SetInteger("transition", 4);
        }
    }

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemyLayer);
        if(hit != null)
        {
            hit.GetComponentInChildren<AnimationControl>().OnHit();
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }


    #endregion
}
