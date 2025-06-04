using UnityEditor;
using UnityEngine;

public class PlayerPrefsReset
{
    [MenuItem("Tools/Reset PlayerPrefs")]
    public static void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log(" PlayerPrefs ont été réinitialisés");
    }
}
