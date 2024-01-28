using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private Canvas coverText;

    [SerializeField] private page status;
    [SerializeField] private page item;
    [SerializeField] private page craft;
    [SerializeField] private page log;

    private page currentPage = null;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
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

    public void ShowPage(page page)
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
            (currentPage)?.Toggle.ToggleOff();
            currentPage = page;
            currentPage.Page.SetActive(true);
        }
    }

    public void CloseCover()
    {
        sprite.enabled = true;
        coverText.enabled = true;
    }

    public void OpenCover()
    {
        sprite.enabled = false;
        coverText.enabled = false;
    }
}

[System.Serializable] public class page
{
    public GameObject Page;
    public ToggleInteration Toggle;
}
