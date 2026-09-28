using UnityEngine;
using UnityEngine.InputSystem;
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
    public void DisableControls()
    {
        canControlplayer=false;
    }


}
