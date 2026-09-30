using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "PowerupSO")]
public class PowerupSO : ScriptableObject
{
   [SerializeField] String powerupType;
   [SerializeField] float valiueChange;
   [SerializeField] float time;
    
}
