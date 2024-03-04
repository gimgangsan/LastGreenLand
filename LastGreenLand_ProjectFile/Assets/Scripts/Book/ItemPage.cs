using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPage : MonoBehaviour
{
    [SerializeField] private GameObject contentsFill;
    [SerializeField] private GameObject verticalLayout;

    [SerializeField] private List<PageContent> contents;

    //scriptable object
    [SerializeField] private List<StatusFill> itemContents;

    [SerializeField] private GameObject contentsFill_int;
    [SerializeField] private Item testItemFormat;

    private void Awake()
    {
        for (int i = 0; i < contents.Count; i++)
        {
            contents[i].UpdateInfo();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            CreateContent(1, "test");
        }
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            DestroyContent(contents[0]);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            AddItem(testItemFormat,1);
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

    // =================legacy==================
    public PageContent GetContent(int index)
    {
        return contents[index];
    }

    public void SetItemCount(int index, int newStat)
    {
        contents[index].Info = newStat;
    }

    public void AddItem(int quantity, string type)
    {
        for(int i = 0; i < contents.Count; i++)
        {
            // same string, same item, only plus count
            if (string.Compare(contents[i].Type, type) == 0)
            {
                contents[i].Info += quantity;
                return;
            }
        }

        // no same item, add new content
        CreateContent(quantity, type);
    }

    public void CreateContent(int info, string type)
    {
        // contentsfill child must be one!!!
        GameObject newUI = Instantiate(contentsFill);
        newUI.transform.SetParent(verticalLayout.transform, false);
        contents.Add(new PageContent(info, type, newUI.GetComponentInChildren<TextMeshProUGUI>()));
    }

    public void UseItem(int count, string type)
    {
        for (int i = 0; i < contents.Count; i++)
        {
            // same string, same item, only minus count
            if (string.Compare(contents[i].Type, type) == 0)
            {
                if (contents[i].Info < count)
                {
                    Debug.Log("not enough quantity");
                }
                else if (contents[i].Info == count)
                {
                    DestroyContent(contents[i]);
                }
                else
                {
                    contents[i].Info -= count;
                }
                return;
            }
        }

    }

    public void DestroyContent(PageContent content)
    {
        contents.Remove(content);
        Destroy(content.UI.rectTransform.parent.gameObject);
    }
    // =================legacy==================
}
