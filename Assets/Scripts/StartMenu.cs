using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour
{

    public GameObject book;
    public GameObject frontCover;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;
    public GameObject page8;
    public GameObject page9;
    public GameObject page10;
    public GameObject page11;
    public GameObject page12;
    public GameObject page13;
    public GameObject page14;
    public GameObject page15;
    public GameObject page16;
    public GameObject page17;
    public GameObject page18;

    public Text spellName;
    public Text spellDamage;
    public Text spellVelocity;
    public Text spellDescription;
    public Image shape00;
    public Image shape01;
    public Image shape02;
    public Image shape10;
    public Image shape11;
    public Image shape12;
    public Image shape20;
    public Image shape21;
    public Image shape22;
    public Button playButton;
    public Button spellBookButton;
    public Button quitButton;

    private bool openingFrontCover;
    private bool turningToSpellBook;
    private bool turningSpellPage;

    private Spell testSpell;
    private Spell testSpell1;
    private Quaternion originalRot;

    // Use this for initialization
    void Start() {
        openingFrontCover = true;
        turningToSpellBook = true;
        turningSpellPage = false;
        testSpell = new Spell("Attack", 10f, 5f, "This is an attack spell.", new bool[3, 3] { { true, true, true }, { false, true, false }, { true, true, false } });
    }

    void loadPlayScene() {
        SceneManager.LoadScene("Play");
    }

    void openSpellBook() {
        
    }

    void quitGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    IEnumerator turnBookElement(GameObject g, float delay)
	{
        yield return new WaitForSeconds(delay);
		Vector3 pivot = new Vector3(book.transform.position.x + 0.1825f, book.transform.position.y, book.transform.position.z);
		g.transform.RotateAround(pivot, Vector3.forward, -1f);
	}

    private void setSpellPageContent(Spell s) {
		shape00.color = s.getShape()[0, 0] ? Color.black : Color.clear;
		shape01.color = s.getShape()[0, 1] ? Color.black : Color.clear;
		shape02.color = s.getShape()[0, 2] ? Color.black : Color.clear;
		shape10.color = s.getShape()[1, 0] ? Color.black : Color.clear;
		shape11.color = s.getShape()[1, 1] ? Color.black : Color.clear;
		shape12.color = s.getShape()[1, 2] ? Color.black : Color.clear;
		shape20.color = s.getShape()[2, 0] ? Color.black : Color.clear;
		shape21.color = s.getShape()[2, 1] ? Color.black : Color.clear;
		shape22.color = s.getShape()[2, 2] ? Color.black : Color.clear;
		spellName.text = s.getName();
		spellVelocity.text = "Velocity: " + s.getVelocity().ToString();
		spellDamage.text = "Damage: " + s.getDamage().ToString();
		spellDescription.text = s.getDescription();
    }

	// Update is called once per frame
	void Update() {
        if (openingFrontCover) {
            StartCoroutine(turnBookElement(frontCover, 0f));
            StartCoroutine(turnBookElement(page1, 1.0f));
            StartCoroutine(turnBookElement(page2, 1.2f));
            StartCoroutine(turnBookElement(page3, 1.4f)); 
        } else if (turningToSpellBook) {
            StartCoroutine(turnBookElement(page4, 1.0f));
			StartCoroutine(turnBookElement(page5, 1.2f));
        }
        if (frontCover.transform.rotation.eulerAngles.x >= 276 && frontCover.transform.rotation.eulerAngles.z == 270f) {
            openingFrontCover = false;
        }
        if (turningToSpellBook && page4.transform.rotation.eulerAngles.x >= 310f && page4.transform.rotation.eulerAngles.x <= 320f && page4.transform.rotation.eulerAngles.y == 270f && page4.transform.rotation.eulerAngles.z == 90f) {
			turningToSpellBook = false;
            turningSpellPage = true;
            originalRot = page6.transform.rotation;
            setSpellPageContent(testSpell);
        }
        if (turningSpellPage) {
            StartCoroutine(turnBookElement(page6, 1f));
            Debug.Log(page6.transform.rotation.eulerAngles);
			//testSpell1 = new Spell("Defend", 11f, 6f, "This is an defense spell.", new bool[3, 3] { { true, true, true }, { false, false, true }, { true, true, true } });
			//setSpellPageContent(testSpell1);
		}
        if (page6.transform.rotation.eulerAngles.x >= 280 && page6.transform.rotation.eulerAngles.y == 90 && page6.transform.rotation.eulerAngles.z == 270) {
            turningSpellPage = false;
            //page5.transform.rotation = page6.transform.rotation;
            page6.transform.rotation = originalRot;
			testSpell1 = new Spell("Defend", 11f, 6f, "This is an defense spell.", new bool[3, 3] { { true, true, true }, { false, false, true }, { true, true, true } });
			setSpellPageContent(testSpell1);
		}
	}
}
