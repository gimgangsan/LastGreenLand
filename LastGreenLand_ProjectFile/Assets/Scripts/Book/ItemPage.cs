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

    private void Awake()
    {
        for (int i = 0; i < contents.Count; i++)
        {
            contents[i].UpdateInfo(contents[i].Info);
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
    }

    public PageContent GetContent(int index)
    {
        return contents[index];
    }

    public void SetItemCount(int index, int newStat)
    {
        contents[index].UpdateInfo(newStat);
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
}
