using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private string currentAnim = "";

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentAnim.Equals(""))
        {
            WaitUntilDone();
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentAnim = "JumpFront";
            anim.Play(currentAnim, 0, 0);
        }
        else
        {
            anim.Play("IdleFront");
        }
    }

    private void WaitUntilDone()
    {
        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            currentAnim = "";
        }
    }
}
