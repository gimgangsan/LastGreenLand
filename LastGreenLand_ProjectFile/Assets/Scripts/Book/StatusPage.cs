using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class StatusPage : MonoBehaviour
{
    [SerializeField] private PageContent[] contents;

    [SerializeField] StatusFill[] statContents;

    public enum ContentsIndex { hp, maxhp, strength, agility, hydration, hunger, bodyTemperature, // physical
        coldResistance, heatResistance, stealth, // environmental
        scavenging, sociability, DIY, engineering, weaponMastery } // skills

    public int ContentsCount { get; private set; }
    public static StatusPage Instance { get; private set; } //ΩÃ±€≈Ê ∆–≈œ

    private void Awake()
    {
        Instance = this;    // ΩÃ±€≈Ê ∆–≈œ
        
        ContentsCount = Enum.GetNames(typeof(ContentsIndex)).Length;
        //Debug.Log(GetContent(ContentsIndex.hp).Info);

        for (int i = 0; i < ContentsCount; i++)
        {
            contents[i].UpdateInfo();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            GetStatus(ContentsIndex.hp).Stat = 12345;
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
