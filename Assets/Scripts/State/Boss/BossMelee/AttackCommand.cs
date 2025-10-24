//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AttackCommand : ICommand<Boss>
//{
//    private bool finished = false;
//    public bool Finished => finished;

//    private bool triggerCalled;

//    public void Execute(Boss _boss)
//    {
//        _boss.anim.SetBool("attack", true);
//        triggerCalled = false;
//    }

//    public void Update(Boss _boss, float _commandTime)
//    {
//        _boss.SetVelocity(0, 0);

//        if (triggerCalled)
//        {
//            _boss.anim.SetBool("attack", false);
//            finished = true;
//        }
//    }

//    public void AnimationTrigger()
//    {
//        triggerCalled = true;
//    }
//}
