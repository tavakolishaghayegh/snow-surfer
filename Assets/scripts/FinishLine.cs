using UnityEngine;
using UnityEngine.SceneManagement;

public class finishline : MonoBehaviour
{
  [SerializeField] float restartDelay=1f;
  [SerializeField] ParticleSystem finishParticles;
  void OnTriggerEnter2D(Collider2D collision) 
  {
    int layerIndex= LayerMask.NameToLayer("player");

    if(collision.gameObject.layer == layerIndex)
    {
      finishParticles.Play();
      Invoke("ReloadScene" ,restartDelay );

      
    }
    
    
  }
  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
