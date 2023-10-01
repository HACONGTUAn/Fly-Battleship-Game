using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 inputRaw;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;


    // Start is called before the first frame update
    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

    }
    void Move()
    {
        Vector3 delta = inputRaw * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();

        newPos.x = Mathf.Clamp(transform.position.x+ delta.x, minBounds.x + paddingLeft, maxBounds.x-paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y+ paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        inputRaw = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = true;
        }
    }
}
