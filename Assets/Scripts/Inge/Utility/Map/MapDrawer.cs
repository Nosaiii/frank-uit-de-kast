using System;
using System.Reflection;

using UnityEngine;

using UnityEditor;
using UnityEditorInternal;

namespace DialoguePlus.Utility.Maps {
    [CustomPropertyDrawer(typeof(Map), true)]
    public class MapDrawer : PropertyDrawer {
        private ReorderableList list;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (list == null) {
                SerializedProperty listProp = property.FindPropertyRelative("list");
                list = new ReorderableList(property.serializedObject, listProp, true, false, true, true);
                list.drawElementCallback = DrawListItems;
            }

            Rect firstLine = position;
            firstLine.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(firstLine, property, label);

            if (property.isExpanded) {
                position.y += firstLine.height;

                if (elementIndex == null)
                    elementIndex = new GUIContent();

                list.DoList(position);
            }
        }

        private static GUIContent[] pairElementLabels => s_pairElementLabels ??= new[] { new GUIContent("Key"), new GUIContent("=>") };
        private static GUIContent[] s_pairElementLabels;

        private static GUIContent elementIndex;

        void DrawListItems(Rect rect, int index, bool isActive, bool isFocused) {
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index); // The element in the list

            SerializedProperty keyProp = element.FindPropertyRelative("Key");
            SerializedProperty valueProp = element.FindPropertyRelative("Value");

            elementIndex.text = $"Element {index}";
            EditorGUI.BeginProperty(rect, elementIndex, element);

            float prevLabelWidth = EditorGUIUtility.labelWidth;

            EditorGUIUtility.labelWidth = 75;

            Rect rect0 = rect;

            float halfWidth = rect0.width / 2f;
            rect0.width = halfWidth;
            rect0.y += 1f;
            rect0.height -= 2f;


            EditorGUIUtility.labelWidth = 40;

            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(rect0, keyProp);

            rect0.x += halfWidth + 4f;

            EditorGUI.PropertyField(rect0, valueProp);

            EditorGUIUtility.labelWidth = prevLabelWidth;

            EditorGUI.EndProperty();
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            if (property.isExpanded) {
                SerializedProperty listProp = property.FindPropertyRelative("list");
                if (listProp.arraySize < 2)
                    return EditorGUIUtility.singleLineHeight + 52f;
                else
                    return EditorGUIUtility.singleLineHeight + 23f * listProp.arraySize + 29;
            } else
                return EditorGUIUtility.singleLineHeight;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ReadOnlyKeyAttribute : PropertyAttribute {

    }
}