using System;
using System.Collections.Generic;
using GameFramework;
using GameFramework.DataTable;
using UnityEngine;

[Serializable]
public class MonsterData : FightEntityData {

    public MonsterData (int entityId, int typeId, CampType camp, int prize) : base (entityId, typeId, camp) {
        IDataTable<DRMonster> dtMonster = GameEntry.DataTable.GetDataTable<DRMonster> ();
        DRMonster drMonster = dtMonster.GetDataRow (typeId);
        if (drMonster == null) {
            return;
        }

        Name = drMonster.Name;
        LV = drMonster.LV;
        exp = drMonster.exp;
        HP = drMonster.HP;
        MP = drMonster.MP;
        MaxHP = HP;
        MaxMP = MP;
        S = drMonster.S;
        A = drMonster.A;
        D = drMonster.D;
        I = drMonster.I;
        M = drMonster.M;
        C = drMonster.C;
        L = drMonster.L;

        Atk = drMonster.Atk;
        Def = drMonster.Def;
        MagicAtk = drMonster.MagicAtk;
        MagicDef = drMonster.MagicDef;
        AtkSpeed = drMonster.AtkSpeed;
        Crit = drMonster.Crit;
        CritDamage = drMonster.CritDamage;
        Hit = drMonster.Hit;
        Agl = drMonster.Agl;
        Counter = drMonster.Counter;
        Double = drMonster.Double;
        HPRecoverPerSecond = drMonster.HPRecoverPerSecond;
        MPRecoverPerSecond = drMonster.MPRecoverPerSecond;

        BloodLine = drMonster.BloodLine;
        Profession = drMonster.Profession;
        MP_STYLE = drMonster.MP_STYLE;


        for (int i = 0; i < drMonster.GetWeaponCount(); i++)
        {
            weaponDatas.Add(new WeaponData(EntityExtension.GenerateSerialId(), drMonster.GetWeaponID(i), Id, Camp));
        }
        for (int i = 0; i < drMonster.GetSkillCount(); i++)
        {
            skillDatas.Add(new SkillData(EntityExtension.GenerateSerialId(), drMonster.GetSkillID(i), Id, Camp));
        }
        for (int i = 0; i < drMonster.GetJobCount(); i++)
        {
            jobDatas.Add(new JobData(EntityExtension.GenerateSerialId(), drMonster.GetJobID(i), Id, Camp));
        }
        for (int i = 0; i < drMonster.GetFeatureCount(); i++)
        {
            featureDatas.Add(new FeatureData(EntityExtension.GenerateSerialId(), drMonster.GetFeatureID(i), Id, Camp));
        }
        this.Prize = prize;

        for (int i = 0; i < drMonster.GetWeaponCount (); i++) {
            weaponDatas.Add (new WeaponData (EntityExtension.GenerateSerialId (), drMonster.GetWeaponID (i), Id, Camp));
        }
    }

    /// <summary>
    /// 调整属性
    /// </summary>
    /// <param name="powerPercent">调整百分比</param>
    public void AjustPower (float powerPercent) {
        SeekRange = SeekRange * powerPercent;
        AtkSpeed = AtkSpeed - AtkSpeed * (powerPercent - 1);
        Atk = (int) (Atk * powerPercent);
        Def = (int) (Def * powerPercent);
        HP = (int) (HP * powerPercent);

        MaxHP = HP;
        if (AtkSpeed < 0.5f) {
            AtkSpeed = 0.5f;
        }

        PowerPercent = powerPercent;
    }
    
    /// <summary>
    /// 强化百分比（正常为1）
    /// </summary>
    /// <returns></returns>
    public float PowerPercent {
        get;
        private set;
    }

    /// <summary>
    /// 攻击范围
    /// </summary>
    public float SeekRange {
        get;
        protected set;
    }
    

    /// <summary>
    /// 怪物奖励分值
    /// </summary>
    /// <returns></returns>
    public int Prize {
        get;
        protected set;
    }

    /// <summary>
    /// 血量不超过最大值
    /// </summary>
    private void RefreshData()
    {
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
        if (MP > MaxMP)
        {
            MP = MaxMP;
        }

    }



    /// <summary>
    /// 升级加强英雄
    /// </summary>
    public void PowerUpByLV()
    {
        PowerUpByAbsValue(HP: 100, MP: 30, S: 1, A: 1, D: 1, I: 1);
        UpdateAttribute();
    }

    /// <summary>
    /// 根据主属性，提升其他属性
    /// </summary>
    public void UpdateAttribute()
    {
        int atk = Mathf.FloorToInt((this.S * 20f + this.A * 1f + this.D * 2f +
                                  this.A * 2f + this.I * 1f + this.M * 1f) / 10f);
        int def = Mathf.FloorToInt((this.S * 20f + this.A * 1f + this.D * 2f +
                                  this.A * 2f + this.I * 1f + this.M * 1f) / 10f);
        int magicatk = Mathf.FloorToInt((this.S * 20f + this.A * 1f + this.D * 2f +
                                  this.A * 2f + this.I * 1f + this.M * 1f) / 10f);
        int magicdef = Mathf.FloorToInt((this.S * 20f + this.A * 1f + this.D * 2f +
                                  this.A * 2f + this.I * 1f + this.M * 1f) / 10f);

        PowerUpByAbsValue(Atk: atk, Def: def, MagicAtk: magicatk, MagicDef: magicdef);



    }


    /// <summary>
    /// 根据给定的属性值，加强英雄
    /// </summary>
    public void PowerUpByAbsValue(int HP = 0, int MP = 0, int S = 0, int A = 0,
                                      int D = 0, int I = 0, int M = 0, int C = 0,
                                      int L = 0, int Atk = 0, int Def = 0, int MagicAtk = 0,
                                      int MagicDef = 0, int Crit = 0, int CritDamage = 0,
                                      int Hit = 0, int Agl = 0, int Counter = 0,
                                      int Double = 0, int HPRecoverPerSecond = 0,
                                      int MPRecoverPerSecond = 0,
                                       float AtkSpeed = 0)
    {
        if (HP != 0)
        {
            this.MaxHP += HP;
            this.HP = this.MaxHP;
        }
        if (MP != 0)
        {
            this.MaxMP += MP;
            this.MP = this.MaxMP;
        }

        this.S += S;
        this.A += A;
        this.D += D;
        this.I += I;
        this.M += M;
        this.C += C;
        this.L += L;
        this.Atk += Atk;
        this.Def += Def;
        this.MagicAtk += MagicAtk;
        this.MagicDef += MagicDef;
        this.Crit += Crit;
        this.CritDamage += CritDamage;
        this.Hit += Hit;
        this.Agl += Agl;
        this.Double += Double;
        this.Counter += Counter;
        this.HPRecoverPerSecond += HPRecoverPerSecond;
        this.MPRecoverPerSecond += MPRecoverPerSecond;


        this.AtkSpeed += AtkSpeed;


    }

}