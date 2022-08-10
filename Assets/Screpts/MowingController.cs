using System.Collections;
using UnityEngine;

public class MowingController : MonoBehaviour
{
    [SerializeField] private GameObject _grassCube;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            var obj = other.GetComponent<GrassController>();
            
            if (obj.Grass.activeSelf)
            {
                obj.Mow();

                StartCoroutine(GrassCube(other));
            }
        }
    }

    IEnumerator GrassCube(Collider other)
    {
        yield return new WaitForSeconds(0.3f);

        var grObj = Instantiate(_grassCube,
                    new Vector3(other.transform.position.x, other.transform.position.y + 0.1f, other.transform.position.z),
                    Quaternion.identity);
        //grObj.GetComponent<Rigidbody>().AddTorque(Vector3.up);
    }
}
