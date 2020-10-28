using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCreator : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject mysquare;
    void Start()
    {
        mysquare = Instantiate(Resources.Load<GameObject>("Prefabs/Square"),new Vector3(0f,0f),Quaternion.identity);
        mysquare.AddComponent<SquareController>();
        StartCoroutine(disableSquare());
    }

    IEnumerator disableSquare()
    {
        yield return new WaitForSeconds(1f);
     //   mysquare.SetActive(false);
    }
   
}
