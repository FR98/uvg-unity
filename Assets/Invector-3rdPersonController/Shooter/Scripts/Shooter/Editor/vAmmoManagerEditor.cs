using UnityEngine;
using System.Collections;
using UnityEditor;
using Invector;

[CanEditMultipleObjects]
[CustomEditor(typeof(vAmmoManager), true)]
public class vAmmoManagerEditor : Editor
{
    GUISkin skin;
    bool openWindow;
    private Texture2D m_Logo = null;

    void OnEnable()
    {
        m_Logo = (Texture2D)Resources.Load("ammoIcon", typeof(Texture2D));
    }

    public override void OnInspectorGUI()
    {        
        var manager = target as vAmmoManager;
        if (!skin) skin = Resources.Load("skin") as GUISkin;
        GUI.skin = skin;        
        GUILayout.BeginVertical("AMMO MANAGER", "window");
        GUILayout.Label(m_Logo, GUILayout.MaxHeight(25));        

        openWindow = GUILayout.Toggle(openWindow, openWindow ? "Close" : "Open", EditorStyles.toolbarButton);
        if (openWindow)
        {
            EditorGUILayout.HelpBox("You can add and manage ammo here if you're NOT using the Inventory. Otherwise the weapon will search for ammo inside the Inventory.", MessageType.Info);

            base.OnInspectorGUI();

            if (manager.ammoListData)
            {
                var ammoList = new SerializedObject(manager.ammoListData);
               
                DrawPropertiesExcluding(ammoList, "m_Script");
                if (GUI.changed)
                    ammoList.ApplyModifiedProperties();
            }
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
}
