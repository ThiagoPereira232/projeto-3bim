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
