//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class MoveCommand : ICommand<Boss>
//{
//    private bool finished = false;
//    public bool Finished => finished;

//    private Transform destiny;
//    private float moveSpeed;

//    internal MoveCommand(Transform _destiny, float _moveSpeed)
//    {
//        this.destiny = _destiny;
//        this.moveSpeed = _moveSpeed;
//    }

//    public void Execute(Boss _boss)
//    {
//        _boss.anim.SetBool("run", true);
//    }

//    public void Update(Boss _boss, float _commandTime)
//    {
//        float distanceFromPlayer = _boss.transform.position.x - destiny.transform.position.x;
//        float threshold = .5f;

//        if (distanceFromPlayer > threshold && _boss.facingRight)
//        {
//            _boss.Flip();
//        }
//        else if (distanceFromPlayer < -threshold && !_boss.facingRight)
//        {
//            _boss.Flip();
//        }

//        _boss.rb.velocity = new Vector2(moveSpeed * _boss.facingDir, _boss.rb.velocity.y);

//        if (Vector2.Distance(_boss.transform.position, destiny.transform.position) < 7f || _boss.IsObstacle())
//        {
//            _boss.anim.SetBool("run", false);
//            finished = true;
//        }
//    }
//}
