using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
public class Score_Writer : MonoBehaviour
{

    string[] read;
    public Text name_field;
    public Text score_field;
    public ScrollRect scroll;
    public float scroll_value;
    string[] names;
    int[] scores;



    // Use this for initialization
    void Start()
    {
        scroll.scrollSensitivity = scroll_value;
        read = File.ReadAllLines("Highscore.txt");
        names = new string[read.Length];
        scores = new int[read.Length];

        for (int i = 0; i < read.Length; i++)
        {
            names[i] = read[i].Substring(0, read[i].IndexOf(" "));
            scores[i] = int.Parse(read[i].Substring(read[i].IndexOf(" ")));

        }

        Array.Sort(scores, names);
        Array.Sort(scores);
        Array.Reverse(scores);
        Array.Reverse(names);
        name_field.text = string.Join(System.Environment.NewLine, names);
        score_field.text = string.Join(System.Environment.NewLine, scores.Select(x => x.ToString()).ToArray());


    }

}