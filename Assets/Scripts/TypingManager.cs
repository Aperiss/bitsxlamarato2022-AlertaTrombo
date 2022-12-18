using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TypingManager : MonoBehaviour
{
    public Message message;
    public CalfParameters calfParams;
    public TextMeshProUGUI textOutput;
    public string input = new string("");
    public string correctWords = new string("");
    public string output = new string("");
    public int currentWord = 0;

    private float lastCorrectWordTimestamp = 0;
    private float timer = 0;
    private float totalTimeElapsed = 0;
    private float wordCountAverageTimeElapsed;
    public float wpmFalloff;

    private string randomMessage;
    public List<string> messageList;

    public bool startProgress = false;

    private void OnEnable()
    {
        messageList.Clear();
        currentWord = 0;
        correctWords = "";
        input = "";
        output = "";
        timer = 0;
        totalTimeElapsed = 0;
        lastCorrectWordTimestamp = 0;
        wordCountAverageTimeElapsed = 0;
        startProgress = false;

        for (int i = 0; i < message.messages.Count; i++)
        {
            messageList.Add(message.messages[i]);
        }
        
        int index = UnityEngine.Random.Range(0, messageList.Count);
        randomMessage = messageList[index];
        messageList.RemoveAt(index);
    }

    void Update()
    {
        string[] words = randomMessage.Split(' ');
        timer += Time.deltaTime;
        //calfParams.averageWpm -= wpmFalloff * Time.deltaTime;
        calfParams.rawWpm -= wpmFalloff * Time.deltaTime;
        calfParams.wordCountAverageWpm -= wpmFalloff * Time.deltaTime;

        calfParams.averageWpm = Mathf.Clamp(calfParams.averageWpm, 0, calfParams.maxWpm);
        calfParams.rawWpm = Mathf.Clamp(calfParams.rawWpm, 0, calfParams.maxWpm);
        calfParams.wordCountAverageWpm = Mathf.Clamp(calfParams.wordCountAverageWpm, 0, calfParams.maxWpm);
        
        if (currentWord < words.Length)
        {
            foreach (char c in Input.inputString)
            {
                startProgress = true;
                if (c == '\b') // has backspace/delete been pressed?
                {
                    if (input.Length != 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                    }
                }
                else if ((c == '\n') || (c == '\r') || c == ' ' || c == '\u001B') // enter/return/space
                {
                    //Check word matches message current word
                    if (input == words[currentWord])
                    {
                        currentWord++;
                        correctWords += "<b><color=black>" + input + "<color=grey></b> ";

                        float timeElapsed = timer - lastCorrectWordTimestamp;
                        totalTimeElapsed += timeElapsed;
                        wordCountAverageTimeElapsed += timeElapsed;
                        lastCorrectWordTimestamp = timer;
                        calfParams.averageWpm = 60.0f / (totalTimeElapsed / currentWord);
                        calfParams.rawWpm = 60.0f / timeElapsed;
                        calfParams.wordCountAverageWpm = 60.0f / (wordCountAverageTimeElapsed / Mathf.Min(currentWord, calfParams.wordCountAverage));
                        
                        calfParams.averageWpm = Mathf.Clamp(calfParams.averageWpm, 0, calfParams.maxWpm);
                        calfParams.rawWpm = Mathf.Clamp(calfParams.rawWpm, 0, calfParams.maxWpm);
                        calfParams.wordCountAverageWpm = Mathf.Clamp(calfParams.wordCountAverageWpm, 0, calfParams.maxWpm);

                        if (currentWord % calfParams.wordCountAverage == 0)
                        {
                            wordCountAverageTimeElapsed = 0.0f;
                        }
                    }
                    input = "";
                }
                else
                {
                    input += c;
                }
            }
        }
        else
        {
            int index = UnityEngine.Random.Range(0, messageList.Count);
            randomMessage = messageList[index];
            messageList.RemoveAt(index);
            currentWord = 0;
            correctWords = "";
        }
        
        output = correctWords;
        for (int i = currentWord; i < words.Length; i++)
        {
            if (i == currentWord)
            {
                string wordCheckString = "";
                for (int j = 0; j < Math.Max(words[i].Length, input.Length); j++)
                {
                    if (j < words[i].Length)
                    {
                        if (input.Length > j && words[i][j] != input[j])
                        {
                            wordCheckString += "<b><color=red>";
                        }
                        else if (input.Length > j && words[i][j] == input[j])
                        {
                            wordCheckString += "<b><color=black>";
                        }
                        else
                        {
                            wordCheckString += "<color=grey>";
                        }
                        wordCheckString += words[i][j] + "</color></b>";
                    }
                    else
                    {
                        wordCheckString += "<b><color=red>" + input[j] + "</color></b>";
                    }
                }
                output += "<b><color=grey>" + wordCheckString + "</color></b> ";
            }
            else
            {
                output +=  "<b><color=grey>" + words[i] + "</color></b> ";
            }
        }
        textOutput.text = output;
    }
    
}
