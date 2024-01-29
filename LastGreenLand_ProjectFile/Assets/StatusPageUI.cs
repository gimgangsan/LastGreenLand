using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPageUI : MonoBehaviour
{
    public GameObject ContentFill_test;
    public GameObject ContentArea;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(ContentFill_test).transform.SetParent(ContentArea.transform);
        }
    }
}
