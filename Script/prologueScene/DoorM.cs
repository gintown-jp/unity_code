using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoorM : MonoBehaviour
{

    [SerializeField] GameObject DoorModulObj;
    [SerializeField] GameObject DoorFObj;

    // Start is called before the first frame update
    void Start()
    {
        DoorFadeIn();
    }

  

    public void DoorRotate()
    {
        this.transform.DORotate(new Vector3(0,-150,0),2f, default)
            .SetEase(Ease.InOutQuart);
    }

    public void DoorFadeIn()
    {
        SpriteRenderer image = DoorModulObj.GetComponent<SpriteRenderer>();
        SpriteRenderer image2 = DoorFObj.GetComponent<SpriteRenderer>();

        image.DOFade(1f, 15f)
            .SetDelay(2f)
            .SetEase(Ease.OutSine);
        image2.DOFade(1f, 15f)
            .SetDelay(2f)
            .SetEase(Ease.OutSine);
    }

    public void DoorColor()
    {
        SpriteRenderer image = DoorModulObj.GetComponent<SpriteRenderer>();
        SpriteRenderer image2 = DoorFObj.GetComponent<SpriteRenderer>();

        image.DOColor(new Color(1, 1, 1), 1f);
        image2.DOColor(new Color(1, 1, 1), 1f);
    }

}


