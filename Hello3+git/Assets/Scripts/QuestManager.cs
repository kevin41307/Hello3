using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    static QuestManager instance;

    public GameObject questGrids;
    public QuestInventory myQuest;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }



}
