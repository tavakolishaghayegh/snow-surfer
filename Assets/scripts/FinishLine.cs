using UnityEngine;
using UnityEngine.SceneManagement;

public class finishline : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D collision) 
  {
    int layerIndex= LayerMask.NameToLayer("player");

    if(collision.gameObject.layer == layerIndex)
    {
      SceneManager.LoadScene(0);
    }
    
    
  }
}
