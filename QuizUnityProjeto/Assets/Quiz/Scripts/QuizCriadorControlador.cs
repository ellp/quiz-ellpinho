using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;
using System.IO;
using UnityEngine.SceneManagement;
public class QuizCriadorControlador : MonoBehaviour
{
    public List<string> perguntas = new List<string>(), respostas = new List<string>(), erradas = new List<string>();
    private List<GameObject> questoes = new List<GameObject>();
    public GameObject preFab;
    public int questAtual = 0;
    public TextMeshProUGUI numQuest;
    public string arqLido = "Quiz1";
    public bool carregarArq = false;
    public TMP_InputField nomeSaida;
    private void Start()
    {
        if(carregarArq)
            LerArquivoQuiz(Application.dataPath + "/StreamingAssets/QuizesArq/" + arqLido + ".txt");
    }
    public void ProxQuest()
    {
        Debug.Log(questAtual + " " + questoes.Count);
        if (questAtual == questoes.Count)
            CriarQuest(questAtual);
        TrocarQuest(0);
        questAtual++;
        numQuest.text = "Questão: " + questAtual.ToString() + "/" + questoes.Count.ToString();
    }
    public void AntQuest()
    {
        if (questAtual - 2 < 0)
            return;
        TrocarQuest(-2);
        questAtual--;
        numQuest.text = "Questão: " + questAtual.ToString() + "/" + questoes.Count.ToString();
    }
    private void CriarQuest(int i)
    {
        questoes.Add(Instantiate(preFab, transform));
        questoes[questoes.Count-1].GetComponent<RectTransform>().anchoredPosition = new Vector2(2000, 0);
        questoes[i].GetComponent<QuizCriadorObj>().startID = i;
        perguntas.Add(" ");
        respostas.Add(" ");
        erradas.Add(" ");
        erradas.Add(" ");
        erradas.Add(" ");
    }
    public void DeleteQuest()
    {
        if (questoes.Count == 1)
            return;
        if(questAtual == 1)
        {
            erradas.RemoveRange((questAtual-1) * 3, 3);
            respostas.RemoveAt(questAtual-1);
            perguntas.RemoveAt(questAtual-1);
            Destroy(questoes[questAtual-1].gameObject);
            questoes.RemoveAt(questAtual-1);
            questAtual--;
            ProxQuest();
        }
        else
        {
            AntQuest();
            erradas.RemoveRange((questAtual) * 3, 3);
            respostas.RemoveAt(questAtual);
            perguntas.RemoveAt(questAtual);
            Destroy(questoes[questAtual].gameObject);
            questoes.RemoveAt(questAtual);
            numQuest.text = "Questão: " + questAtual.ToString() + "/" + questoes.Count.ToString();
        }
    }
    public void PreencherPerg(string s)
    {
        perguntas[questAtual-1] = s;
    }
    public void PreencherResp(string s)
    {
        respostas[questAtual-1] = s;
    }
    public void PreencherErr(int i, string s)
    {
        erradas[(questAtual - 1)*3 + i] = s;
    }
    
    private void TrocarQuest(int i)
    {
        if (questoes.Count > 1 && questAtual > 1)
            questoes[questAtual - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(2000, 0);
        questoes[questAtual+i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
    private void LerArquivoQuiz(string caminho)
    {
        List<String> linhas = new List<string>();
        try
        {
            linhas.AddRange(File.ReadAllLines(caminho, Encoding.UTF8));
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
            
            CriarQuest(i);
            perguntas[i] = linhas[i * 5];
            respostas[i] = linhas[i * 5 + 1];
            erradas[i*3] = linhas[i * 5 + 2];
            erradas[i*3 + 1] = linhas[i * 5 + 3];
            erradas[i*3 + 2] = linhas[i * 5 + 4];
        }
        ProxQuest();
    }
    public void CriarArquvoQuiz(string nome)
    {
        if(nomeSaida.text != "")
            nome = nomeSaida.text;
        List<String> linhas = new List<string>();
        for (int i = 0; i < questoes.Count; i++)
        {
            linhas.Add(perguntas[i]);
            linhas.Add(respostas[i]);
            linhas.Add(erradas[i*3]);
            linhas.Add(erradas[i*3 + 1]);
            linhas.Add(erradas[i*3 + 2]);
        }
        File.WriteAllLines(Application.dataPath + "/StreamingAssets/QuizesArq/" + nome + ".txt", linhas);
        CarregarMenu();
    }
    public void CarregarMenu()
    {
        SceneManager.LoadScene("Quiz");
    }
}
