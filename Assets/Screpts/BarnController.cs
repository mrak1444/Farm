using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _pointUICoins;
    [SerializeField] private UIController _uiController;

    private StackController _stackController;
    private bool _flag = true;

    private void Start()
    {
        _stackController = _player.GetComponent<StackController>();
    }

    private void Update()
    {
        if(_player.transform.position.z <= 3.6f)
        {
            if(_stackController.NumMax != 0 && _flag)
            {
                var num = _stackController.NumMax;
                _flag = false;
                _stackController.StackClear(transform);
                StartCoroutine(Coins(num));
            }
            if(_stackController.NumMax == 0)
            {
                _flag = true;
            }
        }
    }

    IEnumerator Coins(int num)
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(CoinsAdd(num));
    }

    IEnumerator CoinsAdd(int num)
    {
        for (int i = 0; i < num; i++)
        {
            yield return new WaitForSeconds(0.02f);
            var grObj = Instantiate(_coin, transform.position, Quaternion.identity);
            grObj.transform.DOMove(_pointUICoins.transform.position, 1f);

            StartCoroutine(CoinsUI());
        }
    }

    IEnumerator CoinsUI()
    {
        yield return new WaitForSeconds(1f);
        GameProfile.Coins += 15;
        _uiController.CoinsTxt = $"{GameProfile.Coins}";
    }
}
