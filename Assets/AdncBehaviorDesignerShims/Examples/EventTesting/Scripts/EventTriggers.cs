using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

namespace Adnc.ThirdParty.BehaviorDesignerHelpers.Examples {
    public class EventTriggers : MonoBehaviour {
        [SerializeField]
        private string _logPrefix;

        [SerializeField]
        private BehaviorTree _tree;

        public string[] eventNames = new string[0];

        public void TriggerEvent (int index) {
            _tree.SendEvent(eventNames[index]);
            Debug.LogFormat("{0}: {1}", _logPrefix, Time.frameCount);
        }

        public void TriggerAllEvents () {
            for (var i = 0; i < eventNames.Length; i++) {
                TriggerEvent(i);
            }
        }
    }
}


