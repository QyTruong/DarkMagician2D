//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WaitCommand : ICommand<Boss>
//{
//    private bool finished = false;
//    public bool Finished => finished;

//    private float timer;
//    private float waitTime;

//    public WaitCommand(float _waitTime) => waitTime = _waitTime;

//    public void Execute(Boss _boss)
//    {
//        _boss.anim.SetBool("idle", true);
//        timer = waitTime;
//    }

//    public void Update(Boss _boss, float _commandTime)
//    {
//        timer -= _commandTime;
       
//        if (timer <= 0)
//        {
//            _boss.anim.SetBool("idle", false);
//            finished = true;
//        }
//    }
//}
