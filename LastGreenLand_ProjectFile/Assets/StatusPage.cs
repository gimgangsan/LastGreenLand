using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class StatusPage : MonoBehaviour
{
    [SerializeField] private PageContent[] contents;
    public enum ContentsIndex { hp, maxhp, strength, agility, hydration, hunger, bodyTemperature, // physical
                                coldResistance, heatResistance, stealth, // environmental
                                scavengingSkill, sociability, DIY, mechanicalKnowledge, weaponProdiciency } // skills

    public int ContentsCount { get; private set; }

    //// physical
    //private int hp;
    //private int maxhp;
    //private int strength;
    //private int agility;
    //private int naturalHeal;

    //// environmental
    //private int coldResistance;
    //private int heatResistance;
    //private int stealth;

    //// skills
    //private int scavengingSkill;
    //private int sociability;
    //private int stressResilience;
    //private int DIY;
    //private int mechanicalKnowledge;
    //private int weaponProficiency;

    private void Awake()
    {
        ContentsCount = Enum.GetNames(typeof(ContentsIndex)).Length;
        //Debug.Log(GetContent(ContentsIndex.hp).Info);

        for(int i = 0; i < ContentsCount; i++)
        {
            contents[i].UpdateInfo(contents[i].Info);
        }
    }

    public PageContent GetContent(ContentsIndex index)
    {
        return contents[(int)index];
    }

    public void SetStatus(ContentsIndex index, int newStat)
    {
        contents[(int)index].UpdateInfo(newStat);
    }
}

[Serializable]
public class PageContent
{
    public int Info;
    public string Type;
    public TextMeshProUGUI UI;
    
    public void UpdateInfo(int newStat)
    {
        UI.text = Type + " " + Info;
    }
}
