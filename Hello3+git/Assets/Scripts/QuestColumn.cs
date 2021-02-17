using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestColumn : MonoBehaviour
{
    public Quest quest;
    public Database_SystemIcon systemIcon;
    public Text titleUI;
    public Image processStatus;
    public GameObject prefab_DescriptionPanel;
    Transform descriptionPanel;
    bool isOpenDescriptionPanel = false;
    bool isFinished = false;
    
    string targetName;
    string description;

    private void Awake()
    {
        descriptionPanel = Instantiate(prefab_DescriptionPanel, transform.parent).GetComponent<Transform>();
        descriptionPanel.gameObject.SetActive(false);
        descriptionPanel.GetComponent<QuestDescription>().parent = this.transform;

        Setup();
    }

    public void Setup()
    {
        if (quest.info == null) return;

        targetName = quest.info.targetName;
        descriptionPanel.GetComponentInChildren<Text>().text = quest.info.description;
        titleUI.text = quest.info.title + SetupProgressBar();

        if(quest.info.rewardSprite != null )
        {
            descriptionPanel.GetComponent<QuestDescription>().SetupRewardImage(quest.info.rewardSprite);
        }
        if (quest.info.targetSprite != null)
        {
            descriptionPanel.GetComponent<QuestDescription>().SetupTartgeImage(quest.info.targetSprite);
        }
        OnProcessBarChanged();
    }

    string SetupProgressBar() => "(" + quest.currentProgressNum.ToString() + "/" + quest.info.quantity + ")";

    public void UpdateProcessBar(int delta)
    {
        if (quest.currentProgressNum + delta <= 0) return;
        quest.currentProgressNum += delta;
        quest.currentProgressNum = Mathf.Clamp(quest.currentProgressNum, 0, quest.info.quantity);

        titleUI.text = quest.info.title + SetupProgressBar();
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
        if (quest.currentProgressNum < quest.info.quantity) isFinished = false;
        else
            isFinished = true;

        if (isFinished)
        {
            processStatus.sprite = systemIcon.GetIcon(Marks.types.vMark);
            GetComponent<Image>().color = new Color32(0x8C, 0xE5, 0x80, 0xFF);

            descriptionPanel.GetComponent<QuestDescription>().OnQuestFinished();
        }
        else
        {
            processStatus.sprite = systemIcon.GetIcon(Marks.types.xMark);
            GetComponent<Image>().color = new Color32(56, 62, 63, 255);

            descriptionPanel.GetComponent<QuestDescription>().btn.color = new Color32(0xa2, 0xa2, 0xa2, 0xff);
            descriptionPanel.GetComponent<QuestDescription>().button.interactable = false;
        }
    }

    public void OnBtnClicked()
    {
        isOpenDescriptionPanel = !isOpenDescriptionPanel;
        descriptionPanel.gameObject.SetActive(isOpenDescriptionPanel);
    }


}
