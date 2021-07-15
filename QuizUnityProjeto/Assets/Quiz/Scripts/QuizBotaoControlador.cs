using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizBotaoControlador : MonoBehaviour
{
    public Sprite btnNormal, btnPress;
    public TextMeshProUGUI txtNormal, txtPress, txtDel;
    public TMP_Dropdown dpD;
    private Image img;
    private void Start()
    {
        if(dpD != null)
        {
            AtualizarDpD();
        }
        img = GetComponent<Image>();
        Invoke("AttText", 0.1f);//chamar a função com delay para prevenir bug
    }
    
    public void Click()
    {
        img.sprite = btnPress;
        txtNormal.enabled = false;
        txtPress.enabled = true;
        Invoke("Reset", 0.1f);
    }
    private void Reset()
    {
        img.sprite = btnNormal;
        txtNormal.enabled = true;
        txtPress.enabled = false;
    }
    public void CarregarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    private void AttText()
    {
        txtPress.text = txtNormal.text;
    }
    public void TrocarQuiz(int i)
    {
        QuizVerArqs.Instance.quizDest = QuizVerArqs.Instance.quizes[i];
    }
    public void DeletarQuiz()
    {
        QuizVerArqs.Instance.DeletarQuiz();
        QuizVerArqs.Instance.VerificarArquivos();
        AtualizarDpD();
    }
    private void AtualizarDpD()
    {
        QuizVerArqs.Instance.VerificarArquivos();
        dpD.ClearOptions();
        dpD.AddOptions(QuizVerArqs.Instance.quizes);
        for (int i = 0; i < QuizVerArqs.Instance.quizes.Count; i++)
        {
            if (QuizVerArqs.Instance.quizes[i] == QuizVerArqs.Instance.quizDest)
            {
                dpD.value = i;
                break;
            }
        }
    }
    public void AttTextDel()
    {
        txtDel.text = "Tem certeza que deseja deletar o arquivo <color=green>" + QuizVerArqs.Instance.quizDest + "</color> ??\nEsse processo é irreverssível!!!";
    }
}
