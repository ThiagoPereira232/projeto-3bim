using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int life;

    public Sprite fullHealth;
    public Sprite death;
    public Sprite health1_6;
    public Sprite health2_6;
    public Sprite health3_6;
    public Sprite health4_6;
    public Sprite health5_6;

    public Image canvasLife;

    private void Awake()
    {
        instance = this;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {

        switch (life) {
            case 0:
                canvasLife.sprite = death;
                break;
            case 1:
                canvasLife.sprite = health1_6;
                break;
            case 2:
                canvasLife.sprite = health2_6;
                break;
            case 3:
                canvasLife.sprite = health3_6;
                break;
            case 4:
                canvasLife.sprite = health4_6;
                break;
            case 5:
                canvasLife.sprite = health5_6;
                break;
            case 6:
                canvasLife.sprite = fullHealth;
                break;
        }


        if(life == 0)
        {
            Debug.Log("morreu");
        }
    }
}
