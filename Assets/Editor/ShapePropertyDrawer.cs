using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    [CustomPropertyDrawer(typeof(Shape))]
    public class ShapePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty shapeProperty, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, shapeProperty);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects

            var size = 25;
            for (var row = 0; row < 4; row++)
            {
                var row1 = shapeProperty.FindPropertyRelative($"row{(row + 1)}");
                for (var col = 0; col < 4; col++)
                {
                    var amountRect = new Rect(position.x + col * size, position.y + row * size, size, size);
                    var row1col1 = row1.GetArrayElementAtIndex(col);

                    EditorGUI.PropertyField(amountRect, row1col1, GUIContent.none);
                }
            }

            /*
            var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
            var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(amountRect, shapeProperty.FindPropertyRelative("amount"), GUIContent.none);
            EditorGUI.PropertyField(unitRect, shapeProperty.FindPropertyRelative("unit"), GUIContent.none);
            EditorGUI.PropertyField(nameRect, shapeProperty.FindPropertyRelative("name"), GUIContent.none);
            */

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 100;
        }
    }

    
}