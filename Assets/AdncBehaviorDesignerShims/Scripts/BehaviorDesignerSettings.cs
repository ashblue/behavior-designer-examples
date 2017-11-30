using BehaviorDesigner.Runtime;
using UnityEngine;

namespace Adnc.ThirdParty.BehaviorDesignerHelpers {
    [CreateAssetMenu(fileName = "BehaviorDesignerSettings", menuName = "ADNC/Behavior Designer/Settings")]
    public class BehaviorDesignerSettings : ScriptableObject {
        private const string RESOURCE_PATH = "BehaviorDesignerSettings";

        private static BehaviorDesignerSettings _current;
        public static BehaviorDesignerSettings Current {
            get {
                if (_current == null) {
                    _current = Resources.Load<BehaviorDesignerSettings>(RESOURCE_PATH);
                    Debug.AssertFormat(_current != null, "Could not load BehaviorDesignerSettings. Please verify a BehaviorDesignerSettings object " +
                                                         "is available at `Resources/{0}'. If not please create one.", RESOURCE_PATH);
                }

                return _current;
            }
        }

        [Tooltip("Injected empty tree if an external reference is empty (otherwise it will crash). Should" +
                 " have one always valid BT node such as a bool comparison")]
        public ExternalBehaviorTree emptyTree;
    }
}
