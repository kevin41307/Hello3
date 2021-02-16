using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Quest/QuestInformation", fileName = "QuestInformation")]
public class QuestInfomation : ScriptableObject
{
    public string title;
    public string targetName;
    public int quantity;

    [TextArea]
    public string description; 
}
