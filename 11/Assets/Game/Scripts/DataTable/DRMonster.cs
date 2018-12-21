using System.Collections.Generic;
using GameFramework;
using GameFramework.DataTable;

/// <summary>
/// 怪物表
/// </summary>
public class DRMonster : DREntity {


    public override void ParseDataRow (string dataRowText) {
        string[] text = DataTableExtension.SplitDataRow (dataRowText);
        int index = 0;
        index++;
        Id = int.Parse (text[index++]);
        AssetName = text[index++];
        Name = text[index++];
        LV = int.Parse(text[index++]);
        exp = int.Parse(text[index++]);
        HP = int.Parse(text[index++]);
        MP = int.Parse(text[index++]);
        S = int.Parse(text[index++]);
        A = int.Parse(text[index++]);
        D = int.Parse(text[index++]);
        I = int.Parse(text[index++]);
        M = int.Parse(text[index++]);
        C = int.Parse(text[index++]);
        L = int.Parse(text[index++]);

        Atk = int.Parse(text[index++]);
        Def = int.Parse(text[index++]);
        MagicAtk = int.Parse(text[index++]);
        MagicDef = int.Parse(text[index++]);
        AtkSpeed = float.Parse(text[index++]);
        Crit = int.Parse(text[index++]);
        CritDamage = int.Parse(text[index++]);
        Hit = int.Parse(text[index++]);
        Agl = int.Parse(text[index++]);
        Counter = int.Parse(text[index++]);
        Double = int.Parse(text[index++]);
        Atk = int.Parse(text[index++]);
        Def = int.Parse(text[index++]);
        HPRecoverPerSecond = int.Parse(text[index++]);
        MPRecoverPerSecond = int.Parse(text[index++]);

        BloodLine = text[index++];
        Profession = text[index++];
        MP_STYLE = text[index++];

        ParseWeapon(text[index++]);
        ParseJob(text[index++]);
        ParseSkill(text[index++]);
        ParseFeature(text[index++]);
    }

    private void AvoidJIT () {
        new Dictionary<int, DRMonster> ();
    }
}