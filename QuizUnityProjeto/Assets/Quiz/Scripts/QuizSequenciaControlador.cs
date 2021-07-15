using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;
using TMPro;

public class QuizSequenciaControlador : MonoBehaviour
{
    public string arqLido = "Quiz1.txt";
    private List<string> perguntas = new List<string>(), respostas = new List<string>(), erradas = new List<string>();
    private List<GameObject> questoes = new List<GameObject>();
    public GameObject[] questPrefab;
    private int questAt = 0;
    
    private void Awake()
    {
        arqLido = QuizVerArqs.Instance.quizDest;
        LerArquivoQuiz(Application.dataPath + "/StreamingAssets/QuizesArq/" + arqLido);
        CriarQuestoes();
        for (int i = 0; i < perguntas.Count; i++)
        {
            QuizQuestaoControler questao = questoes[i].GetComponent<QuizQuestaoControler>();
            questao.pergunta = perguntas[i];
            questao.resposta = respostas[i];
            for (int j = 0; j < 3; j++)
            {
                questao.erradas[j] = erradas[i*3 + j];
            }
        }
        TrocarQuestao();
    }
    private void CriarQuestoes()
    {
        for (int i = 0; i < perguntas.Count; i++)
        {
            questoes.Add(Instantiate(questPrefab[0], transform.parent));
            questoes[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1900,0);
        }
    }
    public void TrocarQuestao()
    {

        if (questAt == questoes.Count)
        {
            SceneManager.LoadScene("Quiz");
            return;
        }
        if (questAt>0)
            questoes[questAt-1].GetComponent<RectTransform>().anchoredPosition = new Vector2(1900, 0);
        questoes[questAt].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        questAt++;
    }
    private void LerArquivoQuiz(string caminho)
    {
        List<String> linhas = new List<string>();
        try
        {
            linhas.AddRange(File.ReadAllLines(caminho,Encoding.UTF8));
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return;
        }
        if (linhas.Count < 5)
            return;
        int var = (int)(linhas.Count / 5);
        for (int i = 0; i < var; i++)
        {
            perguntas.Add(linhas[i*5]);
            respostas.Add(linhas[i*5+1]);
            erradas.Add(linhas[i*5+2]);
            erradas.Add(linhas[i*5+3]);
            erradas.Add(linhas[i*5+4]);
        }
    }
}
