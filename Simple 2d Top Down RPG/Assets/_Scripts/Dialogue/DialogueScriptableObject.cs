using UnityEngine;

namespace _Scripts.Dialogue
{
    /// <summary>
    /// Dialogue Scriptable Object, contains the dialogue for an NPC
    /// </summary>
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
    public class DialogueScriptableObject : ScriptableObject
    {
        /// <summary>
        /// The name of the NPC speaker
        /// </summary>
        public string speakerName;
        [TextArea(3, 10)]
        public string[] dialogue;

    }
}