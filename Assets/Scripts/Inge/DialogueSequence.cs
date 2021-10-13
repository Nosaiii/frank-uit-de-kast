using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class DialogueSequence : MonoBehaviour {
    [SerializeField]
    private DialogueSpeaker rightSpeaker;
    private DialogueSpeaker[] speakers;
    
    [Serializable]
    public struct DialogueMessage {
        public int speakerIndex;
        public DialogueEmotion emotion;
        public string message;
    }
    [SerializeField]
    private DialogueMessage[] dialogueMessages;

    private int currentDialogueMessageIndex;
    public int CurrentDialogueMessageIndex {
        get {
            return currentDialogueMessageIndex;
        }
        set {
            currentDialogueMessageIndex = value;
            if (currentDialogueMessageIndex == dialogueMessages.Length) {
                EndDialogue();
                return;
            }

            UpdateDialogue();
        }
    }

    [Header("UI references")]
    [SerializeField]
    private DialoguePanel dialoguePanel;
    [SerializeField]
    private TeleType teleType;

    private void Awake() {
        speakers = new DialogueSpeaker[] {
            rightSpeaker
        };
    }

    private void Start() {
        EndDialogue();
        StartDialogue();
    }

    public void Skip(InputAction.CallbackContext context) {
        if (context.action.phase != InputActionPhase.Started) {
            return;
        }

        if(!dialoguePanel.PanelImage.enabled) {
            return;
        }

        CurrentDialogueMessageIndex++;
    }

    public void StartDialogue() {
        
        dialoguePanel.PanelImage.enabled = true;
        CurrentDialogueMessageIndex = 0;
        teleType.enabled = true;
    }

    private void UpdateDialogue() {
        DialogueMessage currentDialogueMessage = dialogueMessages[currentDialogueMessageIndex];

        for (int i = 0; i < speakers.Length; i++) {
            dialoguePanel.SpeakerImages[i].enabled = i == currentDialogueMessage.speakerIndex;
        }

        dialoguePanel.SpeakerImages[currentDialogueMessage.speakerIndex].texture = speakers[currentDialogueMessage.speakerIndex].Emotions[currentDialogueMessage.emotion];
        dialoguePanel.DialogueText.text = currentDialogueMessage.message;
        teleType.enabled = false;
        teleType.enabled = true;
    }

    public void EndDialogue() {
        currentDialogueMessageIndex = 0;

        teleType.enabled = false;
        dialoguePanel.PanelImage.enabled = false;

        for (int i = 0; i < speakers.Length; i++) {
            dialoguePanel.SpeakerImages[i].enabled = false;
        }

        dialoguePanel.DialogueText.text = string.Empty;
    }
}