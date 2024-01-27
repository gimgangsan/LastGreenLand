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
        CraftBookmark.OnClick.AddListener(OpenCover);
        LogBookmark.OnClick.AddListener(OpenCover);
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
        StatusBookmark.OnClick.RemoveListener(ShowStatus);
        StatusBookmark.OnClick.AddListener(CloseStatus);
        StatusBookmark.OnClick.AddListener(CloseCover);
    }

    public void CloseStatus()
    {
        StatusPage.SetActive(false);
        StatusBookmark.OnClick.RemoveListener(CloseStatus);
        StatusBookmark.OnClick.AddListener(ShowStatus);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCover();
        }
    }
}
