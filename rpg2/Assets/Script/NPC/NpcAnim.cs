using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnim : MonoBehaviour
{
    [SerializeField] private int animT;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("transition", animT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
