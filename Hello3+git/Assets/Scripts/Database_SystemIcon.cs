using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Database/Icon/SystemIcon", fileName = "SystemIcon")]
public class Database_SystemIcon : ScriptableObject
{
    public Sprite emptySprite;
    public List<Marks> marks = new List<Marks>();

    /*
    void xxxGetIcon(Marks.types theType)
    {

        switch(theType)
        {
            case Marks.types.ExclamationMark:

                break;
            case Marks.types.questionMark:
                break;
            case Marks.types.vMark:
                break;
            case Marks.types.xMark:
                break;

            default:
                Debug.Log("在Database_SystemIcon找不到" + theType.ToString() + "");
                break;
        }
       
    }    
     */

    public Sprite GetIcon(Marks.types theType)
    {
        Sprite theSprite = null;
        for (int i = 0; i < marks.Count; i++)
        {
            if (theType == marks[i].type)
            {
                theSprite = marks[i].sprite;
                break;
            }
        }

        if (theSprite == null)
            return emptySprite;

        return theSprite;
    }
}
