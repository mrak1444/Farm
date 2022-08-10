using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{
    [SerializeField] private GameObject _cubeMover;
    [SerializeField] private GameObject[] _stack;
    [SerializeField] private UIController _uiController;

    private int _num = 0;
    private Sequence _sequence;

    public int NumMax { get => _num; }

    private void Start()
    {
        

        for (var i = 0; i < _stack.Length; i++)
        {
            _stack[i].SetActive(false);
        }
    }

    public void StackAdd()
    {
        _stack[_num].SetActive(true);
        _num++;
        var n = _num < 39 ? _num : 39;
        _uiController.StackTxt = $"{n + 1} / 40";
    }

    public void StackClear(Transform pointMove)
    {
        StartCoroutine(StackMove(pointMove));
    }

    IEnumerator StackMove(Transform pointMove)
    {
        for (int i = _num-1; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.02f);
            var grObj = Instantiate(_cubeMover, _stack[i].transform.position, Quaternion.identity);
            grObj.transform.DOMove(pointMove.position, 1f);

            _stack[i].SetActive(false);
            _num--;

            var n = _num < 39 ? _num : 39;
            _uiController.StackTxt = $"{n} / 40";
        }
        if (_num < 0) _num = 0;

        
    }
}
