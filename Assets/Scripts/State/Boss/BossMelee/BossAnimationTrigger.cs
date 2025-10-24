//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BossAnimationTrigger : MonoBehaviour
//{
//    [SerializeField] private GameObject prefab;
//    private Boss boss => GetComponentInParent<Boss>();
//    private void AnimationTrigger()
//    {
//        boss.AnimationTrigger();
//    }

//    private void Spash()
//    {
//        GameObject bullet = BulletPoolManager.Instance.GetFromPool(prefab);
//        bullet.GetComponent<Spash>().SetupSpash(boss.transform, new Vector3(boss.facingDir, 0, 0));
//    }
//}
