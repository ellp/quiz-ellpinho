using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizCriadorObj : MonoBehaviour
{
    public QuizCriadorControlador qCC;
    public TextMeshProUGUI a;
    public TMP_InputField[] inputFields;
    public int startID = 0;
    private int errIndex = 0;
    void Start()
    {
        qCC = FindObjectOfType<QuizCriadorControlador>();
        inputFields[0].text = qCC.perguntas[startID];
        inputFields[1].text = qCC.respostas[startID];
        inputFields[2].text = qCC.erradas[startID*3];
        inputFields[3].text = qCC.erradas[startID*3+1];
        inputFields[4].text = qCC.erradas[startID*3+2];
    }
    public void PreencPerg(string s)
    {
        qCC.PreencherPerg(s);
    }
    public void PreencResp(string s)
    {
        qCC.PreencherResp(s);
    }
    public void EscErr(int i)
    {
        errIndex = i;
    }
    public void PreencErr(string s)
    {
        qCC.PreencherErr(errIndex, s);
    }
    public void DeletQuest()
    {
        qCC.DeleteQuest();
    }
}
