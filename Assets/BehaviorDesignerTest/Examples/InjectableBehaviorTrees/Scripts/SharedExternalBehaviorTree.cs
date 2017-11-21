using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

namespace Adnc.ThirdParty.BehaviorDesignerHelpers {
    public class SharedExternalBehaviorTree : SharedVariable<ExternalBehaviorTree> {
        public static implicit operator SharedExternalBehaviorTree (ExternalBehaviorTree value) {
            return new SharedExternalBehaviorTree { Value = value };
        }
    }
}