//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class JumpCommand : ICommand<Boss>
//{
//    private bool finished = false;
//    public bool Finished => finished;

//    private float jumpForce;

//    internal JumpCommand(float _jumpForce)
//    {
//        this.jumpForce = _jumpForce;
//    }

//    public void Execute(Boss _boss)
//    {
//        Debug.Log("hello");
//        _boss.rb.velocity = new Vector2(_boss.rb.velocity.x, jumpForce);
//        _boss.anim.SetBool("jump", true);
//    }

//    public void Update(Boss _boss, float _commandTime)
//    {

//        _boss.anim.SetBool("jump", false);
//        finished = true;
//    }
//}
