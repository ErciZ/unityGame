using GameFramework.Event;
using UnityGameFramework.Runtime;

/// <summary>
/// 死亡事件。
/// </summary>
public sealed class DeadEventArgs : GameEventArgs {
    /// <summary>
    /// 事件编号。
    /// </summary>
    public static readonly int EventId = typeof (DeadEventArgs).GetHashCode ();

    /// <summary>
    /// 获取事件编号。
    /// </summary>
    public override int Id {
        get {
            return EventId;
        }
    }

    /// <summary>
    /// 死亡实体阵营类型
    /// </summary>
    public CampType CampType {
        get;
        private set;
    }

    /// <summary>
    /// 实体数据
    /// </summary>
    /// <returns></returns>
    public EntityData EntityData {
        get;
        private set;
    }

    /// <summary>
    /// 清理事件。
    /// </summary>
    public override void Clear () {
        EntityData = null;
    }

    /// <summary>
    /// 填充事件
    /// </summary>
    /// <param name="UserData"></param>
    public DeadEventArgs Fill (CampType type, EntityData entityData) {
        this.CampType = type;
        this.EntityData = entityData;
        return this;
    }
}