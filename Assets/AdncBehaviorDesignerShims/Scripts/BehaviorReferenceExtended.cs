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

        [Tooltip("If a behavior tree reference is null, trigger an error?")]
        public bool errorOnNull = true;

        public override ExternalBehavior[] GetExternalBehaviors () {
            if (externalBehaviorVars == null) {
                return base.GetExternalBehaviors();
            }

            var externalBts = externalBehaviorVars.Select(btVar => (ExternalBehavior)btVar.Value)
                .Union(externalBehaviors)
                .ToArray();

            if (!errorOnNull) {
                externalBts = externalBts.Where(bt => bt != null).ToArray();
            }

            return externalBts;
        }

        public override void OnReset () {
            externalBehaviorVars = null;
            base.OnReset();
        }
    }
}


