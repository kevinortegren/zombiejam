using UnityEngine;
using System.Collections;

public class QuestionZone : MonoBehaviour {

    private int numberOfAnswers = 0;
    private int[] collectedAnswers;

    private int nrPlayers;

    Question question;

    public bool used = false;
    public bool inited = false;

    TextMesh questionTM;
    TextMesh answer1TM;
    TextMesh answer2TM;
    TextMesh introTM;
    TextMesh waitingTM;

    // Use this for initialization
    void Start() {

        QuestionBank.Initialize();

        nrPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

        TextMesh[] textMesh = gameObject.GetComponentsInChildren<TextMesh>();
        foreach (TextMesh txm in textMesh)
        {
            if (txm.name == "Answer1")
                answer1TM = txm;
            else if (txm.name == "Answer2")
                answer2TM = txm;
            else if (txm.name == "Question")
                questionTM = txm;
            else if (txm.name == "Intro")
                introTM = txm;
            else if (txm.name == "Waiting")
                waitingTM = txm;
        }

        ShowQuestion(false);

        waitingTM.renderer.enabled = false;
	}

    void ShowQuestion(bool show)
    {
        questionTM.renderer.enabled = show;
        answer1TM.renderer.enabled = show;
        answer2TM.renderer.enabled = show;
    }

    void GenerateQuestion()
    {
        question = QuestionBank.GetQuestion();
        collectedAnswers = new int[nrPlayers];

        waitingTM.renderer.enabled = false;
        introTM.renderer.enabled = false;

        answer1TM.text = question.answer1;
        answer2TM.text = question.answer2;
        questionTM.text = question.question;

        ShowQuestion(true);
    }

	// Update is called once per frame
	void Update () {

        if (inited)
        {
            waitingTM.renderer.enabled = true;

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            int i = 0;
            foreach (GameObject playah in players)
            {
                if (playah.GetComponent<Player>().qstate == Player.QUESTIONSTATE.WAITING)
                {
                    i++;
                }
            }

            if (i == nrPlayers)
            {
                GenerateQuestion();

                foreach (GameObject playah in players)
                {
                    playah.GetComponent<Player>().qstate = Player.QUESTIONSTATE.INTRO;
                }

                inited = false;
            }
        }

	}

    public void SubmitAnswer(int answer, int player)
    {
       
        collectedAnswers[player] = answer;
        numberOfAnswers++;

        if (numberOfAnswers == nrPlayers)
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
            if (collectedAnswers[playah.GetComponent<Player>().JoyStickNum - 1] == question.correctAnswer)
            {
                //playah.GetComponent<Player>().AwardScore(200);
                //set player state to moving

                print("Correct answer!");
            }

            playah.GetComponent<Player>().Unlock();
        }

        used = true;
    }
}
