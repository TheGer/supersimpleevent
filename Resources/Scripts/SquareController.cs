using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SquareController : MonoBehaviour
{
    // Start is called before the first frame update

    private UnityAction<string> TestListener;
    void Awake()
    {
        TestListener = new UnityAction<string>(TestMethod);
    }

    void OnEnable()
    {
        EventManager.StartListening("START", TestListener);   
    }

    private void OnDisable()
    {
        EventManager.StopListening("START", TestListener);
    }

    void TestMethod(string jsonvar)
    {
        Debug.Log("Zobbi"+jsonvar);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            testScriptableObject objVars;
            objVars = ScriptableObject.CreateInstance<testScriptableObject>();
            objVars.BoolInfo = true;
            objVars.stringInfo = "Im a string";

            // converts to a json string, so the messge only needs 1 string to pass a large number of diverse parameters. and multiple objects subscribed to the message can pick the ones they need.
            string jsonVars = JsonUtility.ToJson(objVars);
            EventManager.TriggerEvent("START", jsonVars);
        }
    }



}
