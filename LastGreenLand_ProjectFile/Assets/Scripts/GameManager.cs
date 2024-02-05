using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private int currentLocation = 0;
    public float maxHealth = 100;
    public float currentHealth = 100;
    public float strength = 20;
    public float defense = 10;

    void Awake()
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

    public void MoveLocation(int targetLocation)
    {
        if (currentLocation != targetLocation)
        {
            currentLocation = targetLocation;
            Debug.Log("Move to location #" + currentLocation);
        }
        else
        {
            Debug.Log("Already at location #" + currentLocation);
        }
    }
}
