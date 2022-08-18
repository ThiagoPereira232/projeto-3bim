using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    string[] sentences = {
        "Se você levar um dano você perde vida", 
        "Se sua vida chegar a 0 você morre",
        "Atacar o inimigo causa mais dano do que não atacar",
        "Inimigos atacam você, eles querem te matar mesmo",
        "Pegue corações para se curar",
        "Espadas são afiadas, elas cortam",
        "Sua armadura é de metal, se fosse de borracha seria armamole",
        "CUIDADO!!! O inimigo dá dano",
        "Se você morrer você estara morto"
    };
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        int index = random.Next(sentences.Length);
        text.text = sentences[index];
    }

    
}
