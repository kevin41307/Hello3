﻿using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Quest/QuestInformation", fileName = "QuestInformation")]
public class QuestInfomation : ScriptableObject
{
    public string title;

    public string targetName;
    public Sprite targetSprite;
    public int quantity;

    public string rewardName;
    public Sprite rewardSprite;
    public int rewardQuantity;


    [TextArea]
    public string description; 
}
