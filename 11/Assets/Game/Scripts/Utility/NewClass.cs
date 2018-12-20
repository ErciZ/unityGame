/// <summary>
/// 参考来源：https://github.com/EllanJiang/StarForce
/// </summary>
public static class AssetUtility {
    public static string GetConfigAsset (string assetName) {
        return string.Format ("Assets/Game/Configs/{0}.csv", assetName);
    }

    public static string GetDataTableAsset (string assetName) {
        return string.Format ("Assets/Game/DataTables/{0}.csv", assetName);
    }

    public static string GetDictionaryAsset (string assetName) {
        return string.Format ("Assets/Game/Localization/{0}/Dictionaries/{1}.xml", GameEntry.Localization.Language.ToString (), assetName);
    }

    public static string GetFontAsset (string assetName) {
        return string.Format ("Assets/Game/Localization/{0}/Fonts/{1}.ttf", GameEntry.Localization.Language.ToString (), assetName);
    }

    public static string GetSceneAsset (string assetName) {
        return string.Format ("Assets/Game/Scenes/{0}.unity", assetName);
    }

    public static string GetMusicAsset (string assetName) {
        return string.Format ("Assets/Game/Musics/{0}", assetName);
    }

    public static string GetSoundAsset (string assetName) {
        return string.Format ("Assets/Game/Sounds/{0}", assetName);
    }

    public static string GetEntityAsset (string assetName) {
        return string.Format ("Assets/Game/Prefabs/Entities/{0}.prefab", assetName);
    }

    public static string GetBulletEffectAsset (string assetName) {
        return string.Format ("Assets/Game/Prefabs/BulletEffect/{0}.prefab", assetName);
    }

    public static string GetUIFormAsset (string assetName) {
        return string.Format ("Assets/Game/Prefabs/UI/{0}.prefab", assetName);
    }

    public static string GetUISpriteAsset (string assetName) {
        return string.Format ("Assets/Game/Prefabs/UI/UISprites/{0}.prefab", assetName);
    }

    public static string GetUISoundAsset (string assetName) {
        return string.Format ("Assets/Game/UI/UISounds/{0}.wav", assetName);
    }
}