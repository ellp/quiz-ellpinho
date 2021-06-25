using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizQuestaoControler : MonoBehaviour
{
    public string pergunta, resposta;
    public string[] erradas = new string[3];
    public TextMeshProUGUI[] strings = new TextMeshProUGUI[5];
    private QuizErroControlador qEC;
    private QuizSequenciaControlador qSC;
    private int opcCert = 0;
    private void Awake()
    {
        opcCert = Random.Range(1, 5);
    }
    private void Start()
    {
        qEC = FindObjectOfType<QuizErroControlador>();
        qSC = FindObjectOfType<QuizSequenciaControlador>();
        strings[0].text = pergunta;
        AttText();
    }
    void AttText()
    {
        int b = 0;
        for (int i = 1; i < 5; i++)
        {
            if (i == opcCert)
                strings[i].text = resposta;
            else
            {
                strings[i].text = erradas[b];
                b++;
            }
        }
    }
    public void EscolherOpc(int i)
    {
        if (i == opcCert)
        {
            qSC.TrocarQuestao();
        }
        else
            qEC.Errou();
    }
}
