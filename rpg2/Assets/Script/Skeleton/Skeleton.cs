using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animControl;

    private Player player;

    public float currentHealth;
    public Image healthBar;
    public float totalHealth;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            agent.SetDestination(player.transform.position);
            AnimationsSkeleton();

        }


    }

    void AnimationsSkeleton()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            // chegou no limite da distancia
            animControl.PlayAnim(2);
        }
        else
        {
            // skeleton segue o player
            animControl.PlayAnim(1);
        }

        float posX = player.transform.position.x - transform.position.x;
        if (posX > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
