using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float restartDelay=1f;
  [SerializeField] ParticleSystem crashParticles;
  playercontolloer playercontolloer;
  void Start()
  {
    playercontolloer=FindAnyObjectByType<playercontolloer>();
  }
  void OnTriggerEnter2D(Collider2D collision) {
    
    int layerIndex=LayerMask.NameToLayer("Floor");

    if (collision.gameObject.layer == layerIndex)
    {
      playercontolloer.DisableControls();
      crashParticles.Play();
     Invoke("ReloadScene",restartDelay);
    }
    
  }
  void ReloadScene()
  {
    
    SceneManager.LoadScene(0);
  }

}
