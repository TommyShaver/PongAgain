using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static BallMovement instance {get; private set;}

    [SerializeField] float _speedOfBall;
    [SerializeField] float _ballSpeedMovementIncrease = 0;

    public Rigidbody2D _rb;
    public GameObject _ball;

    // Opening Logic ============================================================
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        _rb = GetComponent<Rigidbody2D>();
    }

    //Ball Logic ================================================================
    public void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        _rb.velocity = new Vector2 (_speedOfBall * x,_speedOfBall * y);
    }

    public void ResetBallPosition()
    {
        _speedOfBall = 5;
        _ball.transform.position = Vector3.zero;
    
        _rb.velocity = Vector2.zero;
        LaunchBall();
    }

    
    // Collision Logic ==========================================================
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Padel"))
        {
            if(_ballSpeedMovementIncrease == 5)
            {
                _ballSpeedMovementIncrease = 0;
                _speedOfBall = _speedOfBall + 5;
            }
            else
            {
                _ballSpeedMovementIncrease++;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "leftGoal")
        {
            GameManager.gameManagerInstance.UpdateScore(0, 1);
            GoalWinnerFont.goalWinnerTextIntance.PlayerGoalLeft();
        }
        if (collision.gameObject.tag == "rightGoal")
        {
            GameManager.gameManagerInstance.UpdateScore(1, 0);
            GoalWinnerFont.goalWinnerTextIntance.PlayerGoalRight();
        }
    }
}
