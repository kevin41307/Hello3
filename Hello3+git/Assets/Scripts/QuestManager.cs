using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    static QuestManager instance;

    public GameObject questRoot;
    public GameObject listsRoot;
    public QuestInventory myQuest;

    public GameObject questColumn;
    public QuestInfomation testInfo;
    List<QuestColumn> columns = new List<QuestColumn>();

    bool isOpen = false;
    /*
    public List<Quest> quests = new List<Quest>();
    public Quest quest;
    public TestInpector testInpector;
    public TestInpector[] ins = new TestInpector[10];


    [System.Serializable]
    public class TestInss
    {
        public int aa;
        public int bb;
        public Quest qq;
        public TestInpector inbb;

    }
    public TestInss inss;
    public List<TestInss> testInsses = new List<TestInss>();
    */

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void Start()
    {
        isOpen = questRoot.activeSelf;
        RefreshList();
    }


    public static void RefreshList()
    {
        for (int i = 0; i < instance.listsRoot.transform.childCount; i++)
        {
            if (instance.listsRoot.transform.childCount == 0)
                break;
            Destroy(instance.listsRoot.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.myQuest.questList.Count; i++)
        {
            if (instance.myQuest.questList[i].info == null) continue;
            QuestColumn qc = Instantiate(instance.questColumn, instance.listsRoot.transform).GetComponent<QuestColumn>();
            qc.questInfomation = instance.myQuest.questList[i].info;
            qc.Setup();
        }
    }

    public static void AddQuest(QuestInfomation questInfo)
    {
        Quest quest = new Quest(instance.testInfo);
        bool insert = false;
        for (int i = 0; i < instance.myQuest.questList.Count; i++)
        {
            if (instance.myQuest.questList[i].info != null) continue;
            else
            {
                instance.myQuest.questList[i] = quest;
                insert = true;
                break;
            }
        }
        
        if ( !insert )
            instance.myQuest.questList.Add(quest);
        RefreshList();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            QuestManager.AddQuest(testInfo);
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            OnCloseBtnClicked();
        }
    }

    public void OnCloseBtnClicked()
    {
        isOpen = !isOpen;
        questRoot.SetActive(isOpen);
    }

}
