using System.Collections;
using System.Collections.Generic;
using Adnc.ThirdParty.BehaviorDesignerHelpers.Examples;
using UnityEditor;
using UnityEngine;

namespace Adnc.ThirdParty.BehaviorDesignerHelpers.Editors {
    [CustomEditor(typeof(EventTriggers))]
    public class EventTriggersEditor : Editor {
        private int _eventIndex;

        private EventTriggers Target {
            get { return (EventTriggers)target; }
        }

        public override void OnInspectorGUI () {
            base.OnInspectorGUI();

            if (!Application.isPlaying) {
                return;
            }

            EditorGUILayout.LabelField("Debug", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            _eventIndex = EditorGUILayout.IntField(_eventIndex);
            if (GUILayout.Button("Trigger Event")
                && _eventIndex >= 0
                && _eventIndex < Target.eventNames.Length) {
                Target.TriggerEvent(_eventIndex);
            }
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Trigger All Events")) {
                Target.TriggerAllEvents();
            }
        }
    }
}