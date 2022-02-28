using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float BulletSpeed = 100.0f;
    private Transform myTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>(); //제일 상단에 있는거 찾아오는 것     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = BulletSpeed * Vector3.up * Time.deltaTime;
        myTransform.Translate(moveAmount);
        //화면 밖으로 나가면
        if (myTransform.position.y > 60.0f)
        {
            //없애줍니다.
            Destroy(gameObject); //gameObject = BulletPrefab
        }
    }
}
