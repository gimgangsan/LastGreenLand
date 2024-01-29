using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{
    [SerializeField] private GameObject TopCover;

    [SerializeField] private PageUI status;
    [SerializeField] private PageUI item;
    [SerializeField] private PageUI craft;
    [SerializeField] private PageUI log;
    [SerializeField] private PageUI map;

    private PageUI currentPage = null;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ShowStatus();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowItem();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowCraft();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ShowLog();
        }
        if(Input.GetKeyDown (KeyCode.Tab)) 
        {
            ShowMap();
        }
    }

    public void ShowStatus()
    {
        ShowPage(status);
    }

    public void ShowItem()
    {
        ShowPage(item);
    }

    public void ShowCraft()
    {
        ShowPage(craft);
    }

    public void ShowLog()
    {
        ShowPage(log);
    }

    public void ShowMap()
    {
        ShowPage(map);
    }

    public void ShowPage(PageUI page)
    {
        if (ReferenceEquals(currentPage, page))
        {
            currentPage.Page.SetActive(false);
            currentPage = null;
            CloseCover();
        }
        else
        {
            OpenCover();
            (currentPage)?.Page.SetActive(false);
            //(currentPage)?.Toggle.ToggleOff();
            currentPage = page;
            currentPage.Page.SetActive(true);
        }
    }

    public void CloseCover()
    {
        TopCover.SetActive(true);
    }

    public void OpenCover()
    {
        TopCover.SetActive(false);
    }
}

[System.Serializable]
public class PageUI
{
    public GameObject Page;
    //public ToggleInteration Toggle;
}
