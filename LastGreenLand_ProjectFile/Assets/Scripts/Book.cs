using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private Canvas coverText;

    [SerializeField] private GameObject statusPage;
    [SerializeField] private GameObject itemPage;
    [SerializeField] private GameObject craftPage;
    [SerializeField] private GameObject logPage;

    [SerializeField] private ToggleInteration statusBookmark;
    [SerializeField] private ToggleInteration itemBookmark;
    [SerializeField] private ToggleInteration craftBookmark;
    [SerializeField] private ToggleInteration logBookmark;

    private GameObject currentPage = null;

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
        if(ReferenceEquals(currentPage, statusPage))
        {
            statusPage.SetActive(false);
            currentPage = null;
            CloseCover();
        }
        else
        {
            OpenCover();
            (currentPage)?.SetActive(false);
            InitializeSelectedBookmarkColor();
            statusPage.SetActive(true);
            currentPage = statusPage;
        }
    }

    public void ShowItem()
    {
        if (ReferenceEquals(currentPage, itemPage))
        {
            itemPage.SetActive(false);
            currentPage = null;
            CloseCover();
        }
        else
        {
            OpenCover();
            (currentPage)?.SetActive(false);
            InitializeSelectedBookmarkColor();
            itemPage.SetActive(true);
            currentPage = itemPage;
        }
    }

    public void ShowCraft()
    {
        if (ReferenceEquals(currentPage, craftPage))
        {
            craftPage.SetActive(false);
            currentPage = null;
            CloseCover();
        }
        else
        {
            OpenCover();
            (currentPage)?.SetActive(false);
            InitializeSelectedBookmarkColor();
            craftPage.SetActive(true);
            currentPage = craftPage;
        }
    }

    public void ShowLog()
    {
        if (ReferenceEquals(currentPage, logPage))
        {
            logPage.SetActive(false);
            currentPage = null;
            CloseCover();
        }
        else
        {
            OpenCover();
            (currentPage)?.SetActive(false);
            InitializeSelectedBookmarkColor();
            logPage.SetActive(true);
            currentPage = logPage;
        }
    }

    public void InitializeSelectedBookmarkColor()
    {
        if(ReferenceEquals(currentPage, statusPage))
        {
            statusBookmark.ToggleOff();
        }
        else if(ReferenceEquals(currentPage, itemPage))
        {
            itemBookmark.ToggleOff();
        }
        else if(ReferenceEquals(currentPage, craftPage))
        {
            craftBookmark.ToggleOff();
        }
        else if(ReferenceEquals(currentPage, logPage))
        {
            logBookmark.ToggleOff();
        }
    }
}
