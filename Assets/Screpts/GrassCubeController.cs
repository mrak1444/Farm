using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrassCubeController : MonoBehaviour
{
    private StackController _stackController;
    private bool _flag = true;

    private void Start()
    {
        StartCoroutine(DestroyObj());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _stackController = other.GetComponent<StackController>();

            if (_stackController.NumMax < 40 && _flag)
            {
                _flag = false;
                _stackController.StackAdd();
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}
