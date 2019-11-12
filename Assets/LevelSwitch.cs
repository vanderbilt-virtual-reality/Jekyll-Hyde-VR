using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LevelSwitch : MonoBehaviour
{
    public int curLevel = 0;

    public string[] levelNames = new string[3] { "House interior", "courtyard_scene", "Surgical Theater" };

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<OVRGrabber>().grabbedObject != null)
        {
            print(gameObject.GetComponent<OVRGrabber>().grabbedObject.gameObject);
            if (gameObject.GetComponent<OVRGrabber>().grabbedObject.gameObject.tag == "DoorEnter")
            {
                Debug.Log(gameObject.GetComponent<OVRGrabber>().grabbedObject.gameObject.tag);
                Debug.Log(curLevel);
                curLevel--;
                Debug.Log(curLevel);
                SteamVR_LoadLevel.Begin(levelNames[curLevel]);
            }
            else if (gameObject.GetComponent<OVRGrabber>().grabbedObject.gameObject.tag == "DoorExit")
            {
                Debug.Log(gameObject.GetComponent<OVRGrabber>().grabbedObject.gameObject.tag);
                Debug.Log(curLevel);
                curLevel++;
                Debug.Log(curLevel);
                SteamVR_LoadLevel.Begin(levelNames[curLevel]);
            }
        }
        
    }
}
