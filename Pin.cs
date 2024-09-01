using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed = 10f;
    private bool isPinned = false;
    private bool isLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPinned == false && isLaunched == true){ // 부딪히지 않은 상태에서만, 발사를 누른 이후
            transform.position += Vector3.up * moveSpeed * Time.deltaTime; // 위(up) 방향으로 무한히 올라감
        }
    }

    // onTriggerEnter2D를 적고 Tab키를 누르면 : 2D 안하면 오류 발생
    private void OnTriggerEnter2D(Collider2D other) { // 충돌하게 되면
        isPinned = true; // isPinned(스위치)를 true로 변환 [부딪힌 상태로 전환]
        if (other.gameObject.tag == "Target"){ // TargetCicle 태그를 가진 것과

            GameObject childObject = transform.Find("Square").gameObject; // "Square"라는 이름의 자식 오브젝트를 찾는 것
            // GameObject childObject = transform.GetChild(0).gameObject; 
            SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>(); // 오브젝트의 컴포넌트 중에 Sprite Renderer라는 것
            childSprite.enabled = true; // enabled (표시할지 여부) 체크하기

            transform.SetParent(other.gameObject.transform); // 충돌한 대상(TargetCircle)을 부모로 만들어 줌

            GameManager.instance.DecreaseGoal(); // DecreaseGoal(목표를 하나씩 줄어들게 하는) 메서드 호출하기
        } else if(other.gameObject.tag == "Pin") { // Pin이라는 태그와 (부딪혔다면)
            GameManager.instance.SetGameOver(false); // SetGameOver 메서드를 호출하고 그 인수를 (스위치를) false로 설정
        }
    }
        public void Launch()
    {
        isLaunched = true; // Launch(발사)되면 발사 여부를 true로 변경
    }

}