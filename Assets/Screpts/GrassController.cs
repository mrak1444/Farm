using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrassController : MonoBehaviour
{
    [SerializeField] private GameObject _grass;

    public GameObject Grass { get => _grass; }

    public void Mow()
    {
        StartCoroutine(Mowing());
    }

    IEnumerator Mowing()
    {
        _grass.transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        yield return new WaitForSeconds(0.3f);
        
        _grass.SetActive(false);
        StartCoroutine(GrassGrowth());
    }

    IEnumerator GrassGrowth()
    {
        yield return new WaitForSeconds(30f);

        _grass.SetActive(true);
        //_grass.transform.localScale = new Vector3(0, 0, 0);
        _grass.transform.DOScale(new Vector3(1, 1, 1), 10f);
    }
}
