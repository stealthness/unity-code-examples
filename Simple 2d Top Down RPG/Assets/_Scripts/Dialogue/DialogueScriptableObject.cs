using UnityEngine;

namespace _Scripts.Dialogue
{
    /// <summary>
    /// Dialogue Scriptable Object, contains the dialogue for an NPC
    /// </summary>
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
    public class DialogueSo : ScriptableObject
    {
        /// <summary>
        /// The name of the NPC speaker
        /// </summary>
        public string speakerName;
        [TextArea(3, 10)]
        public string[] dialogue;
        [SerializeField] private int currentIndex = 0;
        
        
        public  string GetFirstLine()
        {
            currentIndex = 0;
            return dialogue[currentIndex];
        }
        
        public string GetNextLine()
        {

            if (currentIndex < dialogue.Length)
            {
                var currentLine = dialogue[currentIndex];
                currentIndex++;
                return currentLine;
            }

            return null;
        }
        
        public void ResetIndex()
        {
            currentIndex = 0;
        }

    }
}