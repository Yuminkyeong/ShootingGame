using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //���� �̵��ӵ�
    public float EnemySpeed = 90.0f;

    //���� Ʈ������ ������Ʈ 
    private Transform myTransform = null;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //�� ���ӿ�����Ʈ�� �̵�.
        Vector3 moveAmount = EnemySpeed * Vector3.back * Time.deltaTime;
        myTransform.Translate(moveAmount);

        //ȭ�� ������ �����ٸ� ��ġ�� �ٽ� ����
        if(myTransform.position.y < -50.0f)
        {
            myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f),
                50.0f, //y�� ���� 50
                0.0f); //z�� ���� 0
        }
        
    }

    //���� �浹ü ������ Ʈ���� �����̵� �浹ü�� �ε����ٸ� �߻��Ǵ� �̺�Ʈ �Լ�.
    private void OnTriggerEnter(Collider other)
    {
        //�Ѿ��� �´ٸ� 
        if(other.tag == "bullet")
        {

        }
        
    }
}
