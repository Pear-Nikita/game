using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float standartMovingSpeed = 5f;
    [SerializeField] private float runMovingSpeed = 7.5f;
    private Rigidbody2D rb;
    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;
    public bool isSmash = false;
    
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 vectorInput = GameInput.Instance.GetMovementVector();

        vectorInput = vectorInput.normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + vectorInput * (runMovingSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rb.MovePosition(rb.position + vectorInput * (standartMovingSpeed * Time.fixedDeltaTime));
        }

        if (Mathf.Abs(vectorInput.x) > minMovingSpeed || Mathf.Abs(vectorInput.y) > minMovingSpeed)
        {
            isRunning = true;
        } else
        {
            isRunning = false;
        }
    }

    public bool IsRunning() { return isRunning; } 

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition =  Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }

    public bool IsSmashed() 
    { 
        if(GameInput.Instance.IsPlayerSmashed())
        {
            return  true;
        } else
        {
            return false;
        }
         
    }
}
