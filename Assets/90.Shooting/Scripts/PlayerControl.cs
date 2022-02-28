using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Player 비행체 이동 속도 inspector view에 있는 것이 우선순위 높음
    //inspector에서 바꾸고 싶은거(밖에서 수정하고 싶은 것) public
    public float Speed = 15.0f;
    //플레이어가 생성하게될 원본 bullet prefab
    public GameObject BulletPrefab = null;
    //Player gameObject의 transfrom component
    private Transform myTransform = null; //Transform 상태의 변수 
 
    //Transform으로 여러가지 조정 가능하므로 cashing(얻어온다) 한번 불러와서 컴포넌트 찾지 않고 
    //계속 사용하는게 간편함. 


    // Start is called before the first frame update  update 함수 호출 전 딱 한번 호출됨.
    void Start()
    {
       
        //트랜스폼 컴포넌트를 캐싱
        myTransform = GetComponent<Transform>();
        //myTransform = GetComponent("Transform") as Transform; "" -> type의 이름 들어감. 잘 사용안함. 

    }

    // Update is called once per frame
    void Update()
    {
           
            // -1~1 왼쪽 화살키(-1) 오른쪽 화살키(1) 딱 -1,1 깂 나오는 건 아님. 오래 누르고 있을 수록 가까운 값이 출력됨. 
            //edit>projectSettings>Input inputManager가 있는데 거기에 있는 값들을 가져오는 것임. 
            float axis = Input.GetAxis("Horizontal");
            //Debug.Log("axis: "+axis);
            //FPS frame per second ; 30 FPS = 1초에 30번 호출 
            //힘과 방향을 가지고 있는 하나의 표시 체계: vector 
            //쿼터니안 각도가 더 좋음 // 임폴리안? 과 관련
            //player 가 rotation으로 위치 뒤집어져(좌우 바뀌어) 있기 때문에 -Vector3.right 해야함. 
            //매프레임당 이 게임오브젝트가 우리가 원하는 속도와 방향으로 이동하는 양. 
            Vector3 moveAmount = axis * Speed * -Vector3.right * Time.deltaTime;
        //frame 경과 시간 -> delta time
        
            myTransform.Translate(moveAmount); //scripting할 때 https://docs.unity3d.com/Manual/index.html api 참고
      
        //슈팅
        if (Input.GetKeyDown(KeyCode.Space)) //눌렸을때
        {

            //bulletprefab을 현재 내가 있는 위치에서 회전 시키지 않은 상태로 인스턴싱.
            Instantiate(BulletPrefab,myTransform.position,Quaternion.identity); //Quaternion.identity는 회전시키지 않겠다는 뜻.
        }
    }

  
}
