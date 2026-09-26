using UnityEngine;

public class finishline : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D collision) 
  {
    int layerIndex= LayerMask.NameToLayer("player");

    if(collision.gameObject.layer == layerIndex)
    {
      Debug.Log("the player has won!");
    }
    
    
  }
}
