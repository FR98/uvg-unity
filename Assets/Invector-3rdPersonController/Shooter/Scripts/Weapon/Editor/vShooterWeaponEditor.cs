using UnityEngine;
using System.Collections;
using UnityEditor;
using Invector;

[CanEditMultipleObjects]
[CustomEditor(typeof(vShooterWeapon), true)]
public class vShooterWeaponEditor : Editor
{
    GUISkin skin;
    string[] ignoreProperties = new string[] { "onShot","onReload","onEmptyClip","onEnableAim", "onDisableAim","onEnableScope","onDisableScope" };
    [SerializeField]
    public bool eventsOpen;
    private Texture2D m_Logo = null;

    void OnEnable()
    {
        m_Logo = (Texture2D)Resources.Load("icon_v2", typeof(Texture2D));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var oldskin = GUI.skin;
        if (!skin) skin = Resources.Load("skin") as GUISkin;
        GUI.skin = skin;        
	    GUILayout.BeginVertical("Shooter Weapon", "window");
        GUILayout.Label(m_Logo, GUILayout.MaxHeight(25));
        GUILayout.Space(10);

        DrawPropertiesExcluding(serializedObject, ignoreProperties);
        GUI.skin = oldskin;
        EditorGUILayout.Space();
        if (GUILayout.Button(eventsOpen ? "Close Events" : "Open Events")) eventsOpen = !eventsOpen;
        if(eventsOpen)
            for (int i = 0; i < ignoreProperties.Length; i++)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty(ignoreProperties[i]));
            }
       
      
        serializedObject.ApplyModifiedProperties();	    

        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        
    }
}