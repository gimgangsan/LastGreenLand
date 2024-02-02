using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{
    [SerializeField] PageUI[] PageArray;
    [SerializeField] int currentPageNum;

    void Awake()
    {
        foreach (PageUI _page in PageArray)
            _page.animator = _page.Page.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))    ShowPage(1);
        if (Input.GetKeyDown(KeyCode.W))    ShowPage(2);
        if (Input.GetKeyDown(KeyCode.E))    ShowPage(3);
        if (Input.GetKeyDown(KeyCode.R))    ShowPage(4);
        if (Input.GetKeyDown(KeyCode.Tab))  ShowPage(5);
    }


    public void ShowPage(int targetPageNum) {
        StartCoroutine(_ShowPage(targetPageNum));
    }

    bool isPageOpening; //_ShowPage �ڷ�ƾ�� ���� ���ΰ�?
    IEnumerator _ShowPage(int targetPageNum)
    {
        if (isPageOpening) yield break;                             //�ڷ�ƾ�� �ߺ� ������ ���� ����
        isPageOpening = true;

        if (currentPageNum == targetPageNum) targetPageNum = 0;     //Ŀ���� ���ڴ� = ��� �������� �ݰڴ�

        //��ǥ �������� �ڿ� �ִٸ�, �� �徿 ������ ����
        for (; currentPageNum < targetPageNum; currentPageNum++) {
            PageArray[currentPageNum].animator.SetTrigger("Open");      //������ ���� �ִϸ��̼�
            yield return new WaitForSeconds(0.1f);                      //��ٸ��� ���� �������� �Ҷ�� �Ѿ�� ����
        }

        //��ǥ �������� �տ� �ִٸ�, �� �徿 ������ �ݱ�
        for (; currentPageNum > targetPageNum; currentPageNum--) {
            PageArray[currentPageNum-1].animator.SetTrigger("Close");   //������ �ݴ� �ִϸ��̼�
            yield return new WaitForSeconds(0.1f);                      //��ٸ��� ����, �������� �Ҷ�� �Ѿ�� ����
        }

        currentPageNum = Mathf.Clamp(currentPageNum, 0, PageArray.Length - 1);
        isPageOpening = false;
    }
}

[System.Serializable]
public class PageUI
{
    public GameObject Page;
    [HideInInspector] public Animator animator;
    //public ToggleInteration Toggle;
}
