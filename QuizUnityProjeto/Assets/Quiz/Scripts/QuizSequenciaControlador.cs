using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizSequenciaControlador : MonoBehaviour
{
    public string[] perguntas, respostas, erradas;
    private GameObject[] questoes;
    public GameObject[] questPrefab;
    private int questAt = 0;
    
    private void Awake()
    {
        questoes = new GameObject[perguntas.Length];
        CriarQuestoes();
        for (int i = 0; i < questoes.Length; i++)
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
        for (int i = 0; i < questoes.Length; i++)
        {
            questoes[i] = Instantiate(questPrefab[0], transform.parent);
            questoes[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1900,0);
        }
    }
    public void TrocarQuestao()
    {

        if (questAt == questoes.Length)
        {
            SceneManager.LoadScene("Quiz");
            return;
        }
        if (questAt>0)
            questoes[questAt-1].GetComponent<RectTransform>().anchoredPosition = new Vector2(1900, 0);
        questoes[questAt].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        questAt++;
    }
}
