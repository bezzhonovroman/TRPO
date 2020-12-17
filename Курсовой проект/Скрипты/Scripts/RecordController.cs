using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordController : MonoBehaviour
{
    [SerializeField]
    private Text playername;
    [SerializeField]
    private Text score;

    public string Name { get { return playername.text; } set { playername.text = value; } }
    public int Score { get { return int.Parse(score.text); } set { score.text = value.ToString(); } }
}
