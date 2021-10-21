﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralQuest : MonoBehaviour
{
    public Transform[] QuestItems;
    [HideInInspector] public bool questIsActive;
    [HideInInspector] public int collectedItems;

    private void Start()
    {
        DeactivateQuest();
        collectedItems = 0;
        questIsActive = false;
    }
    public void ActivateQuest()
    {
        collectedItems = 0;
        questIsActive = true;

        // Activate objects 
        foreach (var item in QuestItems)
        {
            item.gameObject.SetActive(true);
        }
    }

    public void DeactivateQuest()
    {
        questIsActive = false;

        // Activate objects 
        foreach (var item in QuestItems)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void OnGUI()
    {
        if (questIsActive)
        {
            if(collectedItems < QuestItems.Length)
            {
                GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
                GUILayout.Label($"<color='black'><size=40>{collectedItems}/{QuestItems.Length}</size></color>");
                GUILayout.EndArea();
            }
            else
            {
                GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
                GUILayout.Label($"<color='black'><size=40>Quest completed!</size></color>");
                GUILayout.EndArea();
            }
        }
    }
}