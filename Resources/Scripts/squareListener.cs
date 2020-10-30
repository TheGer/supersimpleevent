using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareListener : MonoBehaviour
{
    // Start is called before the first frame update
    testScriptableObject objVars;

    void Start()
    {
        objVars = ScriptableObject.CreateInstance<testScriptableObject>();
        objVars.myobject = this.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            EventManager.TriggerEvent("MOVEUP", JsonUtility.ToJson(objVars));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EventManager.TriggerEvent("MOVEDOWN", JsonUtility.ToJson(objVars));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            EventManager.TriggerEvent("MOVELEFT", JsonUtility.ToJson(objVars));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            EventManager.TriggerEvent("MOVERIGHT", JsonUtility.ToJson(objVars));
        }



        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            testScriptableObject objVars;
            objVars = ScriptableObject.CreateInstance<testScriptableObject>();
            objVars.BoolInfo = true;
            objVars.stringInfo = "Im a string";

            // converts to a json string, so the messge only needs 1 string to pass a large number of diverse parameters. and multiple objects subscribed to the message can pick the ones they need.
            string jsonVars = JsonUtility.ToJson(objVars);
            EventManager.TriggerEvent("MOVEUP", jsonVars);
        }*/
    }
}
