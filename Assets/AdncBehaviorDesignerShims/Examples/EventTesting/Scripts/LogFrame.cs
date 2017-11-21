using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks {
    [TaskDescription("Log the frame with a text message")]
    [TaskIcon("{SkinColor}LogIcon.png")]
    public class LogFrame : Action {
        [Tooltip("Text to output to the log")]
        public SharedString text;

        public override TaskStatus OnUpdate () {
            // Log the text and return success
            Debug.LogFormat("{0}: {1}", text.Value, Time.frameCount);
            return TaskStatus.Success;
        }

        public override void OnReset () {
            // Reset the properties back to their original values
            text = "";
        }
    }
}