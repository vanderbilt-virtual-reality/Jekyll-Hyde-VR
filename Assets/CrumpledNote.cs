using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrumpledNote : MonoBehaviour
{
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = myText.GetComponent<Text>();
    }

    // Update is called once per frame
    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Paper")
        {
            myText.text = "Dr. Jekyll presents his compliments to Messrs. Maw. " +
                "He assures them that their last sample is impure and quite useless for his present purpose. " +
                "In the year 18—, Dr. J. purchased a somewhat large quantity from Messrs. M. He now begs them " +
                "to search with most sedulous care, and should any of the same quality be left, forward it to him " +
                "at once. Expense is no consideration. The importance of this to Dr. J. can hardly be exaggerated.";
        }
    }
}
