using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Adnc.ThirdParty.BehaviorDesignerHelpers {
    [TaskDescription("Behavior Reference allows you to run another behavior tree within the current behavior tree.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=53")]
    [TaskIcon("BehaviorTreeReferenceIcon.png")]
    public class BehaviorTreeReferenceExt : BehaviorReference {
        [Tooltip("Include external behavior trees as variables")]
        public SharedExternalBehaviorTree[] externalBehaviorVars;

        // Added to prevent null BT nodes from crashing in-case they're optional (currently crashes entire tree on null)
        [Tooltip("If a behavior tree reference is null, trigger an error?")]
        public bool errorOnNull = true;

        public override ExternalBehavior[] GetExternalBehaviors () {
            if (externalBehaviorVars == null) {
                return base.GetExternalBehaviors();
            }

            // @TODO LINQ logic could be optimized
            var externalBts = externalBehaviorVars.Select(btVar => (ExternalBehavior)btVar.Value)
                .Union(externalBehaviors)
                .ToArray();

            if (!errorOnNull) {
                externalBts = externalBts.Where(bt => bt != null).ToArray();
            }

            // Edge case since external BT references silently fail if returning empty
            // Causes odd behavior with parallel selectors
            if (externalBts.Length == 0) {
                return new ExternalBehavior[] { BehaviorDesignerSettings.Current.emptyTree };
            }

            return externalBts;
        }

        public override void OnReset () {
            externalBehaviorVars = null;
            base.OnReset();
        }
    }
}


