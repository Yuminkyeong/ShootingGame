using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Player ����ü �̵� �ӵ� inspector view�� �ִ� ���� �켱���� ����
    //inspector���� �ٲٰ� ������(�ۿ��� �����ϰ� ���� ��) public
    public float Speed = 15.0f;
    //�÷��̾ �����ϰԵ� ���� bullet prefab
    public GameObject BulletPrefab = null;
    //Player gameObject�� transfrom component
    private Transform myTransform = null; //Transform ������ ���� 
 
    //Transform���� �������� ���� �����ϹǷ� cashing(���´�) �ѹ� �ҷ��ͼ� ������Ʈ ã�� �ʰ� 
    //��� ����ϴ°� ������. 


    // Start is called before the first frame update  update �Լ� ȣ�� �� �� �ѹ� ȣ���.
    void Start()
    {
       
        //Ʈ������ ������Ʈ�� ĳ��
        myTransform = GetComponent<Transform>();
        //myTransform = GetComponent("Transform") as Transform; "" -> type�� �̸� ��. �� ������. 

    }

    // Update is called once per frame
    void Update()
    {
           
            // -1~1 ���� ȭ��Ű(-1) ������ ȭ��Ű(1) �� -1,1 �� ������ �� �ƴ�. ���� ������ ���� ���� ����� ���� ��µ�. 
            //edit>projectSettings>Input inputManager�� �ִµ� �ű⿡ �ִ� ������ �������� ����. 
            float axis = Input.GetAxis("Horizontal");
            //Debug.Log("axis: "+axis);
            //FPS frame per second ; 30 FPS = 1�ʿ� 30�� ȣ�� 
            //���� ������ ������ �ִ� �ϳ��� ǥ�� ü��: vector 
            //���ʹϾ� ������ �� ���� // ��������? �� ����
            //player �� rotation���� ��ġ ��������(�¿� �ٲ��) �ֱ� ������ -Vector3.right �ؾ���. 
            //�������Ӵ� �� ���ӿ�����Ʈ�� �츮�� ���ϴ� �ӵ��� �������� �̵��ϴ� ��. 
            Vector3 moveAmount = axis * Speed * -Vector3.right * Time.deltaTime;
        //frame ��� �ð� -> delta time
        
            myTransform.Translate(moveAmount); //scripting�� �� https://docs.unity3d.com/Manual/index.html api ����
      
        //����
        if (Input.GetKeyDown(KeyCode.Space)) //��������
        {

            //bulletprefab�� ���� ���� �ִ� ��ġ���� ȸ�� ��Ű�� ���� ���·� �ν��Ͻ�.
            Instantiate(BulletPrefab,myTransform.position,Quaternion.identity); //Quaternion.identity�� ȸ����Ű�� �ʰڴٴ� ��.
        }
    }

  
}
