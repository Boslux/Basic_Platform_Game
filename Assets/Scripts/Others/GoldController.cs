using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldController : MonoBehaviour
{
    public Text gold;
    public PlayerStats ps;

    private void Update()
    {
        gold.text = "" + ps.gold;
    }
}
