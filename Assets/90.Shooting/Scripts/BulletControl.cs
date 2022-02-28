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
        myTransform = GetComponent<Transform>(); //���� ��ܿ� �ִ°� ã�ƿ��� ��     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = BulletSpeed * Vector3.up * Time.deltaTime;
        myTransform.Translate(moveAmount);
        //ȭ�� ������ ������
        if (myTransform.position.y > 60.0f)
        {
            //�����ݴϴ�.
            Destroy(gameObject); //gameObject = BulletPrefab
        }
    }
}
