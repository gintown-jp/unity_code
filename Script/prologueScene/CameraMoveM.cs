using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CameraMoveM : MonoBehaviour
{
    public float zoomDuration;//何秒かけて進むか
    public float zoomFieldView;//カメラ拡大の値
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();

        CameraZoom();
    }

    

    public void CameraZoom()
    {
        camera.DOFieldOfView(zoomFieldView, zoomDuration)
            .SetDelay(2f);
    }

    public void CameraMoreZoom()
    {
        camera.DOFieldOfView(2, 1.5f)
            .SetDelay(0.5f);
    }


}
