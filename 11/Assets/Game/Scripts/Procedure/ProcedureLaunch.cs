using System;
using GameFramework;
using GameFramework.Event;
using GameFramework.Localization;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
public class ProcedureLaunch : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        
		Log.Debug("Launch 进程开始!!");
        // 构建信息：发布版本时，把一些数据以 Json 的格式写入 Assets/GF_JustOneLevel/Configs/BuildInfo.txt，供游戏逻辑读取。
        //GameEntry.BuiltinData.InitBuildInfo();

        // 默认字典：加载默认字典文件 Assets/GF_JustOneLevel/Configs/DefaultDictionary.xml。
        // 此字典文件记录了资源更新前使用的各种语言的字符串，会随 App 一起发布，故不可更新。
        //GameEntry.BuiltinData.InitDefaultDictionary();
    
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);

    }

    //protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    //{
    //    base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

    //    SceneComponent scene
    //        = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

    //    // 切换场景
    //    scene.LoadScene("Assets/Scenes/Menu.unity", this);

    //    // 切换流程
    //    ChangeState<ProcedureMenu>(procedureOwner);
    //}
    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        ChangeState<ProcedureSplash>(procedureOwner);
    }

}