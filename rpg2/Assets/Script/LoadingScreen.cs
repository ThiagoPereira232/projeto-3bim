using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    string[] sentences = {
        "Se voc� levar um dano voc� perde vida", 
        "Se sua vida chegar a 0 voc� morre",
        "Atacar o inimigo causa mais dano do que n�o atacar",
        "Inimigos atacam voc�, eles querem te matar mesmo",
        "Pegue cora��es para se curar",
        "Espadas s�o afiadas, elas cortam",
        "Sua armadura � de metal, se fosse de borracha seria armamole",
        "CUIDADO!!! O inimigo d� dano",
        "Se voc� morrer voc� estara morto"
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
