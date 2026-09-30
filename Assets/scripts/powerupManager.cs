using UnityEngine;

public class powerupManager : MonoBehaviour
{
 [SerializeField] PowerupSO powerup;
 playercontolloer player;
  void Start()
  {
    player=FindAnyObjectByType<playercontolloer>();
  }
  void OnTriggerEnter2D(Collider2D collision) {
    int layerIndex= LayerMask.NameToLayer("player");

    if(collision.gameObject.layer == layerIndex)
    {
      player.ActivatePowerup(powerup);
      

    
  }
  }

}
