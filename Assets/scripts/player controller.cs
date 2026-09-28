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

    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    Vector2 moveVector;
     bool canControlplayer = true;
     float previousRotation;
     float TotalRotation;
     int FlipCount;

    void Start()
    {
       
       moveAction=InputSystem.actions.FindAction("Move");
       myRigidbody2D=GetComponent<Rigidbody2D>();
       surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
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
            FlipCount += 1;
            TotalRotation = 0 ;
            print(FlipCount);
        }
        previousRotation=currentRotation;
    }
    public void DisableControls()
    {
        canControlplayer=false;
    }


}
