using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinLancher : MonoBehaviour
{

    [SerializeField]
    private GameObject pinObject; // 유니티에서 핀 오브젝트를 드래그앤 드롭

    private Pin currPin;

    // Start is called before the first frame update
    void Start() // 시작하자마자
    {
        PreparePin(); // PreparePin 메소드 호출
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currPin != null && GameManager.instance.isGameOver == false){ // 왼쪽(0번) 마우스 버튼을 누르면(Down) && currPin이 발사된 직후가 아닌 경우에만 && 게임오버가 아닌 경우에만
            currPin.Launch(); // Launch 스위치를 작동하는 것
            currPin = null; // 발사되고 나면 더 이상 제어 불가능
            Invoke("PreparePin", 0.2f); // 쏘고 나서 0.1초 이후에 PreparePin 메소드를 다시 불러옴
        }
    }

    void PreparePin()
    {
        if (GameManager.instance.isGameOver == false) { // 게임오버되지 않았을 때 : (핀을 쏠 준비를 하라는 것)
            GameObject pin = Instantiate(pinObject, transform.position, Quaternion.identity); // 핀 오브젝트를 어디에, 얼마나 회전하도록 할지 정함
            currPin = pin.GetComponent<Pin>(); // Pin 컴포넌트의 Launch((스위치)를 쓰기 위해 연결해주기
        }
    }

}