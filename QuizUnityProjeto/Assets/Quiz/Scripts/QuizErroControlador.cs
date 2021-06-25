using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizErroControlador : MonoBehaviour
{
    private Image[] erros;
    public GameObject erroPrefab;
    public int qtdErros = 3;
    private int qtdErrados = 0;
    private void Start()
    {
        erros = new Image[qtdErros];
        CriarErros();
    }
    private void CriarErros()
    {
        for (int i = 0; i < qtdErros; i++)
        {
            GameObject temp = Instantiate(erroPrefab, transform);
            temp.GetComponent<RectTransform>().anchoredPosition = new Vector2(i*125f,0);
            erros[i] = temp.GetComponentsInChildren<Image>()[1];
            erros[i].enabled = false;
        }
    }
    public void Errou()
    {
        erros[qtdErrados].enabled = true;
        qtdErrados++;
        if(qtdErrados == qtdErros)
        {
            SceneManager.LoadScene("Quiz");
        }
    }
}
