using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{

    public float ScrollSpeed = 0.1f;
    public Renderer myRenderer = null;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Meshrenderer�� ��Ʈ������ offset���� ���� �������ش�. �� frame���� 
        myRenderer.material.SetTextureOffset("_MainTex", new Vector2(0.0f, Time.time * ScrollSpeed)); //_MainTex material�� ������ �ִ� properties ID
        //�ؿ� shader ȯ�� ���� ������ select shader �ϸ� properties�� _MainText����. 
    }
}
