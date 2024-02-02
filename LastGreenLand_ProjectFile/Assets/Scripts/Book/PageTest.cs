using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTest : MonoBehaviour
{
    public GameObject ContentFill_test;
    public GameObject ContentArea;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            GameObject newContent = Instantiate(ContentFill_test);
            newContent.transform.SetParent(ContentArea.transform);
            newContent.transform.localScale = Vector3.one;
        }
    }
}
