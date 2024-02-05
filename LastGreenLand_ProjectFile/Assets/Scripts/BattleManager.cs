using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Enemy[] enemies;

    [SerializeField] private GameObject battleScreen;

    [SerializeField] private Image enemyImage;
    [SerializeField] private TMP_Text enemyName;
    [SerializeField] private Slider enemyHealthBar;

    [SerializeField] private Button attackButton;
    [SerializeField] private Button defendButton;
    [SerializeField] private Animator flash;

    private Enemy enemy;

    private bool isPlayerTurn = true;
    private bool isPlayerDefending = false;

    private float actionCooldown = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))    // 테스트용
        {
            StartBattle(0);
        }

        actionCooldown -= Time.deltaTime;

        if (isPlayerTurn)
        {
            if (actionCooldown < 0f)
            {
                attackButton.interactable = true;
                defendButton.interactable = true;
            }
        }
        else
        {
            attackButton.interactable = false;
            defendButton.interactable = false;

            if (actionCooldown < 0f)
            {
                DoEnemyAttack();
            }
        }
    }

    public void StartBattle(int index)
    {
        enemy = (Enemy)enemies[index].Clone();

        enemyImage.sprite = enemy.sprite;
        enemyName.text = enemy.name;
        enemyHealthBar.value = enemy.curHealth / enemy.maxHealth;

        isPlayerTurn = true;

        battleScreen.SetActive(true);
    }

    public void DoPlayerAttack()
    {
        Debug.Log("Player Attacked!");
        flash.SetTrigger("Flash");

        enemy.curHealth -= Mathf.Max(GameManager.Instance.strength - enemy.defense, 0f);
        if (enemy.curHealth < 0f) { enemy.curHealth = 0f; EndBattle(); }

        enemyHealthBar.value = enemy.curHealth / enemy.maxHealth;

        isPlayerTurn = false;
        actionCooldown = 1f;
    }

    public void DoPlayerDefense()
    {
        Debug.Log("Player Defended!");

        isPlayerDefending = true;
        isPlayerTurn = false;

        actionCooldown = 1f;
    }

    public void DoEnemyAttack()
    {
        Debug.Log("Enemy Attacked!");

        flash.SetTrigger("Flash");

        GameManager.Instance.currentHealth -= isPlayerDefending ? Mathf.Max(enemy.strength - GameManager.Instance.defense, 0f) : enemy.strength;
        if (GameManager.Instance.currentHealth < 0f) { GameManager.Instance.currentHealth = 0f; }

        isPlayerDefending = false;
        isPlayerTurn = true;

        actionCooldown = 1f;
    }

    public void EndBattle()
    {
        battleScreen.SetActive(false);
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