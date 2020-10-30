using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SquareController : MonoBehaviour
{
    // Start is called before the first frame update

    private UnityAction<string> moveUpListener;
    private UnityAction<string> moveDownListener;
    private UnityAction<string> moveLeftListener;
    private UnityAction<string> moveRightListener;


    void Awake()
    {
        moveUpListener = new UnityAction<string>(moveUp);
        moveDownListener = new UnityAction<string>(moveDown);
        moveLeftListener = new UnityAction<string>(moveLeft);
        moveRightListener = new UnityAction<string>(moveRight);

    }

    void OnEnable()
    {
        EventManager.StartListening("MOVEUP", moveUpListener);
        EventManager.StartListening("MOVEDOWN", moveDownListener);
        EventManager.StartListening("MOVELEFT", moveLeftListener);
        EventManager.StartListening("MOVERIGHT", moveRightListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("MOVEUP", moveUpListener);
        EventManager.StopListening("MOVEDOWN", moveDownListener);
        EventManager.StopListening("MOVELEFT", moveLeftListener);
        EventManager.StopListening("MOVERIGHT", moveRightListener);
    }

    void moveUp(string jsonvar)
    {
        // Debug.Log("Zobbi"+jsonvar);
        transform.position += new Vector3(0f, 1f);

    }

    void moveDown(string jsonvar)
    {
        // Debug.Log("Zobbi"+jsonvar);
        transform.position -= new Vector3(0f, 1f);


    }
    void moveLeft(string jsonvar)
    {
        // Debug.Log("Zobbi"+jsonvar);
        transform.position -= new Vector3(1f, 0f);


    }
    void moveRight(string jsonvar)
    {
        // Debug.Log("Zobbi"+jsonvar);
        transform.position += new Vector3(1f, 0f);


    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            EventManager.TriggerEvent("MOVEUP", null);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EventManager.TriggerEvent("MOVEDOWN", null);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            EventManager.TriggerEvent("MOVELEFT", null);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            EventManager.TriggerEvent("MOVERIGHT", null);
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
