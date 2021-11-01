using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpamController : MonoBehaviour
{
    public TextMeshProUGUI spamPrompt;
    public GameObject prompt;
    public bool appear;
    // Start is called before the first frame update
    void Start()
    {
        spamPrompt = GetComponent<TextMeshProUGUI>();
        appear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(appear)
        {
            
            spamPrompt.enabled = true;
        } else
        {
           
            spamPrompt.enabled = false;
        }
        
    }

}
