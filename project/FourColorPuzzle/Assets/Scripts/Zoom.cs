using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour
{
    private enum PINCH_STATUS
    {
        NONE = -1,
        UP,
        SCROLL,
        PINCH,
    };

    private PINCH_STATUS pinchStatus = PINCH_STATUS.UP;
    private PINCH_STATUS pinchStatusNext = PINCH_STATUS.NONE;

    const float ZOOM_SPEED = 150.0f;
    const float MOVE_SPEED = 0.05f;

    private float pos_x = 0.0f;
    private float pos_y = 0.0f;
    private float pinchLength;
    private Vector2 center;
    Camera cam;

    void Start()
    {
        cam = (Camera)transform.GetComponent("Camera");
    }

    Vector2 convertCenter(Vector2 pos)
    {
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 0));
        return new Vector2(p.x, p.y);
    }

    void Update()
    {
        switch (pinchStatus)
        {
            case PINCH_STATUS.UP:
                if (Input.touchCount == 1)
                {
                    pinchStatusNext = PINCH_STATUS.SCROLL;
                }
                if (Input.touchCount == 2)
                {
                    Touch touch0 = Input.GetTouch(0);
                    Touch touch1 = Input.GetTouch(1);

                    pinchLength = Vector2.Distance(touch0.position, touch1.position);
                    center = (touch0.position + touch1.position) * 0.5f;
                    center = convertCenter(center);
                    print(touch0.position + ", " + touch1.position + ", " + center);


                    pinchStatusNext = PINCH_STATUS.PINCH;
                }

                break;

            case PINCH_STATUS.SCROLL:
                if (Input.touchCount == 0)
                {
                    pinchStatusNext = PINCH_STATUS.UP;
                }
                if (Input.touchCount == 2)
                {
                    Touch touch0 = Input.GetTouch(0);
                    Touch touch1 = Input.GetTouch(1);

                    pinchLength = Vector2.Distance(touch0.position, touch1.position);
                    center = (touch0.position + touch1.position) * 0.5f;
                    center = convertCenter(center);
                    print(touch0.position + ", " + touch1.position + ", " + center);

                    pinchStatusNext = PINCH_STATUS.PINCH;
                }

                if (cam.orthographicSize < 5)
                {
                    pos_x = Input.GetAxis("Mouse X") * MOVE_SPEED;
                    pos_y = Input.GetAxis("Mouse Y") * MOVE_SPEED;

                    Vector3 pos = transform.localPosition;

                    if (cam.transform.localPosition.x > 3) pos.x = 3;
                    if (cam.transform.localPosition.x < -3) pos.x = -3;
                    if (transform.localPosition.y > 1.0) pos.y = 1.0f;
                    if (transform.localPosition.y < -1.0) pos.y = -1.0f;

                    cam.transform.localPosition = pos;

                    cam.transform.localPosition -= new Vector3(pos_x, pos_y, 0);

                }
                break;

            case PINCH_STATUS.PINCH:
                if (Input.touchCount == 0)
                {
                    pinchStatusNext = PINCH_STATUS.UP;
                }
                if (Input.touchCount == 1)
                {
                    pinchStatusNext = PINCH_STATUS.SCROLL;
                }
                break;
        }

        while (pinchStatusNext != PINCH_STATUS.NONE)
        {
            pinchStatus = pinchStatusNext;
            pinchStatusNext = PINCH_STATUS.NONE;
        }

        switch (pinchStatus)
        {
            case PINCH_STATUS.PINCH:
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);
                float nowPinchLength = Vector2.Distance(touch0.position, touch1.position);
                float scale = nowPinchLength / pinchLength;
                cam.orthographicSize /= scale;

                if (cam.orthographicSize < 2) cam.orthographicSize = 2;
                if (cam.orthographicSize > 5) cam.orthographicSize = 5;
                pinchLength = nowPinchLength;

                Vector2 nowCamPos = new Vector2(cam.transform.localPosition.x, cam.transform.localPosition.y);
                Vector2 dis = center - nowCamPos;
                scale = 1.0f - scale;
                dis = dis * scale;

                if (cam.orthographicSize > 2 && cam.orthographicSize < 5)
                {

                    if (cam.transform.localPosition.x > 3) dis.x = 3;
                    if (cam.transform.localPosition.x < -3) dis.x = -3;
                    if (cam.transform.localPosition.y > 1.0) dis.y = 1.0f;
                    if (cam.transform.localPosition.y < -1.0) dis.y = -1.0f;

                    cam.transform.localPosition -= new Vector3(dis.x, dis.y, 0);
                }

                if (cam.orthographicSize == 5)
                {
                    cam.transform.localPosition = new Vector3(0, 0, -10);
                }

                break;
        }
    }
}
