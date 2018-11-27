using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewrite : MonoBehaviour
{
    Text txt;
    public float textDelay = 0.2F;

    // Use this for initialization 
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
    }

    private void Awake()
    {
        txt = GetComponent<Text>();
    }

    public IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        while (i < strComplete.Length)
        {
            txt.text += strComplete[i++];
            yield return new WaitForSeconds(textDelay);
        }
    }
}
