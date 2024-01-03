using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player Stats", menuName ="Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int gold;
    public float jumpPower;
    public float speed;
}
