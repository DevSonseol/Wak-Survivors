using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TwitchIRC))]
public class TwitchChatExample : MonoBehaviour
{
    public int maxMessages = 100; //we start deleting UI elements when the count is larger than this var.
    private LinkedList<GameObject> messages =
        new LinkedList<GameObject>();
    public UnityEngine.UI.InputField inputField;
    public UnityEngine.UI.Button submitButton;
    public UnityEngine.RectTransform chatBox;
    public UnityEngine.UI.ScrollRect scrollRect;
    private TwitchIRC IRC;
    //when message is recieved from IRC-server or our own message.
    void OnChatMsgRecieved(string msg)
    {
        //parse from buffer.
        int msgIndex = msg.IndexOf("PRIVMSG #");
        string msgString = msg.Substring(msgIndex + IRC.channelName.Length + 11);
        string user = msg.Substring(1, msg.IndexOf('!') - 1);

        //remove old messages for performance reasons.
        if (messages.Count > maxMessages)
        {
            Destroy(messages.First.Value);
            messages.RemoveFirst();
        }

        //add new message.
        CreateUIMessage(user, msgString);
        if(msgString == "¿À")
        {
            GameObject go = new GameObject("¿À");
        }
    }
    void CreateUIMessage(string userName, string msgString)
    {
        Color32 c = ColorFromUsername(userName);
        string nameColor = "#" + c.r.ToString("X2") + c.g.ToString("X2") + c.b.ToString("X2");
        GameObject go = new GameObject("twitchMsg");
        var text = go.AddComponent<UnityEngine.UI.Text>();
        var layout = go.AddComponent<UnityEngine.UI.LayoutElement>();
        //var rigidbody = go.AddComponent<Rigidbody2D>();

        //rigidbody.gravityScale = 20;
        go.transform.SetParent(chatBox);
        go.transform.position = chatBox.transform.position + new Vector3(200,-200,0);
        Destroy(go, 4f);
       
        messages.AddLast(go);

        layout.minHeight = 20f;
        text.alignment = TextAnchor.UpperRight;
        //text.rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        text.text = "<color=" + nameColor + "><b>" + userName + "</b></color>" + ": " + msgString;
        text.color = Color.black;
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        //scrollRect.velocity = new Vector2(0, 1000f);
    }
    //when Submit button is clicked or ENTER is pressed.
    public void OnSubmit()
    {
        if (inputField.text.Length > 0)
        {
            IRC.SendMsg(inputField.text); //send message.
            CreateUIMessage(IRC.nickName, inputField.text); //create ui element.
            inputField.text = "";
        }
    }
    Color ColorFromUsername(string username)
    {
        Random.seed = username.Length + (int)username[0] + (int)username[username.Length - 1];
        return new Color(Random.Range(0.25f, 0.55f), Random.Range(0.20f, 0.55f), Random.Range(0.25f, 0.55f));
    }
    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;

        IRC = this.GetComponent<TwitchIRC>();
        //IRC.SendCommand("CAP REQ :twitch.tv/tags"); //register for additional data such as emote-ids, name color etc.
        IRC.messageRecievedEvent.AddListener(OnChatMsgRecieved);
    }


}
