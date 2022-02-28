using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //적의 이동속도
    public float EnemySpeed = 90.0f;

    //나의 트랜스폼 컴포넌트 
    private Transform myTransform = null;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //적 게임오브젝트의 이동.
        Vector3 moveAmount = EnemySpeed * Vector3.back * Time.deltaTime;
        myTransform.Translate(moveAmount);

        //화면 밖으로 나갔다면 위치를 다시 세팅
        if(myTransform.position.y < -50.0f)
        {
            myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f),
                50.0f, //y축 값은 50
                0.0f); //z축 값은 0
        }
        
    }

    //나의 충돌체 영역에 트리거 설정이된 충돌체가 부딪혔다면 발생되는 이벤트 함수.
    private void OnTriggerEnter(Collider other)
    {
        //총알이 맞다면 
        if(other.tag == "bullet")
        {

        }
        
    }
}
