using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{
    public bool enter = true;
    private BoxCollider grabbable;
    public int curLevel;
    public int total;
    public Text toast;
    private bool hasBeenGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<BoxCollider>();
        toast = toast.GetComponent<Text>();
    }

    private void onTimedEvent(object sender, ElapsedEventArgs elapsedEventArg)
    {
        toast.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            if (!hasBeenGrabbed)
            {
                LevelSwitch.count[curLevel]++;
                hasBeenGrabbed = true;

                toast.text = "Clues found: " + LevelSwitch.count[curLevel] + "/" + total;
                System.Timers.Timer aTimer;
                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(this.onTimedEvent);
                aTimer.Interval = 5000;
                aTimer.Enabled = true;
            }

            

            if (total <= LevelSwitch.count[curLevel])
            {
                toast.text = "You hear the click of a door unlocking...";
                LevelSwitch.finish[curLevel] = true;
            }
        }
    }
}
