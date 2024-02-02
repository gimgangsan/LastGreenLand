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

    bool isPageOpening; //_ShowPage 코루틴이 실행 중인가?
    IEnumerator _ShowPage(int targetPageNum)
    {
        if (isPageOpening) yield break;                             //코루틴의 중복 실행을 막기 위해
        isPageOpening = true;

        if (currentPageNum == targetPageNum) targetPageNum = 0;     //커버로 가겠다 = 모든 페이지를 닫겠다

        //목표 페이지가 뒤에 있다면, 한 장씩 페이지 열기
        for (; currentPageNum < targetPageNum; currentPageNum++) {
            PageArray[currentPageNum].animator.SetTrigger("Open");      //페이지 여는 애니메이션
            yield return new WaitForSeconds(0.1f);                      //기다림을 통해 페이지가 촤라락 넘어가게 연출
        }

        //목표 페이지가 앞에 있다면, 한 장씩 페이지 닫기
        for (; currentPageNum > targetPageNum; currentPageNum--) {
            PageArray[currentPageNum-1].animator.SetTrigger("Close");   //페이지 닫는 애니메이션
            yield return new WaitForSeconds(0.1f);                      //기다림을 통해, 페이지가 촤라락 넘어가게 연출
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
