using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{
    [SerializeField] private PageUI[] PageArray;
    [SerializeField] private int currentPageNum;

    void Awake()
    {
        foreach (PageUI _page in PageArray)
            _page.animator = _page.Page.GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ShowPage(1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowPage(2);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowPage(3);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ShowPage(4);
        }
        if(Input.GetKeyDown (KeyCode.Tab)) 
        {
            ShowPage(5);
        }
    }
    
    public void ShowPage(int targetPageNum)
    {
        StartCoroutine(_ShowPage(targetPageNum));
    }

    public IEnumerator _ShowPage(int targetPageNum)
    {
        if (currentPageNum == targetPageNum) targetPageNum = 0;

        for (; currentPageNum < targetPageNum; currentPageNum++) {
            PageArray[currentPageNum].animator.SetTrigger("Open");
            yield return new WaitForSeconds(0.2f);
        }

        for (; currentPageNum > targetPageNum; currentPageNum--) {
            PageArray[currentPageNum-1].animator.SetTrigger("Close");
            yield return new WaitForSeconds(0.2f);
        }

        currentPageNum = Mathf.Clamp(currentPageNum, 0, PageArray.Length - 1);
    }
}

[System.Serializable]
public class PageUI
{
    public GameObject Page;
    [HideInInspector] public Animator animator;
    //public ToggleInteration Toggle;
}
