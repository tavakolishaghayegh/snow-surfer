using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class playercontolloer : MonoBehaviour
{
    [SerializeField] float torqueAmount=1f;
    [SerializeField] float baseSpeed =15f;
    [SerializeField] float BoostSpeed=20f;
    [SerializeField] ParticleSystem powerupParticles;

    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    ScoreManager scoreManager;
    Vector2 moveVector;
     bool canControlplayer = true;
     float previousRotation;
     float TotalRotation;
     int activePowerupCount;
     

    void Start()
    {
       
       moveAction=InputSystem.actions.FindAction("Move");
       myRigidbody2D=GetComponent<Rigidbody2D>();
       surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
       scoreManager=FindAnyObjectByType<ScoreManager>();
    }

    
    void Update()
    {
        if (canControlplayer==true)
        {
             RotatePlayer();
             BoostPlayer();
             CalculateFlips();
            
        }
       
       
    }
    void RotatePlayer()
    {
        
        moveVector=moveAction.ReadValue<Vector2>();
        if(moveVector.x < 0)
        {
             myRigidbody2D.AddTorque(torqueAmount);
        }
         else if(moveVector.x > 0)
        {
             myRigidbody2D.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer()
    {
        
        if(moveVector.y > 0)
        {
            surfaceEffector2D.speed=BoostSpeed;
        }
        else
        {
            surfaceEffector2D.speed=baseSpeed;
        }
    }
    void CalculateFlips()
    {
        float currentRotation=transform.rotation.eulerAngles.z;
        TotalRotation +=Mathf.DeltaAngle(previousRotation, currentRotation);
        if(TotalRotation > 340 || TotalRotation < -340)
        {
            
            TotalRotation = 0 ;
            scoreManager.AddScore(100);
        }
        previousRotation=currentRotation;
    }
    public void DisableControls()
    {
        canControlplayer=false;
    }

    public void ActivatePowerup(PowerupSO powerup)
    {
        powerupParticles.Play();
        activePowerupCount+=1;
        if(powerup.GetPowerupType()== "speed")
        {
            baseSpeed+= powerup.GetValueChange();
            BoostSpeed+= powerup.GetValueChange();

        }
        else if (powerup.GetPowerupType()== "torque")
        {
            torqueAmount+= powerup.GetValueChange();
            
        }
        
    }
    
    public void DeaActivatePowerup(PowerupSO powerup)
    {
        activePowerupCount-=1;
        if(activePowerupCount==0)
        {
            powerupParticles.Stop();
        }
        if(powerup.GetPowerupType()== "speed")
        {
            baseSpeed-= powerup.GetValueChange();
            BoostSpeed-= powerup.GetValueChange();

        }
        else if (powerup.GetPowerupType()== "torque")
        {
            torqueAmount-= powerup.GetValueChange();
            
        }
        
    }


    


}
