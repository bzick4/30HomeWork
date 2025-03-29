
using UnityEngine;

public class WalkBall : MonoBehaviour
{
  private Vector2 startTouchPosition, endTouchPosition;
    private Rigidbody _ball;

    private float moveForce = 7; 
    private float swipeThreshold = 50f; 

    void Start()
    {
        _ball = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0) HandleTouchSwipe();
        if (Input.GetMouseButtonDown(0)) startTouchPosition = Input.mousePosition;
        if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            Move_Ball();
        }
    }

    void HandleTouchSwipe()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
            startTouchPosition = touch.position;

        if (touch.phase == TouchPhase.Ended)
        {
            endTouchPosition = touch.position;
            Move_Ball();
        }
    }

    void Move_Ball()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude >= swipeThreshold)
        {
            Vector3 moveDirection = Vector3.zero;

            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                moveDirection = -swipeDelta.x > 0 ? Vector3.right : Vector3.left;
            else
                moveDirection = -swipeDelta.y > 0 ? Vector3.forward : Vector3.back;

            _ball.velocity = moveDirection * moveForce;
        }
    }
}
