using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public static LogManager Instance = null;

    [SerializeField] private TMP_Text logText;
    [SerializeField] private int maxLogs = 13;
    List<string> logs;

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
        logs = new List<string>();
    }

    public void AddLog(string text)
    {
        logs.Insert(0, text);

        while (logs.Count > maxLogs)
        {
            logs.RemoveAt(logs.Count - 1);
        }

        UpdateLogText();
    }

    public void RemoveLog(int index)
    {
        logs.RemoveAt(index);

        UpdateLogText();
    } 

    public void FlushLog()
    {
        logs.Clear();
        logText.SetText("");

        UpdateLogText();
    }

    private void UpdateLogText()
    {
        StringBuilder sb = new StringBuilder();

        foreach(var str in logs)
        {
            sb.Append("- " + str + "\n");
        }

        logText.SetText(sb.ToString());
    }
}
