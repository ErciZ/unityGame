using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using System;
using System.Threading;


public class ProcedureMenu : ProcedureBase
{
    private SurvivalGame survivalGame = null;
    protected override void OnInit(ProcedureOwner procedureOwner)
    {
        base.OnInit(procedureOwner);

        this.m_ProcedureOwner = procedureOwner;
        survivalGame = new SurvivalGame();
    }
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
		Log.Debug("进入主流程，可以在这里加载菜单UI与生成游戏。");
        survivalGame.Initialize();

        // 订阅事件
        GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

        // 加载UI
        //GameEntry.UI.OpenUIForm(UIFormId.Menu, this);

        // 加载UI
        GameEntry.UI.OpenUIForm("Assets/Game/Prefab/UI_Menu.prefab", "UI_Menu", this);

        GameEntry.Entity.ShowEntity<Hero_Logic>(1, "Assets/Game/Prefab/Hero.prefab", "Heros");


    }
    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);

        // 取消订阅
        GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

        // 停止音乐
        //GameEntry.Sound.StopMusic();

        // 关闭所有UI

        GameEntry.UI.CloseAllLoadedUIForms();


    
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds) {

        GlobalGame.GameTimes += elapseSeconds;

        //if (survivalGame != null)
        //{
        //    if (!GlobalGame.IsPause)
        //    {
        //        survivalGame.Update(elapseSeconds, realElapseSeconds);
        //    }
        //    else
        //    {
        //        GameOver(procedureOwner);
        //    }
        //}
    }



    private void OnOpenUIFormSuccess(object sender, GameEventArgs e){
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        //判断userData是否为自己
        if (ne.UserData != this){
            return;
        }
        Log.Debug("UI_Menu:Congratulation!");
    }
}


