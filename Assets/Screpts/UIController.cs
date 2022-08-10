using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _stackTxt;
    [SerializeField] private TMP_Text _coinsTxt;
    [SerializeField] private GameObject _StackIcon;
    [SerializeField] private GameObject _CoinsIcon;

    public string StackTxt 
    {
        set 
        { 
            _stackTxt.text = value;
            Shake(_StackIcon);
        } 
    }
    public string CoinsTxt 
    {
        set 
        { 
            _coinsTxt.text = value;
            Shake(_CoinsIcon);
        } 
    }

    private void Shake(GameObject obj)
    {
        obj.transform.DOShakePosition(0.9f, new Vector3(2,2,0));
    }
}
