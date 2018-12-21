using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

[Serializable]
public class FightEntityData : EntityData {
    protected List<WeaponData> weaponDatas = new List<WeaponData> ();
    protected List<SkillData> skillDatas = new List<SkillData>();
    protected List<FeatureData> featureDatas = new List<FeatureData>();
    protected List<JobData> jobDatas = new List<JobData>();

    public FightEntityData (int entityId, int typeId, CampType camp) : base (entityId, typeId) {
        this.Camp = camp;
    }

    /// <summary>
    /// 改变名字
    /// </summary>
    /// <param name="name"></param>
    public void ChangeName (string name) {
        this.Name = name;
    }

    /// <summary>
    /// 增加MP
    /// </summary>
    /// <param name="value"></param>
    public void AddMP (int value) {
        this.MP += value;

        if (this.MP > this.MaxMP) {
            this.MP = this.MaxMP;
        }
    }

    /// <summary>
    /// 消耗MP
    /// </summary>
    /// <param name="value"></param>
    public void CostMP (int value) {
        this.MP -= value;

        if (this.MP < 0) {
            this.MP = 0;
        }
    }

    /// <summary>
    /// 获取战斗力数值
    /// </summary>
    /// <returns></returns>
    public int GetPower () {
        int hpPower = this.MaxHP / 5;
        int defPower = this.Def * 3;
        int atkPower = this.Atk;
        int atkSpeedPower = (int)(1 / this.AtkSpeed);
        int moveSpeedPower = (int)this.MoveSpeed;
        int atkRangePower = (int)(this.AtkRange / 2);
        
        return hpPower + defPower + atkPower + atkSpeedPower + moveSpeedPower + atkRangePower;
    }

    /// <summary>
    /// 获取战斗力对应的等级
    /// </summary>
    /// <param name="power"></param>
    /// <returns></returns>
    public int GetPowerLevel (int power = -1) {
        if (power < 0) {
            power = GetPower();
        }

        if (power < 15) return 0;
        if (power < 20) return 1;
        if (power < 35) return 2;
        if (power < 55) return 3;
        if (power < 85) return 4;
        if (power < 105) return 5;
        if (power < 135) return 6;
        if (power < 170) return 7;
        if (power < 230) return 8;

        return 9;
    }   

    /// <summary>
    /// 获取武器数据列表
    /// </summary>
    /// <returns></returns>
    public List<WeaponData> GetWeaponDatas() {
        return weaponDatas;
    }

    /// <summary>
    /// 获取副职业数据列表
    /// </summary>
    /// <returns></returns>
    public List<JobData> GetJobDatas()
    {
        return jobDatas;
    }

    /// <summary>
    /// 获取专长数据列表
    /// </summary>
    /// <returns></returns>
    public List<FeatureData> GetFeatureDatas()
    {
        return featureDatas;
    }

    /// <summary>
    /// 获取技能数据列表
    /// </summary>
    /// <returns></returns>
    public List<SkillData> GetSkillDatas()
    {
        return skillDatas;
    }

    /// <summary>
    /// 名字
    /// </summary>
    /// <returns></returns>
    public string Name {
        get;
        protected set;
    }

    /// <summary>
    /// 魔法值
    /// </summary>
    /// <returns></returns>
    public int MP {
        get;
        protected set;
    }

    /// <summary>
    /// 最大魔法值
    /// </summary>
    /// <returns></returns>
    public int MaxMP {
        get;
        protected set;
    }

    /// <summary>
    /// 移动速度。
    /// </summary>
    public float MoveSpeed {
        get;
        protected set;
    }

    /// <summary>
    /// 旋转速度。
    /// </summary>
    public float RotateSpeed {
        get;
        protected set;
    }

    /// <summary>
    /// 攻击力
    /// </summary>
    public int Atk {
        get;
        protected set;
    }
    
    /// <summary>
    /// 攻击动画时间（秒）
    /// </summary>
    public float AtkAnimTime {
        get;
        protected set;
    }

    /// <summary>
    /// 攻击范围
    /// </summary>
    public float AtkRange {
        get;
        protected set;
    }
    
    /// <summary>
    /// 攻速
    /// </summary>
    public float AtkSpeed {
        get;
        protected set;
    }

    public int DeadEffectId {
        get;
        protected set;
    }

    public int DeadSoundId {
        get;
        protected set;
    }

    /// <summary>
    /// 角色阵营。
    /// </summary>
    public CampType Camp
    {
        get;
        protected set;
    } = CampType.Unknown;

    /// <summary>
    /// 当前生命。
    /// </summary>
    public int HP {
        get;
        set;
    }

    /// <summary>
    /// 最大生命。
    /// </summary>
    public int MaxHP {
        get;
        protected set;
    }

    /// <summary>
    /// 生命百分比。
    /// </summary>
    public float HPRatio {
        get {
            return MaxHP > 0 ? (float) HP / MaxHP : 0f;
        }
    }

    /// <summary>
    /// 防御。
    /// </summary>
    public int Def {
        get;
        protected set;
    }

    /// <summary>
    /// 等级
    /// </summary>
    /// <returns></returns>
    public int LV
    {
        get;
        protected set;
    }

    /// <summary>
    /// 经验值
    /// </summary>
    /// <returns></returns>
    public int exp
    {
        get;
        protected set;
    }



    /// <summary>
    /// 力量
    /// </summary>
    /// <returns></returns>
    public int S
    {
        get;
        protected set;
    }

    /// <summary>
    /// 敏捷
    /// </summary>
    /// <returns></returns>
    public int A
    {
        get;
        protected set;
    }

    /// <summary>
    /// 耐力
    /// </summary>
    /// <returns></returns>
    public int D
    {
        get;
        protected set;
    }

    /// <summary>
    /// 智力
    /// </summary>
    /// <returns></returns>
    public int I
    {
        get;
        protected set;
    }

    /// <summary>
    /// 神秘
    /// </summary>
    /// <returns></returns>
    public int M
    {
        get;
        protected set;
    }

    /// <summary>
    /// 魅力
    /// </summary>
    /// <returns></returns>
    public int C
    {
        get;
        protected set;
    }

    /// <summary>
    /// 幸运
    /// </summary>
    /// <returns></returns>
    public int L
    {
        get;
        protected set;
    }

    /// <summary>
    /// 魔攻 magicatk
    /// </summary>
    /// <returns></returns>
    public int MagicAtk
    {
        get;
        protected set;
    }

    /// <summary>
    /// 魔防
    /// </summary>
    /// <returns></returns>
    public int MagicDef
    {
        get;
        protected set;
    }

    /// <summary>
    /// 暴击
    /// </summary>
    /// <returns></returns>
    public int Crit
    {
        get;
        protected set;
    }

    /// <summary>
    /// 爆伤
    /// </summary>
    /// <returns></returns>
    public int CritDamage
    {
        get;
        protected set;
    }

    /// <summary>
    /// 命中
    /// </summary>
    /// <returns></returns>
    public int Hit
    {
        get;
        protected set;
    }

    /// <summary>
    /// 闪避
    /// </summary>
    /// <returns></returns>
    public int Agl
    {
        get;
        protected set;
    }

    /// <summary>
    /// 反击
    /// </summary>
    /// <returns></returns>
    public int Counter
    {
        get;
        protected set;
    }

    /// <summary>
    /// 连击
    /// </summary>
    /// <returns></returns>
    public int Double
    {
        get;
        protected set;
    }

    /// <summary>
    /// 每秒血量回复
    /// </summary>
    /// <returns></returns>
    public int HPRecoverPerSecond
    {
        get;
        protected set;
    }

    /// <summary>
    /// 每秒魔量回复
    /// </summary>
    /// <returns></returns>
    public int MPRecoverPerSecond
    {
        get;
        protected set;
    }



    /// <summary>
    /// 血统
    /// </summary>
    /// <returns></returns>
    public string BloodLine
    {
        get;
        protected set;
    }



    /// <summary>
    /// 职业  profession
    /// </summary>
    /// <returns></returns>
    public string Profession
    {
        get;
        protected set;
    }

    /// <summary>
    /// 能量体系  MP STYLE
    /// </summary>
    /// <returns></returns>
    public string MP_STYLE
    {
        get;
        protected set;
    }



}