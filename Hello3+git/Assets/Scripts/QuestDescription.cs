using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDescription : MonoBehaviour
{
    public Transform parent;
    public Image btn;
    public Button button;
    public Image targetImage;
    public Image rewardImage;

    
    public Color32 finishColor = new Color32(0x8C, 0xE5, 0x80, 0xFF);


    private void Start()
    {

    }

    public void SetupImage(Sprite target, Sprite reward)
    {
        targetImage.sprite = target;
        rewardImage.sprite = reward;
    }
    public void SetupTartgeImage(Sprite target)
    {
        targetImage.sprite = target;
    }
    public void SetupRewardImage(Sprite reward)
    {
        rewardImage.sprite = reward;
    }


    public void OnGetBtnClicked() => QuestManager.DeleteQuest(parent.GetComponent<QuestColumn>().quest.index);

    public void OnQuestFinished()
    {
        button.interactable = true;
        btn.color = new Color32(0x8C, 0xE5, 0x80, 0xFF);
    }



}
