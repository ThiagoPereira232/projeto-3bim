using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance;
    public string tag;

    private void Awake()
    {
        instance = this;
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
