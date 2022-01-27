using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueM : MonoBehaviour
{

    [SerializeField] GameObject BasePointOfObj;//ドアの支点
    [SerializeField] GameObject storyTextObj;
    [SerializeField] GameObject MainCameraObj;
    [SerializeField] GameObject fadeSceanObj;

    public bool ClickOn = false;//画面タップを許可判定（storyTxtMから操作）
    

    // Update is called once per frame
    void Update()
    {
        if(ClickOn == false) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.name == "Cube")//ドアのオブジェクトに重ねている3dオブジェクト"Cube"がhitしたら実行
                {
                    DoorClickSet();
                }
            }
        }
    }
    private IEnumerator SceanMove()//シーンの移動
    {
        yield return new WaitForSeconds(0.8f);
        fadeSceanObj.GetComponent<SceneFadeM>().fadeOutStart(255, 255, 255, 0, "main");
    }

    public void DoorClickSet()//ドアをクリックした時のセット
    {
        storyTextObj.GetComponent<storyTextM>().TextFadeOut();
        BasePointOfObj.GetComponent<DoorM>().DoorRotate();
        BasePointOfObj.GetComponent<DoorM>().DoorColor();
        MainCameraObj.GetComponent<CameraMoveM>().CameraMoreZoom();
        StartCoroutine(SceanMove());//シーンの移動
    }


}
