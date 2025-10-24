using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance { get => instance; }

    public Player player;

    private PlayerManager()
    {
       
    }

    private void Awake()
    {
        if (instance == null)
            PlayerManager.instance = this;
        else
            Destroy(gameObject);
    }
}
