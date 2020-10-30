using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCreator : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject mysquare,mysquare2;
    void Start()
    {
        mysquare = Instantiate(Resources.Load<GameObject>("Prefabs/Square"),new Vector3(0f,0f),Quaternion.identity);


        mysquare2 = Instantiate(Resources.Load<GameObject>("Prefabs/Square"), new Vector3(1f, 1f), Quaternion.identity);

        mysquare.AddComponent<squareListener>();
        mysquare2.AddComponent<squareListener>();
        StartCoroutine(disableSquare());
    }

    IEnumerator disableSquare()
    {
        yield return new WaitForSeconds(1f);
     //   mysquare.SetActive(false);
    }
   
}
