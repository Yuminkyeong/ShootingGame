using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //���� �̵��ӵ�
    public float EnemySpeed = 90.0f;

    //�ǰ� ����Ʈ
    public GameObject Explosion = null;

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
            InitPosition();
        }
        
    }

    //����Ǵ°� �Լ��� �� ���� ��ġ �ʱ�ȭ �Լ� 
    //summary ���콺 �ø��� �Լ� ���� ��. �ǹ����� ���� ��� 
        /// <summary>
        /// �� ��ġ�� �ʱ�ȭ ���ִ� �Լ�
        /// </summary>
    void InitPosition()
    {
        myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f), 50.0f, 0f);
    }

    //���� �浹ü ������ Ʈ���� �����̵� �浹ü�� �ε����ٸ� �߻��Ǵ� �̺�Ʈ �Լ�.
    private void OnTriggerEnter(Collider other)
    {
        //�Ѿ��� �´ٸ� 
        if(other.tag == "bullet")
        {
            //Enemy�� ���߸� ���� 100�� up
            MainControl.Score += 100;

            //�ǰ� ����Ʈ ���� 
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
