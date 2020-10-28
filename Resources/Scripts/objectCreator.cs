using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.Profiling;
using UnityEngine;


public class boxObject
{
    Vector3 position;
    float scale;

    public float Scale { get => scale; set => scale = value; }
    public Vector3 Position { get => position; set => position = value; }
}

public class objectCreator : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject squareToLoad;
    HashSet<boxObject> boxes;
    float xvalue, yvalue,scale;
    int failcount;

    void Start()
    {
        //the folder Prefabs, and the file Square, to load into this variable.
        squareToLoad = Resources.Load<GameObject>("Prefabs/Square");
        boxes = new HashSet<boxObject>();
        failcount = 0;
        StartCoroutine(generateBoxes());
        
        
        
        
    }


    IEnumerator generateBoxes()
    {
        while (true)
        {
            xvalue = Random.Range(-Camera.main.orthographicSize+0.5f, Camera.main.orthographicSize-0.5f);
            yvalue = Random.Range(-Camera.main.orthographicSize+0.5f, Camera.main.orthographicSize-0.5f);
            scale = Random.Range(0.1f, 2.0f);

            Vector3 pos = new Vector3(xvalue, yvalue);

            if (!checkOverlapping(pos,scale))
            {
                failcount = 0;
                generateSquare(pos,scale);
                boxObject myBox = new boxObject();
                myBox.Position = pos;
                myBox.Scale = scale;
                

                boxes.Add(myBox);
            }
            else
            {
                Debug.Log("failed" + failcount);
                failcount++;
            }

            if (failcount >= 500)
            {
                break;
            }
            //100 squares in random positions on the screen which DO NOT overlap
            //  yield return new WaitForSeconds(0.01f);
            yield return null;
        }
        yield return null;
    }


    float getHypotenuse(float scale)
    {
        return Mathf.Sqrt(Mathf.Pow(scale, 2) + Mathf.Pow(scale, 2));
    }


    bool checkOverlapping(Vector3 boxPosition,float scale)
    {
        foreach (boxObject box in boxes)
        {
            if (Vector3.Distance(box.Position,boxPosition)<(getHypotenuse(box.Scale)+getHypotenuse(scale)))
            {
                //Debug.Log(positions.Count);
                return true;
            }
        }
        return false;
    }
        
    void generateSquare(Vector3 newposition,float scale)
    {
        
       GameObject box =Instantiate(squareToLoad, newposition, Quaternion.identity);
        box.transform.localScale = new Vector3(scale,scale);
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
