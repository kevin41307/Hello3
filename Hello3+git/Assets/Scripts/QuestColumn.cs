using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestColumn : MonoBehaviour
{
    public QuestInfomation questInfomation;
    public Database_SystemIcon systemIcon;
    public Text titleUI;
    public Image processStatus;
    public GameObject prefab_DescriptionPanel;
    Transform descriptionPanel;
    bool isOpenDescriptionPanel = false;
    bool isFinished = false;
    
    int requestQuantity = 0;
    int currentProgressNum = 0;
    string targetName;
    string description;

    private void Awake()
    {
        descriptionPanel = Instantiate(prefab_DescriptionPanel, transform.parent).GetComponent<Transform>();
        descriptionPanel.gameObject.SetActive(false);

        Setup();
    }

    private void OnEnable()
    {
        OnProcessBarChanged();
    }

    private void Start()
    {
        
    }

    public void Setup()
    {
        requestQuantity = questInfomation.quantity;
        targetName = questInfomation.targetName;
        descriptionPanel.GetComponentInChildren<Text>().text = questInfomation.description;
        titleUI.text = questInfomation.title + SetupProgressBar();
        OnProcessBarChanged();
    }

    string SetupProgressBar()
    {
        string progress = "(" + currentProgressNum.ToString() + "/" + requestQuantity + ")";
        
        return progress;
    }

    public void UpdateProcessBar(int delta)
    {
        if (currentProgressNum + delta <= 0) return;
        currentProgressNum += delta;
        currentProgressNum = Mathf.Clamp(currentProgressNum, 0, requestQuantity);


        titleUI.text = questInfomation.title + SetupProgressBar();
        OnProcessBarChanged();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            UpdateProcessBar(1);
        }
    }

    void OnProcessBarChanged()
    {
        if (currentProgressNum < requestQuantity) isFinished = false;
        else
            isFinished = true;

        if (isFinished) processStatus.sprite = systemIcon.GetIcon(Marks.types.vMark);
        else processStatus.sprite = systemIcon.GetIcon(Marks.types.xMark);
    }

    public void OnBtnClicked()
    {
        isOpenDescriptionPanel = !isOpenDescriptionPanel;
        descriptionPanel.gameObject.SetActive(isOpenDescriptionPanel);
    }
}
