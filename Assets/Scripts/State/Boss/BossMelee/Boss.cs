//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public class Boss : Entity
//{
//    public Player player { get; private set; }

//    private ICommand<Boss> curCommand;
//    private Queue<ICommand<Boss>> commandQueue = new Queue<ICommand<Boss>>();

//    [Header("Boss info")]
//    [SerializeField] private float moveSpeed;
//    [SerializeField] private float jumpForce;
//    [SerializeField] private float playerCheckAboveDistace;
//    [SerializeField] private float playerCheckInFrontDistace;
//    [SerializeField] private float obstacleCheckDistance;

//    protected override void Awake()
//    {
//        base.Awake();

//        player = PlayerManager.Instance.player;

//    }

//    protected override void Start()
//    {
//        EnqueueCommand(new WaitCommand(3f));
//    }

//    protected override void Update()
//    {
//        if (curCommand == null && commandQueue.Count > 0)
//        {
//            curCommand = commandQueue.Dequeue();
//            curCommand.Execute(this);
//        }

//        if (curCommand != null)
//        {
//            curCommand.Update(this, Time.deltaTime);

//            if (curCommand.Finished)
//            {
//                ICommand<Boss> newCommand = GenerateCommand();
//                EnqueueCommand(newCommand);

//                curCommand = null;
//            }
//        }


//    }

//    public bool IsPlayerAbove() => Physics2D.Raycast(transform.position, Vector2.up, playerCheckAboveDistace, 1 << player.gameObject.layer);
//    public bool IsPlayerInFront() => Physics2D.Raycast(transform.position, Vector2.right * facingDir, playerCheckInFrontDistace, 1 << player.gameObject.layer);
//    public bool IsObstacle() => Physics2D.Raycast(transform.position + new Vector3(3 * facingDir, 0, 0), Vector2.down, obstacleCheckDistance, groundLayer);
   
//    //private void CircleCommand()
//    //{
//    //    EnqueueCommand(new WaitCommand(.9f));
//    //    EnqueueCommand(new MoveCommand(player.transform, moveSpeed));
//    //    EnqueueCommand(new AttackCommand());
//    //}

//    private void EnqueueCommand(ICommand<Boss> command)
//    {
//        commandQueue.Enqueue(command);
//    }

//    private ICommand<Boss> GenerateCommand()
//    {
//        if (IsObstacle())
//            return new JumpCommand(jumpForce);
//        if (Vector2.Distance(player.transform.position, this.transform.position) <= 7)
//            return new AttackCommand();

//        return new MoveCommand(player.transform, moveSpeed);
//    }

//    private bool CheckForJumping()
//    {
//        return true;
//    }

//    protected override void OnDrawGizmos()
//    {
//        base.OnDrawGizmos();

//        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * playerCheckAboveDistace);
//        Gizmos.DrawLine(transform.position, transform.position + new Vector3(playerCheckInFrontDistace * facingDir, 0, 0));
//        Gizmos.DrawLine(transform.position + new Vector3(3 * facingDir, 0, 0), transform.position + new Vector3(3 * facingDir, 0, 0) + Vector3.down * obstacleCheckDistance);
//    }


//    public void AnimationTrigger()
//    {
//        if (curCommand is AttackCommand attackCommand)
//        {
//            attackCommand.AnimationTrigger();
//        }
//    }

//    private void CalFacingDir()
//    {
//        if (transform.rotation.y > 0)
//        {
//            facingRight = false;
//            facingDir = -1;
//        }
//        else
//        {
//            facingRight = true;
//            facingDir = 1;
//        }
//    }
//}
