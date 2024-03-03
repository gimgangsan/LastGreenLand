using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class StatusPage : MonoBehaviour
{
    [SerializeField] private PageContent[] contents;

    [SerializeField] private StatusFormat[] initialFormat;
    [SerializeField] private GameObject contentsFill_int;
    [SerializeField] private GameObject verticalLayout;
    private StatusFill[] statContents;

    public enum ContentsIndex { hp, maxhp, strength, agility, hydration, hunger, bodyTemperature, // physical
        coldResistance, heatResistance, stealth, // environmental
        scavenging, sociability, DIY, engineering, weaponMastery } // skills

    public int ContentsCount { get; private set; }
    public static StatusPage Instance { get; private set; } //ΩÃ±€≈Ê ∆–≈œ

    private void Awake()
    {
        Instance = this;    // ΩÃ±€≈Ê ∆–≈œ
        
        ContentsCount = Enum.GetNames(typeof(ContentsIndex)).Length;
        statContents = new StatusFill[ContentsCount];
        //Debug.Log(GetContent(ContentsIndex.hp).Info);

        for (int i = 0; i < ContentsCount; i++)
        {
            contents[i].UpdateInfo();
        }
        CreateContent();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("lol");
            GetStatus(ContentsIndex.hp).Stat = 2222;
        }
    }

    public void CreateContent()
    {
        for (int i = 0; i < initialFormat.Length; i++)
        {
            GameObject newContent = Instantiate(contentsFill_int);
            newContent.transform.SetParent(verticalLayout.transform, false);
            StatusFill script = newContent.GetComponent<StatusFill>();
            script.ContentsFormat = initialFormat[i];
            statContents[i] = script;
        }
    }

    public StatusFill GetStatus(ContentsIndex index)
    {
        return statContents[(int)index];
    }

    public PageContent GetContent(ContentsIndex index)
    {
        return contents[(int)index];
    }

    public void SetStatus(ContentsIndex index, int newStat)
    {
        contents[(int)index].Info = newStat;
    }
}

[Serializable]
public class PageContent
{
    [SerializeField] private int info;
    public int Info
    {
        get {  return info; }
        set
        {
            info = value;
            UpdateInfo();
        }
    }
        
    public string Type;
    public TextMeshProUGUI UI;

    public PageContent(int info, string type, TextMeshProUGUI uI)
    {
        Info = info;
        Type = type;
        UI = uI;
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        UI.text = Type + " " + Info;
    }
}
