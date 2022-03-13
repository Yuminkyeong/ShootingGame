using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //적의 이동속도
    public float EnemySpeed = 90.0f;

    //피격 이펙트
    public GameObject Explosion = null;

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
            InitPosition();
        }
        
    }

    //공통되는건 함수로 꼭 빼기 위치 초기화 함수 
    //summary 마우스 올리면 함수 설명 뜸. 실무에서 많이 사용 
        /// <summary>
        /// 내 위치를 초기화 해주는 함수
        /// </summary>
    void InitPosition()
    {
        myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f), 50.0f, 0f);
    }

    //나의 충돌체 영역에 트리거 설정이된 충돌체가 부딪혔다면 발생되는 이벤트 함수.
    private void OnTriggerEnter(Collider other)
    {
        //총알이 맞다면 
        if(other.tag == "bullet")
        {
            //Enemy를 맞추면 점수 100씩 up
            MainControl.Score += 100;

            //피격 이펙트 생성 
            Instantiate(Explosion, myTransform.position, Quaternion.identity);
           
            InitPosition();
            Destroy(other.gameObject);
        }

        else if(other.tag == "Player")
        {
            
            MainControl.Life -= 1;
            if (MainControl.Life == 0)
            {

            }

        }
        
    }
}
