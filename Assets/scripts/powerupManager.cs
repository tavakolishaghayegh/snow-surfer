using UnityEngine;

public class powerupManager : MonoBehaviour
{
 [SerializeField] PowerupSO powerup;
 playercontolloer player;

 SpriteRenderer spriteRenderer;
 float timeLeft;

  void Start()
  {
    player=FindAnyObjectByType<playercontolloer>();
    spriteRenderer=GetComponent<SpriteRenderer>();
    timeLeft=powerup.GetTime();
  }
  void Update()
  {
    CountdownTimer();
  }
  
     
     
      void CountdownTimer()
      {
        if (spriteRenderer.enabled==false)
        {
           if (timeLeft > 0)
           {
               timeLeft -= Time.deltaTime;
               if(timeLeft <= 0)
               {
                  player.DeaActivatePowerup(powerup);
               }
           }
      

      
      
        }
    
    
      }
 
 
  void OnTriggerEnter2D(Collider2D collision) {
    int layerIndex= LayerMask.NameToLayer("player");

    if(collision.gameObject.layer == layerIndex && spriteRenderer.enabled)
    {
      spriteRenderer.enabled=false;
      player.ActivatePowerup(powerup);
      

    
  }
  }

}
