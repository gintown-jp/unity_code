using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class DoorKnobM : MonoBehaviour
{
    [SerializeField] GameObject DoorMirrorObj;
    [SerializeField] GameObject AudioObjSE;

    [SerializeField] GameObject GameMObj;

    private int count = 0;


    public void countUp()
    {
        count++;
        if (count > 3)
        {
            footPrintsOn();
            GameMObj.GetComponent<GManager>().PlusChaos();
        }
    }

    public void footPrintsOn()
    {

        DoorMirrorObj.GetComponent<Image>().color = new Color(0.9f, 0.7f, 0.7f,1f);
        AudioObjSE.GetComponent<SoundSE_M>().DoorMirrorSE();

        Image image = DoorMirrorObj.GetComponent<Image>();
        image.DOFade(0f, 1.5f)
                  .SetDelay(1f)
                  .SetEase(Ease.OutSine);

        count = 0;
    }


}
