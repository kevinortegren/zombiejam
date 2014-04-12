using UnityEngine;
using System.Collections;

public class QuestionZone : MonoBehaviour {

    private int numberOfAnswers = 0;
    private int[] collectedAnswers;
    private int correctAnswer;
    private string question;
    private string[] answers;

    // Use this for initialization
    void Start() {
        collectedAnswers = new int[Global.numberOfPlayers];
        correctAnswer = 0;
        question = "Testion";

        answers = new string[2];
        answers[0] = "Right";
        answers[1] = "Wrong";

        TextMesh[] textMesh = gameObject.GetComponentsInChildren<TextMesh>();

        foreach(TextMesh txm in textMesh)
        {
            if (txm.name == "Answer1")
                txm.text = answers[0];
            else if (txm.name == "Answer2")
                txm.text = answers[1];
            else if (txm.name == "Question")
                txm.text = question;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SubmitAnswer(int answer, int player)
    {
        collectedAnswers[player] = answer;
        numberOfAnswers++;

        if (numberOfAnswers == Global.numberOfPlayers - 1)
        {
            AnswersDone();
        }
    }

    private void AnswersDone()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject playah in players)
        {
            // Award scores and set state
            if (collectedAnswers[playah.GetComponent<Player>().JoyStickNum - 1] == correctAnswer)
            {
                //playah.GetComponent<Player>().AwardScore(200);
                //set player state to moving
            }
        }
    }
}
