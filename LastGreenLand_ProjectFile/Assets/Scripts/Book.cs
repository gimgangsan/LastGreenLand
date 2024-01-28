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

    public void ShowStatus()
    {
        if(ReferenceEquals(currentPage, status))
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
            currentPage = status;
            currentPage.Page.SetActive(true);
        }
    }

    public void ShowItem()
    {
        if (ReferenceEquals(currentPage, item))
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
            currentPage = item;
            currentPage.Page.SetActive(true);
        }
    }

    public void ShowCraft()
    {
        if (ReferenceEquals(currentPage, craft))
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
            currentPage = craft;
            currentPage.Page.SetActive(true);
        }
    }

    public void ShowLog()
    {
        if (ReferenceEquals(currentPage, log))
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
            currentPage = log;
            currentPage.Page.SetActive(true);
        }
    }
}

[System.Serializable] public class page
{
    public GameObject Page;
    public ToggleInteration Toggle;
}
