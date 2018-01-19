using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour
{
    public void startscore()
    {
        Application.LoadLevel("GameTest1");
        Cursor.visible = false;

    }

    public void startstory()
    {
        Application.LoadLevel("Story Recap");
        Cursor.visible = false;

    }

}
