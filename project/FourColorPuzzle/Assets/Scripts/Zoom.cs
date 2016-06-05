using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour
{
    const float ZOOM_SPEED = 200.0f;
    const float MOVE_SPEED = 0.05f;

    private Vector3 originalSize;
    private float pos_x = 0.0f;
    private float pos_y = 0.0f;

    private bool isDrag = false;
    private bool isPinch = false;
    private float interval = 0.0f;
    Camera came;

    // Use this for initialization
    void Start()
    {
        came = (Camera)transform.GetComponent("Camera");
        originalSize.z = came.orthographicSize;
    }

    void Update()
    {
        if (Input.touchCount == 1 && !isPinch)
        {
            if (Event.current.type == EventType.MouseDrag)
                isDrag = true;
            else
                isDrag = false;
        }
        else if (Input.touchCount == 0)
        {
            isPinch = false;
            isDrag = false;
        }

        //========================================================================
        // ズームイン・アウト、画面スクロール
        //========================================================================
        if (Input.touchCount == 2) 
        {
            if (Input.touches[0].phase == TouchPhase.Began || Input.touches[1].phase == TouchPhase.Began)
            {
                interval = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            }
            float tmpInterval = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);

            originalSize.z += (interval - tmpInterval) / ZOOM_SPEED;

            interval = tmpInterval;
            if (originalSize.z < 1) originalSize.z = 1;
            if (originalSize.z > 5) originalSize.z = 5;

            came.orthographicSize = originalSize.z;
            isPinch = true;
        }
        else if (isDrag)
        {
            pos_x = Input.GetAxis("Mouse X") * MOVE_SPEED;
            pos_y = Input.GetAxis("Mouse Y") * MOVE_SPEED;
            
            transform.Translate(-pos_x, -pos_y, 0);
        }
    }
}
