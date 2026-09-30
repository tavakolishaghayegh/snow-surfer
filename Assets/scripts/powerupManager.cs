using UnityEngine;

public class powerupManager : MonoBehaviour
{
 [SerializeField] PowerupSO powerup;
 playercontolloer player;

 SpriteRenderer spriteRenderer;
  void Start()
  {
    player=FindAnyObjectByType<playercontolloer>();
    spriteRenderer=GetComponent<SpriteRenderer>();
  }
  void OnTriggerEnter2D(Collider2D collision) {
    int layerIndex= LayerMask.NameToLayer("player");

    if(collision.gameObject.layer == layerIndex)
    {
      spriteRenderer.enabled=false;
      player.ActivatePowerup(powerup);
      

    
  }
  }

}
