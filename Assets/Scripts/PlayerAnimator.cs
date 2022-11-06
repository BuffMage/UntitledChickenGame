using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private string currentAnim = "";
    private bool lastForward = false;
    private bool lastLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentAnim.Equals(""))
        {
            WaitUntilDone();
            return;
        }
        Idle(lastForward, lastLeft);
    }

    public void Walk(bool forward, bool left)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DashBack") || anim.GetCurrentAnimatorStateInfo(0).IsName("DashFront"))
        {
            return;
        }
        if (left)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        if (!forward)
        {
            currentAnim = "WalkFront";
        }
        else
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            currentAnim = "WalkBack";
        }
        anim.Play(currentAnim);
        lastForward = forward;
        lastLeft = left;
    }

    public void Jump(bool forward, bool left)
    {
        if (left)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        if (!forward)
        {
            currentAnim = "JumpFront";
        }
        else
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            currentAnim = "JumpBack";
        }
        anim.Play(currentAnim, 0, 0);
        lastForward = forward;
        lastLeft = left;
    }

    public void Dash(bool forward, bool left)
    {
        if (left)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if (!forward)
        {
            currentAnim = "DashFront";
        }
        else
        {
            //spriteRenderer.flipX = !spriteRenderer.flipX;
            currentAnim = "DashBack";
        }
        anim.Play(currentAnim);
        lastForward = forward;
        lastLeft = left;
    }

    public void Idle(bool forward, bool left)
    {
        if (left)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        if (!forward)
        {
            currentAnim = "IdleFront";
        }
        else
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            currentAnim = "IdleBack";
        }
        anim.Play(currentAnim);
    }

    public void Die()
    {
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if (currentAnim.Equals("ForeverDeath"))
        {
            anim.Play(currentAnim, 0, 0);
            return;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .55f)
        {
            currentAnim = "ForeverDeath";
            anim.Play(currentAnim);
            return;
        }
        anim.Play("Death");
    }

    private void WaitUntilDone()
    {
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            currentAnim = "";
        }
    }
}
