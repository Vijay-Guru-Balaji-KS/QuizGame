using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionnAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionText;


    private int totalQuestions;
    private int count = 1;

    public GameOverScript gameOverScript;

    // Start is called before the first frame update

    private void Awake()
    {
        gameOverScript = GetComponent<GameOverScript>();
    }
    void Start()
    {
        totalQuestions = QnA.Count;
        count++;
        if(count<totalQuestions)
        {
            generateQuestion();
        }
    }

    private void Update()
    {
        if(QnA.Count == 0)
        {
            gameOverScript.GameOverPanel.SetActive(true);
            this.enabled = false;
        }
    }

    public void correct()
    {
        if (QnA.Count > 0)
        {
            QnA.RemoveAt(currentQuestion);
            
                generateQuestion();
        }
        
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].answers[i];

            if (QnA[currentQuestion].correctAnswer==i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
       if(QnA.Count>0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Question;
            setAnswers();
        }
    }
}
