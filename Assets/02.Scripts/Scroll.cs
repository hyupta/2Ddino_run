using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeedX = 2f; // X축 스크롤 속도
    private Renderer quadRenderer;

    public bool isCloud;    // 구름인지 아닌지 판단하기 위한 bool 데이터 타입, 구름이면 true 아니면(Ground면) false.
    public float cloudScrollSpeedX = 0.5f;  // 구름이 움직이는 속도

    void Start()
    {
        quadRenderer = GetComponent<Renderer>();   // Quad의 Renderer를 가져옴
    }

    void Update()
    {
        if (isCloud)
        {
            // 이 스크립트가 붙어있는 게임 오브젝트를 현재 좌표에서 지정한 cloudScollSpeedX값만큼 계속 빼서 왼쪽으로 계속 움직여준다.
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - cloudScrollSpeedX * Time.deltaTime,
                                                         this.gameObject.transform.position.y,
                                                         this.gameObject.transform.position.z);

            if (this.gameObject.transform.position.x <= -11f) // 이 게임 오브젝트의 x 좌표가 -11보다 작거나 같으면, 
            {
                this.gameObject.transform.position = new Vector3(11f, Random.Range(1f, 4f), 0f);  // 이 게임 오브젝트는 x =11, 랜덤값 y가 1에서 4 사이, z = 0의 좌표로 이동됨
            }
        }
        else
        {
            // 시간에 따라 UV 오프셋 값을 계산
            float offsetX = Time.time * scrollSpeedX;

            // Material의 메인 텍스처의 오프셋을 조정
            quadRenderer.material.mainTextureOffset = new Vector2(offsetX, 0f);
        }
    }
}
