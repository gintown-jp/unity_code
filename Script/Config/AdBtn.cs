using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AdBtn : MonoBehaviour
{
    public int AdBtnNo;

    public void ColorChange()
    {
        this.GetComponent<Image>().color = new Color(0.7f,0.9f,0.9f);
    }

}
