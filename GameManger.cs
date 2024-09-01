using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // 추가해주기
using UnityEngine.SceneManagement; // 버튼으로 재실행하게 만들기에 적용됨

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool isGameOver = false;

    [SerializeField]
    private TextMeshProUGUI textGoal; // TMP Text(UI 안의 텍스트)를 드래그앤 드롭으로 넣을 곳

    [SerializeField]
    public int goal; // Text의 글자를 직접 설정할 수 있도록 하기

    [SerializeField]
    private GameObject btnRetry; // 버튼을 넣을 장소

    [SerializeField]
    private Color successed; // 성공하면 지정하고자 하는 색깔
    
    [SerializeField]
    private Color failed; // 실패하면 지정하고자 하는 색깔


    // Awake 적고 tab 키 누르면 자동으로 완성됨
    private void Awake() 
    {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textGoal.SetText(goal.ToString()); // goal에 적은대로 텍스트를 변경 : goal은 정수라서 문자열로 변환해야 함
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseGoal() // DecreaseGoal이 호출될 때마다
    {
        goal -= 1; // goal 인수에 있는 값을 1씩 줄어들게 함
        textGoal.SetText(goal.ToString()); // 다시 int에서 String으로 변환하여 적용하기

        if (goal <= 0){ // 그런데 만약 목표가 0보다 낮아지면
            SetGameOver(true); // SetGameOver라는 메소드를 호출함
        }
    }

    public void SetGameOver(bool success)
    {
        if (isGameOver == false){ // isGameover 스위치가 false이면
            isGameOver = true; // isGameover 스위치를 true로 변경하고

            Camera.main.backgroundColor = success ? successed : failed; // if else 문을 짧게 줄인 것 : 성공하면 어떤 색깔, 실패하면 어떤 색깔로 지정
            Invoke("ShowRetryButton", 1f); // 1초 이후에 ShowRetryButton 메서드 활성화
        }
    }

    void ShowRetryButton()
    {
        btnRetry.SetActive(true); // Retry 버튼을 화면에 띄움
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene"); // Sample Scene이라고 이름을 붙인 게임(처음화면)을 로드하기
    }
}