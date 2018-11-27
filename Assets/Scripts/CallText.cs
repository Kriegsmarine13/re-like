using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallText : MonoBehaviour
{
    public string objectDescription;
    private Camera mainCamera;

    // Use this for initialization 
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame 
    void Update()
    {

    }

    public void TypewriteText()
    {
        var typewriter = mainCamera.GetComponentInChildren<Typewrite>();
        StartCoroutine(typewriter.AnimateText(objectDescription));
    }
}