using DialoguePlus.Utility.Maps;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New dialogue speaker", menuName = "DialoguePlus/DialogueSpeaker")]
public class DialogueSpeaker : ScriptableObject {
    [SerializeField]
    private string speakerName;
    [SerializeField]
    private Map<DialogueEmotion, Texture2D> emotions;

    public string SpeakerName => speakerName;
    public Map<DialogueEmotion, Texture2D> Emotions => emotions;
}

public enum DialogueEmotion {
    HAPPY,
    SAD
}