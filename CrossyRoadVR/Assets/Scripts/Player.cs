using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{


    public float jumpAnglesDegrees;   //跳跃的角度
    public float jumpSpeed;   //跳跃的速度
    private bool isOnPlane = false;//是否在地面上的标志位。


    private Rigidbody rig;
    //凝视的引用
    private CardboardHead GazeHead;

    //最后请求起跳的时间。
    private float LastJumpRequestTime = 0.0f;


    void Start()
    {
        GazeHead = this.GetComponentInChildren<CardboardHead>();
        rig = GetComponent<Rigidbody>();
        Cardboard.SDK.OnTrigger += PullJumpTrigger;
    }

    private void PullJumpTrigger()
    {
    
        RequestJump();


    }

    private void RequestJump()
    {
        LastJumpRequestTime = Time.time;
        rig.WakeUp();

    }

    void Jump()
    {
        if (!GameState.instance.isGameOver)
        {
            //度数转弧度,我们的跳跃角度
            float jumpAngleInRadians = jumpAnglesDegrees * Mathf.Deg2Rad;
            //将头到凝视点的射线方向投影到Vector3.up(0,1,0)的向量为法向量的平面当前也就是平面上
            Vector3 ProjectedVector = Vector3.ProjectOnPlane(GazeHead.Gaze.direction, Vector3.up);
            //模拟跳跃
            Vector3 Jump = Vector3.RotateTowards(LookDirection(), Vector3.up, jumpAngleInRadians, 0);
            rig.velocity = Jump * jumpSpeed;
            isOnPlane = false;
        }
        
    }


    public Vector3 LookDirection()
    {
        return Vector3.ProjectOnPlane(GazeHead.Gaze.direction, Vector3.up);
    }

    void OnCollisionStay(Collision co)
    {
        float time = Time.time - LastJumpRequestTime;
        if (time < 0.1f)
        {
            Jump();
            LastJumpRequestTime = 0.0f;
        }
    }

    void DropOnFloor()
    {
        if (this.transform.position.y<0.0f)
        {
            GameState.instance.isGameOver = true;
        }
    }



    void Update()
    {
        DropOnFloor();
        if (GameState.instance.isGameOver)
        {
            rig.isKinematic = true;
        }

    }
}
