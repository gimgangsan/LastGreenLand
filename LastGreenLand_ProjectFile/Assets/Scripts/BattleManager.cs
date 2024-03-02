using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static StatusPage;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance = null;

    public Enemy[] enemies;

    [SerializeField] private GameObject battleScreen;

    [SerializeField] private Image enemyImage;
    [SerializeField] private TMP_Text enemyName;
    [SerializeField] private Slider enemyHealthBar;

    [SerializeField] private Button attackButton;
    [SerializeField] private Button defendButton;
    [SerializeField] private Animator flash;

    private Enemy enemy;

    public Battle_Encounter ongoingEncounter;  // 진행 중인 전투가 있음을 알리기 위해

    private bool isPlayerDefending = false;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))    // 테스트용
        {
            StartBattle(0);
        }
    }

    public void StartBattle(int index)
    {
        enemy = (Enemy)enemies[index].Clone();

        enemyImage.sprite = enemy.sprite;
        enemyName.text = enemy.name;
        enemyHealthBar.value = enemy.curHealth / enemy.maxHealth;

        attackButton.interactable = true;
        defendButton.interactable = true;

        battleScreen.SetActive(true);
    }

    public void DoPlayerAttack()
    {
        Debug.Log("Player Attacked!");
        flash.SetTrigger("Flash");

        enemy.curHealth -= Mathf.Max(StatusPage.Instance.GetContent(ContentsIndex.strength).Info - enemy.defense, 0f);
        if (enemy.curHealth < 0f) { enemy.curHealth = 0f; EndBattle(); }

        enemyHealthBar.value = enemy.curHealth / enemy.maxHealth;

        StartCoroutine("DoEnemyAttack");
    }

    public void DoPlayerDefense()
    {
        Debug.Log("Player Defended!");

        isPlayerDefending = true;

        StartCoroutine("DoEnemyAttack");
    }

    public IEnumerator DoEnemyAttack()
    {
        attackButton.interactable = false;
        defendButton.interactable = false;

        yield return new WaitForSeconds(1f);

        Debug.Log("Enemy Attacked!");
        flash.SetTrigger("Flash");

        StatusPage.Instance.GetContent(ContentsIndex.hp).Info -= Mathf.CeilToInt(enemy.strength); //isPlayerDefending ? Mathf.Max(enemy.strength - GameManager.Instance.defense, 0f) : enemy.strength; //StatusPage에 defense가 없음
        StatusPage.Instance.GetContent(ContentsIndex.hp).Info = Mathf.Max(StatusPage.Instance.GetContent(ContentsIndex.hp).Info, 0);

        yield return new WaitForSeconds(1f);

        isPlayerDefending = false;
        attackButton.interactable = true;
        defendButton.interactable = true;
    }

    public void EndBattle()
    {
        battleScreen.SetActive(false);
        ongoingEncounter.Complete();
    }
}

[System.Serializable]
public class Enemy : ICloneable
{
    public string name;
    public Sprite sprite;

    public float maxHealth;
    public float curHealth;
    public float strength;
    public float defense;

    public object Clone()
    {
        Enemy enemy = new Enemy();

        enemy.name = name;
        enemy.sprite = sprite;

        enemy.maxHealth = maxHealth;
        enemy.curHealth = curHealth;
        enemy.strength = strength;
        enemy.defense = defense;

        return enemy;
    }
}