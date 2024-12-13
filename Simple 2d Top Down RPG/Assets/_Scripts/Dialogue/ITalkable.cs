using _Scripts.NPCs;

namespace _Scripts.Dialogue
{
    public interface ITalkable
    {
        void Talk(DialogueScriptableObject dialogue);
    }
}