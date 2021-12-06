using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ConversationList : ScriptableObject
{
    public List<ConversationEntry> Conversation;
    public string nextPanelName;   //can specify a next panel to open
}