using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "PowerupSO")]
public class PowerupSO : ScriptableObject
{
   [SerializeField] String powerupType;
   [SerializeField] float valiueChange;
   [SerializeField] float time;

   public string GetPowerupType()
   {
      return powerupType;
   }
   public float GetValueChange()
   {
      return valiueChange;
   }
   public float GetTime()
   {
      return time;
   }
    
}
