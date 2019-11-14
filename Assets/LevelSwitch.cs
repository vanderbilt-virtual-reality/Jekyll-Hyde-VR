using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class LevelSwitch : MonoBehaviour
{
    public int curLevel = 0;
    static bool entering = true;

    public string[] levelNames = new string[3] { "House interior", "courtyard_scene", "Surgical Theater" };

    // Start is called before the first frame update
    void Start()
    {
        GameObject entrance = GameObject.FindWithTag("DoorEnter");
        GameObject exit = GameObject.FindWithTag("DoorExit");
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 startPos;
        if (entering)
        {
            startPos = new Vector3(entrance.transform.position.x, 1.0f, entrance.transform.position.z);
            player.transform.rotation = GameObject.FindWithTag("DoorEnter").transform.rotation;
        } else
        {
            startPos = new Vector3(exit.transform.position.x, 1.0f, exit.transform.position.z);
            player.transform.rotation = GameObject.FindWithTag("DoorExit").transform.rotation;
        }
        player.transform.position = startPos;
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
                entering = false;
                SteamVR_LoadLevel.Begin(levelNames[curLevel]);
            }
            else if (gameObject.GetComponent<OVRGrabber>().grabbedObject.gameObject.tag == "DoorExit")
            {
                Debug.Log(gameObject.GetComponent<OVRGrabber>().grabbedObject.gameObject.tag);
                Debug.Log(curLevel);
                curLevel++;
                Debug.Log(curLevel);
                entering = true;
                SteamVR_LoadLevel.Begin(levelNames[curLevel]);
            }
        }
        
    }
}
