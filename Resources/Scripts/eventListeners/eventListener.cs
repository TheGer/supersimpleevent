using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventListener : MonoBehaviour
{
    // Start is called before the first frame update

    private UnityAction<string> moveUpListener;
    private UnityAction<string> moveDownListener;
    private UnityAction<string> moveLeftListener;
    private UnityAction<string> moveRightListener;
    scriptedObject objVars;


    void Awake()
    {
        moveUpListener = new UnityAction<string>(moveUp);
        moveDownListener = new UnityAction<string>(moveDown);
        moveLeftListener = new UnityAction<string>(moveLeft);
        moveRightListener = new UnityAction<string>(moveRight);
        objVars = ScriptableObject.CreateInstance<scriptedObject>();

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
        scriptedObject obj = new scriptedObject();
        JsonUtility.FromJsonOverwrite(jsonvar,obj);

        obj.myobject.transform.position += new Vector3(0f, 1f);

    }

    void moveDown(string jsonvar)
    {
        scriptedObject obj = new scriptedObject();
        JsonUtility.FromJsonOverwrite(jsonvar, obj);
        obj.myobject.transform.position -= new Vector3(0f, 1f);


    }
    void moveLeft(string jsonvar)
    {
        scriptedObject obj = new scriptedObject();
        JsonUtility.FromJsonOverwrite(jsonvar, obj);

        obj.myobject.transform.position -= new Vector3(1f, 0f);


    }
    void moveRight(string jsonvar)
    {
        // Debug.Log("Zobbi"+jsonvar);
        scriptedObject obj = new scriptedObject();
        JsonUtility.FromJsonOverwrite(jsonvar, obj);

        obj.myobject.transform.position += new Vector3(1f, 0f);


    }

   



}
