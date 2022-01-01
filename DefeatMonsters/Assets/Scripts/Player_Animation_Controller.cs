using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Controller : MonoBehaviour
{
    // public SPUM_SpriteList _spriteOBj;
    // Set False nếu muốn charater chết luôn
    public bool EditChk = true;
    // public string _code;
    public Animator _anim;
    public enum AttackType
    {
        Sword,
        Bow,
        Magic
    };
    public AttackType attackType;
    // Start is called before the first frame update
    public void Idle()
    {
        PlayAnimation(0);
    }
    public void Run()
    {
        PlayAnimation(1);
    }
    public void Death()
    {
        EditChk = false;
        PlayAnimation(2);
    }
    public void Stun()
    {
        PlayAnimation(3);
    }
    public void Attack()
    {
        switch (attackType)
        {
            case AttackType.Sword:
                AttackSword();
                break;
            case AttackType.Bow:
                AttackBow();
                break;
            case AttackType.Magic:
                AttackMagic();
                break;
        }
    }
    public void AttackSword()
    {
        PlayAnimation(4);
    }
    public void AttackBow()
    {
        PlayAnimation(5);
    }
    public void AttackMagic()
    {
        PlayAnimation(6);
    }
    public void SkillSword()
    {
        PlayAnimation(7);
    }
    public void SkillBow()
    {
        PlayAnimation(8);
    }
    public void SkillMagic()
    {
        PlayAnimation(9);
    }

    public void PlayAnimation(int num)
    {
        switch (num)
        {
            case 0: //Idle
                _anim.SetFloat("RunState", 0f);
                break;

            case 1: //Run
                _anim.SetFloat("RunState", 0.5f);
                break;

            case 2: //Death
                _anim.SetTrigger("Die");
                _anim.SetBool("EditChk", EditChk);
                break;

            case 3: //Stun
                // _anim.SetFloat("RunState", 1.0f);
                _anim.SetTrigger("Stun");
                break;

            case 4: //Attack Sword
                _anim.SetTrigger("Attack");
                _anim.SetFloat("AttackState", 0.0f);
                _anim.SetFloat("NormalState", 0.0f);
                break;

            case 5: //Attack Bow
                _anim.SetTrigger("Attack");
                _anim.SetFloat("AttackState", 0.0f);
                _anim.SetFloat("NormalState", 0.5f);
                break;

            case 6: //Attack Magic
                _anim.SetTrigger("Attack");
                _anim.SetFloat("AttackState", 0.0f);
                _anim.SetFloat("NormalState", 1.0f);
                break;

            case 7: //Skill Sword
                _anim.SetTrigger("Attack");
                _anim.SetFloat("AttackState", 1.0f);
                _anim.SetFloat("NormalState", 0.0f);
                break;

            case 8: //Skill Bow
                _anim.SetTrigger("Attack");
                _anim.SetFloat("AttackState", 1.0f);
                _anim.SetFloat("NormalState", 0.5f);
                break;

            case 9: //Skill Magic
                _anim.SetTrigger("Attack");
                _anim.SetFloat("AttackState", 1.0f);
                _anim.SetFloat("NormalState", 1.0f);
                break;
        }
    }
}
