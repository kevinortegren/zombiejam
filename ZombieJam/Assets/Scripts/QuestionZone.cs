using UnityEngine;
using System.Collections;

public class QuestionZone : MonoBehaviour {

    private int numberOfAnswers = 0;
    private int[] collectedAnswers;

    private int nrPlayers;

    Question question;

    public bool used = false;
    public bool inited = false;
    public bool intro = false;
    public bool outro = false;

    TextMesh questionTM;
    TextMesh answer1TM;
    TextMesh answer2TM;
    TextMesh introTM;
    TextMesh waitingTM;
    TextMesh lbTM;
    TextMesh rbTM;
    TextMesh countdownTM;
    TextMesh outroTM;

    private float time = 0.0f;
    private float fsize = 0.0f;

    public GameObject loose;

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
            else if (txm.name == "Countdown")
                countdownTM = txm;
            else if (txm.name == "LB")
                lbTM = txm;
            else if (txm.name == "RB")
                rbTM = txm;
            else if (txm.name == "Outro")
                outroTM = txm;
        }

        ShowQuestion(false);

        waitingTM.renderer.enabled = false;
        countdownTM.renderer.enabled = false;
        outroTM.renderer.enabled = false;
	}

    void ShowQuestion(bool show)
    {
        questionTM.renderer.enabled = show;
        answer1TM.renderer.enabled = show;
        answer2TM.renderer.enabled = show;
        lbTM.renderer.enabled = show;
        rbTM.renderer.enabled = show;
    }

    void GenerateQuestion()
    {
        nrPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

        question = QuestionBank.GetQuestion();
        collectedAnswers = new int[nrPlayers];

        waitingTM.renderer.enabled = false;
        introTM.renderer.enabled = false;
        countdownTM.renderer.enabled = false;

        answer1TM.text = question.answer1;
        answer2TM.text = question.answer2;
        questionTM.text = question.question;

        ShowQuestion(true);
    }

	// Update is called once per frame
	void Update () {

        if (intro)
        {
            time += Time.deltaTime;

            if (time > 2)
                countdownTM.text = "1";
            else if (time > 1)
                countdownTM.text = "2";
            else
                countdownTM.text = "3";

            if (time > 3)
            {
                GenerateQuestion();

                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject playah in players)
                {
                    playah.GetComponent<Player>().qstate = Player.QUESTIONSTATE.INPUT;
                }

                intro = false;
            }
        }
        else if (inited)
        {
            nrPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

            print(nrPlayers);

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
                introTM.renderer.enabled = false;
                waitingTM.renderer.enabled = false;

                countdownTM.renderer.enabled = true;

                intro = true;
                inited = false;
            }
        }
        else if (outro)
        {
            time += Time.deltaTime;
            if (time < 1.4f)
            {
                fsize += Time.time * 1.8f;

                if (outroTM.fontSize < 600)
                {
                    outroTM.fontSize = (60 + (int)(fsize));
                }
            }
            else
            {
                outroTM.renderer.enabled = false;
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

    private void ShowEndText(bool win)
    {
        if (win)
        {
            outroTM.color = Color.green;
            outroTM.text = "Correct!";
        }
        else
        {
            outroTM.color = Color.red;
            outroTM.text = "Incorrect!";
        }

        outroTM.renderer.enabled = true;
        outro = true;
        time = 0.0f;
        print("end");
    }

    private void AnswersDone()
    {
        if (question.correctAnswer == 0)
        {
            answer1TM.color = Color.green;
            answer2TM.color = Color.red;
        }
        else
        {
            answer1TM.color = Color.red;
            answer2TM.color = Color.green;
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        int i = 0;
        foreach (GameObject playah in players)
        {    
            // Award scores and set state
            if (collectedAnswers[playah.GetComponent<Player>().JoyStickNum - 1] == question.correctAnswer)
            {
                playah.GetComponent<Player>().AddScore(2);
                //set player state to moving

                print("Correct answer!");
                i++;
            }
            else
                playah.GetComponent<Player>().AddScore(-2);

            playah.GetComponent<Player>().Unlock();
        }

        if (i == nrPlayers)
        {
            ShowEndText(true);
        }
        else
        {
            if (loose != null)
            {
                GameObject g = (GameObject)Instantiate(loose);
                g.GetComponent<SpawnEnemy>().Trigger();
            }

            ShowEndText(false);
        }

        used = true;
    }
}
