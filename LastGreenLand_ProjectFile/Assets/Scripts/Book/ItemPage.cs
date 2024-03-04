using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPage : MonoBehaviour
{
    [SerializeField] private GameObject verticalLayout;
    [SerializeField] private List<StatusFill> itemContents;

    [SerializeField] private GameObject contentsFill_int;
    [SerializeField] private Item testItemFormat;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            AddItem(testItemFormat,1);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            UseItem(testItemFormat,1);
        }
    }

    public StatusFill GetFromInventory(int index)
    {
        if (index > itemContents.Count)
        {
            Debug.Log("out of inventory index");
            return null;
        }
        return itemContents[index];
    }

    public void UseItem(Item itemInfo, int quantity)
    {
        for (int i = 0; i < itemContents.Count; i++)
        {
            // same string, same item, only minus count
            if (string.Compare(itemContents[i].ContentsFormat.Info, itemInfo.Name) == 0)
            {
                if (itemContents[i].Stat < quantity)
                {
                    Debug.Log("not enough quantity");
                }
                else if (itemContents[i].Stat == quantity)
                {
                    DestroyContent(itemContents[i]);
                }
                else
                {
                    itemContents[i].Stat -= quantity;
                }
                return;
            }
        }
    }

    public void DestroyContent(StatusFill content)
    {
        itemContents.Remove(content);
        Destroy(content.gameObject);
    }

    public void AddItem(Item itemInfo, int quantity)
    {
        for (int i = 0; i < itemContents.Count; i++)
        {
            // 같은 아이템
            if (string.Compare(itemContents[i].ContentsFormat.Info, itemInfo.Name) == 0)
            {
                itemContents[i].Stat += quantity;
                return;
            }
        }
        StatusFormat newItemFormat = new StatusFormat(itemInfo.Sprite, itemInfo.Name, itemInfo.Describtion, 1);

        CreateContent(newItemFormat);
    }

    public void CreateContent(StatusFormat format)
    {
        GameObject newUI = Instantiate(contentsFill_int);
        newUI.transform.SetParent(verticalLayout.transform, false);
        StatusFill script = newUI.GetComponent<StatusFill>();
        script.ApplyContentsFormat(format);
        itemContents.Add(script);
    }
}
