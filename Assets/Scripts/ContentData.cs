using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ContentData", fileName = "ContentData")]
public class ContentData : ScriptableObject
{
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] [field: TextArea(20, 25)] public string Text { get; private set; }
}