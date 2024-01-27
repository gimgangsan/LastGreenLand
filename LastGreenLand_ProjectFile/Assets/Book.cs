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

    [SerializeField] private ButtonInteraction StatusBookmark;
    [SerializeField] private ButtonInteraction ItemBookmark;
    [SerializeField] private ButtonInteraction CraftBookmark;
    [SerializeField] private ButtonInteraction LogBookmark;
    private ButtonInteraction currentBookmark;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        StatusBookmark.OnClick.AddListener(OpenCover);
        StatusBookmark.OnClick.AddListener(ShowStatus);
        ItemBookmark.OnClick.AddListener(OpenCover);
        ItemBookmark.OnClick.AddListener (ShowItem);
        CraftBookmark.OnClick.AddListener(OpenCover);
        CraftBookmark.OnClick.AddListener(ShowCraft);
        LogBookmark.OnClick.AddListener(OpenCover);
        LogBookmark.OnClick.AddListener(ShowLog);
    }

    public void CloseCover()
    {
        sprite.enabled = true;
        coverText.enabled = true;

        //make cover open next time
        StatusBookmark.OnClick.AddListener(OpenCover);
        ItemBookmark.OnClick.AddListener(OpenCover);
        CraftBookmark.OnClick.AddListener(OpenCover);
        LogBookmark.OnClick.AddListener(OpenCover);
    }

    public void OpenCover()
    {
        sprite.enabled = false;
        coverText.enabled = false;

        // make cover close next time
        StatusBookmark.OnClick.RemoveListener(OpenCover);
        ItemBookmark.OnClick.RemoveListener(OpenCover);
        CraftBookmark.OnClick.RemoveListener(OpenCover);
        LogBookmark.OnClick.RemoveListener(OpenCover);
    }

    public void HideAllPages()
    {
        StatusPage.SetActive(false);
        ItemPage.SetActive(false);
        CraftPage.SetActive(false);
        LogPage.SetActive(false);
    }

    public void ShowStatus()
    {
        StatusPage.SetActive(true);
        currentBookmark = StatusBookmark;

        StatusBookmark.OnClick.RemoveListener(ShowStatus);
        StatusBookmark.OnClick.AddListener(CloseStatus);
        StatusBookmark.OnClick.AddListener(CloseCover);
    }

    public void CloseStatus()
    {
        StatusPage.SetActive(false);
        currentBookmark = null;

        StatusBookmark.OnClick.RemoveListener(CloseStatus);
        StatusBookmark.OnClick.AddListener(ShowStatus);
    }

    public void ShowItem()
    {
        ItemPage.SetActive(true);
        currentBookmark = ItemBookmark;

        ItemBookmark.OnClick.RemoveListener(ShowItem);
        ItemBookmark.OnClick.AddListener(CloseItem);
        ItemBookmark.OnClick.AddListener(CloseCover);
    }

    public void CloseItem()
    {
        ItemPage.SetActive(false);
        currentBookmark = null;

        ItemBookmark.OnClick.RemoveListener(CloseItem);
        ItemBookmark.OnClick.AddListener(ShowItem);
    }

    public void ShowCraft()
    {
        CraftPage.SetActive(true);
        currentBookmark = CraftBookmark;

        CraftBookmark.OnClick.RemoveListener(ShowCraft);
        CraftBookmark.OnClick.AddListener(CloseCraft);
        CraftBookmark.OnClick.AddListener(CloseCover);
    }

    public void CloseCraft()
    {
        CraftPage.SetActive(false);
        currentBookmark = null;

        CraftBookmark.OnClick.RemoveListener(CloseCraft);
        CraftBookmark.OnClick.AddListener(ShowCraft);
    }

    public void ShowLog()
    {
        LogPage.SetActive(true);
        currentBookmark = LogBookmark;

        LogBookmark.OnClick.RemoveListener(ShowLog);
        LogBookmark.OnClick.AddListener(CloseLog);
        LogBookmark.OnClick.AddListener(CloseCover);
    }

    public void CloseLog()
    {
        LogPage.SetActive(false);
        currentBookmark = null;

        LogBookmark.OnClick.RemoveListener(CloseLog);
        LogBookmark.OnClick.AddListener(ShowLog);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            (currentBookmark)?.OnClick.Invoke();
        }
    }
}
