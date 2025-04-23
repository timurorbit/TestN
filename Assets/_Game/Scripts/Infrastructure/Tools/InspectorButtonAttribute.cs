using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace MageDefence
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class InspectorButtonAttribute : PropertyAttribute
    {
        public readonly string MethodName;

        public InspectorButtonAttribute(string MethodName)
        {
            this.MethodName = MethodName;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(InspectorButtonAttribute))]
    public class InspectorButtonPropertyDrawer : PropertyDrawer
    {
        private MethodInfo _eventMethodInfo = null;

        public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
        {
            InspectorButtonAttribute inspectorButtonAttribute = (InspectorButtonAttribute)attribute;

            var buttonLength = position.width;
            var buttonRect = new Rect(position.x, position.y, buttonLength, position.height);
            GUI.skin.button.alignment = TextAnchor.MiddleLeft;

            if (GUI.Button(buttonRect, inspectorButtonAttribute.MethodName))
            {
                var eventOwnerType = prop.serializedObject.targetObject.GetType();
                var eventName = inspectorButtonAttribute.MethodName;

                if (_eventMethodInfo == null)
                {
                    _eventMethodInfo = eventOwnerType.GetMethod(eventName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }

                if (_eventMethodInfo != null)
                {
                    _eventMethodInfo.Invoke(prop.serializedObject.targetObject, null);
                }
                else
                {
                    Debug.LogWarning($"InspectorButton: Unable to find method {eventName} in {eventOwnerType}");
                }
            }
        }
    }
#endif
}