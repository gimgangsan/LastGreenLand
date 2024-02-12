using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private int currentLocation = 0;

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
