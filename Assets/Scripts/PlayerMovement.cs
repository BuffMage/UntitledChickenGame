using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int index = 0;
    private bool playerSpawned = false;
    [SerializeField]
    private float playerSpeed;
    private bool jumping = false;
    private Vector3 targetPosition;
    private float jumpScale = 0f;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float playerHeightOffset;
    [SerializeField]
    private float timeToDash;
    private float dashTimer = 0f;
    private bool dashing = false;
    [SerializeField]
    private float dashDistance;
    private Vector3 facing = Vector3.forward;
    private bool jumpingUp = false;
    private float jumpUpTimer = 0f;
    [SerializeField]
    private float timeToJumpUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LaneManager.areLanesReady)
        {
            JumpUp();
            if (!jumping && !dashing)
            {
                FwdBwdMovement();
                SideMovement();
                return;
            }
            if (!dashing && !jumpingUp)
            {
                Jumping();
                return;
            }
            if (!jumpingUp)
            {
                Dash();
            }
        }
    }

    void SideMovement()
    {
        Vector3 sideMovement = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            sideMovement += Vector3.forward;
            facing = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            sideMovement -= Vector3.forward;
            facing = Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("Dashing");
            dashing = true;
            dashTimer = 0f;
        }
        this.transform.Translate(sideMovement * Time.deltaTime * playerSpeed, Space.World);
    }

    void FwdBwdMovement()
    {
        if (jumpingUp) return;
        if (!playerSpawned)
        {
            this.transform.position = new Vector3(LaneManager.getLanePosition(0), 1, 0);
            playerSpawned = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            index++;
            SetUpJump();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            index--;
            SetUpJump();
        }
    }

    void SetUpJump()
    {
        if (index < 0 || index >= LaneManager.getNumLanes())
            {
                index = Mathf.Clamp(index, 0, LaneManager.getNumLanes() - 1);
            }
            else
            {
                jumping = true;
                targetPosition = new Vector3(LaneManager.getLanePosition(index), 1, this.transform.position.z);
                jumpScale = Mathf.Abs(targetPosition.x - transform.position.x);
            }
    }

    void Jumping()
    {
        Vector3 targetPosX = new Vector3(targetPosition.x, 0, 0);
        Vector3 targetPosY = new Vector3(0, targetPosition.y, 0);
        Vector3 xMovement = new Vector3(transform.position.x, 0, 0);
        xMovement = Vector3.MoveTowards(xMovement, targetPosX, jumpSpeed * Time.deltaTime);
        Vector3 yMovement = new Vector3(0, transform.position.y, 0);
        yMovement = new Vector3(0, jumpHeight * Mathf.Sin((Mathf.PI * Mathf.Abs(transform.position.x - targetPosition.x) / jumpScale)), 0);
        xMovement.z = transform.position.z;
        yMovement.y += playerHeightOffset;
        transform.position = xMovement + yMovement;
        if (xMovement.x == targetPosX.x)
        {
            jumping = false;
        }
    }

    void JumpUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jumpingUp)
        {
            jumpingUp = true;
            jumpUpTimer = 0f;
        }
        if (jumpingUp)
        {
            float y = playerHeightOffset;
            jumpUpTimer += Time.deltaTime;
            float progress = Mathf.Lerp(0, 1, jumpUpTimer / timeToJumpUp);
            y += jumpHeight * Mathf.Sin(Mathf.PI * progress);
            Vector3 newPos = transform.position;
            if (jumpUpTimer > timeToJumpUp)
            {
                jumpingUp = false;
                newPos.y = playerHeightOffset;
            }
            else
            {
                newPos.y = y;
            }
            transform.position = newPos;
        }
    }

    void Dash()
    {
        dashTimer += Time.deltaTime;
        transform.Translate((facing * dashDistance * Time.deltaTime) / timeToDash, Space.World);
        if (dashTimer > timeToDash)
        {
            dashing = false;
        }
    }
}
