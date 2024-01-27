using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private Canvas coverText;

    [SerializeField] private GameObject StatusPage;
    [SerializeField] private GameObject ItemPage;
    [SerializeField] private GameObject CraftPage;
    [SerializeField] private GameObject LogPage;


    [SerializeField] private ButtonInteraction ItemBookmark;
    [SerializeField] private ButtonInteraction CraftBookmark;
    [SerializeField] private ButtonInteraction LogBookmark;
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
        if(ReferenceEquals(currentPage, StatusPage))
        {
            StatusPage.SetActive(false);
            currentPage = null;
            CloseCover();
        }
        else
        {
            OpenCover();
            (currentPage)?.SetActive(false);
            StatusPage.SetActive(true);
            currentPage = StatusPage;
        }
    }

    public void ShowItem()
    {
        if (ReferenceEquals(currentPage, ItemPage))
        {
            ItemPage.SetActive(false);
            currentPage = null;
            CloseCover();
        }
        else
        {
            OpenCover();
            (currentPage)?.SetActive(false);
            ItemPage.SetActive(true);
            currentPage = ItemPage;
        }
    }

    public void ShowCraft()
    {
        if (ReferenceEquals(currentPage, CraftPage))
        {
            CraftPage.SetActive(false);
            currentPage = null;
            CloseCover();
        }
        else
        {
            OpenCover();
            (currentPage)?.SetActive(false);
            CraftPage.SetActive(true);
            currentPage = CraftPage;
        }
    }

    public void ShowLog()
    {
        if (ReferenceEquals(currentPage, LogPage))
        {
            LogPage.SetActive(false);
            currentPage = null;
            CloseCover();
        }
        else
        {
            OpenCover();
            (currentPage)?.SetActive(false);
            LogPage.SetActive(true);
            currentPage = LogPage;
        }
    }
}
