using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public static LogManager Instance = null;

    [SerializeField] private GameObject logTextContainer;
    [SerializeField] private GameObject logTextPrefab;
    [SerializeField] private int maxLogs = 13;
    List<GameObject> logs;

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

    void Start()
    {
        logs = new List<GameObject>();
    }

    public void AddLog(string text)
    {
        GameObject newLog = Instantiate(logTextPrefab, logTextContainer.transform);
        newLog.transform.SetParent(logTextContainer.transform);

        TMP_Text textComp = newLog.GetComponentInChildren<TMP_Text>();
        textComp.enableAutoSizing = false;
        textComp.fontSize = 16;
        textComp.text = text;

        RectTransform parentRect = textComp.transform.parent.GetComponent<RectTransform>();
        parentRect.sizeDelta = new Vector2(parentRect.sizeDelta.x, textComp.preferredHeight);

        logs.Insert(0, newLog);

        while (logs.Count > maxLogs)
        {
            GameObject temp = logs[logs.Count - 1];
            logs.RemoveAt(logs.Count - 1);
            Destroy(temp);
        }
    }

    public void RemoveLog(int index)
    {
        GameObject temp = logs[index];
        logs.RemoveAt(index);
        Destroy(logs[index]);
    } 

    public void FlushLog()
    {
        logs.Clear();

        foreach(GameObject child in logTextContainer.transform)
        {
            Destroy(child);
        }
    }
}
