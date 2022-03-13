using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    //전역변수 static
    static public int Score = 0;
    static public int Life = 3;
    public GUISkin mySkin = null;

    private void OnGUI()
    {
        //함수 안에 코딩한 GUI 자동으로 그려줌. 유니티 기능
        //skin 변경 skin 쓴 이유 UI 실시간으로 바꿔볼 수 있으므로
        GUI.skin = mySkin;
        Rect labelRect1 = new Rect(10.0f, 10.0f, 400.0f, 100.0f); //위치 x, y, 폭, 높이 영역 만들기
        GUI.Label(labelRect1, "SCORE: " + MainControl.Score); //클래스 이름으로 바로 변수 접근 -> static이기 때문에 가능한 것.
        Rect labelRect2 = new Rect(10.0f, 110.0f, 400.0f, 100.0f);
        GUI.Label(labelRect2, "LIFE: " +  Life); //script 내부니까 이렇게 접근해도 ok
    }

    // Update is called once per frame
    void Update()
    {
        if (MainControl.Score > 500)
        {
            MainControl.Score = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }
    }
}
