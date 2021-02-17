using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Quest
{
    public QuestInfomation info;
    public int currentProgressNum = 0;


    public Quest()
    {

    }
    public Quest(QuestInfomation _info)
    {
        info = _info;
    }

    public void Setup(QuestInfomation _info)
    {
        info = _info;
    }
}
