using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TargetCircle : MonoBehaviour
{
    [SerializeField]

    private float rotateSpeed = -140f; // 음수면 시계방향, 양수면 반시계방향

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false){ // isGameOver가 false이면 즉 아직 게임 중이면
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime); // z값(회전 각도)만 바꾸는 것
        }
    }
}