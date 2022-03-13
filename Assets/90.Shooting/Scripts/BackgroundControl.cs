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
        //Meshrenderer의 매트리얼의 offset값을 새로 세팅해준다. 매 frame마다 
        myRenderer.material.SetTextureOffset("_MainTex", new Vector2(0.0f, Time.time * ScrollSpeed)); //_MainTex material이 가지고 있는 properties ID
        //밑에 shader 환경 설정 눌러서 select shader 하면 properties에 _MainText있음. 
    }
}
