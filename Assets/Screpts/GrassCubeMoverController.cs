using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassCubeMoverController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyObj());
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
