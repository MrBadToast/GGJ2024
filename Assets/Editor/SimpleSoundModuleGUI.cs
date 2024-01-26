using UnityEditor;
using System.Collections;
using UnityEngine;

[CustomEditor(typeof(SimpleSoundModule))]
public class SimpleSoundModuleGUI : Editor
{
    private static GUIContent
        addItemsButtonContent = new GUIContent("Add"),
        removeItemsButtonContent = new GUIContent("Remove");


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        SimpleSoundModule soundModule = (SimpleSoundModule)target;
        SerializedProperty property = serializedObject.FindProperty("soundItems");

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Add New Sound");
        if (GUILayout.Button(addItemsButtonContent, EditorStyles.miniButtonRight))
        {
            property.InsertArrayElementAtIndex(0);
            var newSound = property.GetArrayElementAtIndex(0);
            newSound.FindPropertyRelative("pitchMin").floatValue = 1.0f;
            newSound.FindPropertyRelative("pitchMax").floatValue = 1.0f;
            newSound.FindPropertyRelative("volumeMin").floatValue = 1.0f;
            newSound.FindPropertyRelative("volumeMax").floatValue = 1.0f;
            serializedObject.ApplyModifiedProperties();
            return;
        }
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10f);

        if (property.arraySize != 0)
        {
            for (int i = 0; i < soundModule.SoundItems.Length; i++)
            {
                var item = property.GetArrayElementAtIndex(i);

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                GUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(item.FindPropertyRelative("name"));
                if (GUILayout.Button(removeItemsButtonContent, EditorStyles.miniButtonRight))
                {
                    property.DeleteArrayElementAtIndex(i);
                    continue;
                }
                GUILayout.EndHorizontal();

                EditorGUI.indentLevel += 1;
                EditorGUILayout.PropertyField(item.FindPropertyRelative("audioClips"), true);
                if (item.FindPropertyRelative("audioClips").arraySize == 0 && i == 0)
                {
                    EditorGUI.indentLevel += 1;
                    EditorGUILayout.HelpBox("If listed audios are more than two, Random audio will be played!", MessageType.Info);
                    EditorGUI.indentLevel -= 1;
                }
                EditorGUILayout.PropertyField(item.FindPropertyRelative("randomPitch"));
                if (soundModule.SoundItems[i].randomPitch)
                {
                    EditorGUI.indentLevel += 1;
                    EditorGUILayout.PropertyField(item.FindPropertyRelative("pitchMin"));
                    EditorGUILayout.PropertyField(item.FindPropertyRelative("pitchMax"));
                    EditorGUI.indentLevel -= 1;
                }
                EditorGUILayout.PropertyField(item.FindPropertyRelative("randomVolume"));
                if (soundModule.SoundItems[i].randomVolume)
                {
                    EditorGUI.indentLevel += 1;
                    EditorGUILayout.PropertyField(item.FindPropertyRelative("volumeMin"));
                    EditorGUILayout.PropertyField(item.FindPropertyRelative("volumeMax"));
                    EditorGUI.indentLevel -= 1;
                }

                EditorGUI.indentLevel -= 1;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

}
