using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

class WeightedSkill
{
    public Command command;
    public float weight;

    public WeightedSkill(Command command, float weight)
    {
        this.command = command;
        this.weight = weight;
    }  
}

public class BossAI : MonoBehaviour
{
    [Header("Setting parameters")]
    [SerializeField] private float _cooldown;
    private float _cooldownTimer;

    
    private Command _command;
    private FlyBoss _boss;
    private Player _player;
    private List<WeightedSkill> _skills;
    

    private void Start()
    {
        _boss = GetComponent<FlyBoss>();
        _player = PlayerManager.Instance.player;
        _cooldownTimer = _cooldown;
        _skills = new List<WeightedSkill>() {
            new WeightedSkill(new AttackSurikenCommand(_boss), 4f),
            new WeightedSkill(new MoveCommand(_boss), 2f),
            new WeightedSkill(new AttackPowerBulletCommand(_boss), 4f)
        };
    }

    private void Update()
    {
        _cooldownTimer -= Time.deltaTime;

        if (_cooldownTimer <= 0 && _boss.finished)
        {
            Command cmd = GenerateCommand(_skills);
            SetCommand(cmd);
            _cooldownTimer = _cooldown;
        }
        
        if (!_boss.finished)
            ActiveCommand();
    }

    private Command GenerateCommand(List<WeightedSkill> skills)
    {
        float total = 0;

        foreach (var s in skills)
            total += s.weight;

        float rand = Random.Range(0, total);
        float sum = 0;

        foreach (var s in skills)
        {
            sum += s.weight;
            if (rand <= sum)
                return s.command;
        }

        return skills[0].command;
    }

    private void SetCommand(Command command)
    {
        this._command = command;
        _boss.finished = false;
    }

    private void ActiveCommand()
    {
        this._command.execute();
    }
}
