using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [Header("���̵� �ð�")]
    [SerializeField]
    private float fadeDuration = 1f;
    [Header("�̹����� ��µǴ� �ð�")]
    private float displayImageDuration = 1f;
    [Header("�÷��̾� ���ӿ�����Ʈ")]
    [SerializeField]
    private GameObject player;
    [Header("���� ĵ���� �׷�")]
    [SerializeField]
    private CanvasGroup exitBackgroundImageGroup = null;
    [Header("���� ĵ���� �׷�")]
    [SerializeField]
    private CanvasGroup caughtBackgroundImageGroup = null;

    [Header("���� ����")]
    [SerializeField]
    private AudioSource exitAudio;
    [Header ("���� ����")]
    [SerializeField]
    private AudioSource caughtAudio;
    private bool hasAudioPlayed = false;

    private bool isPlayerExit = false;
    private bool isPlayerCaught = false;

    private float timer = 0f;

    private void Update()
    {
        if (isPlayerExit == true)
        {
            EndLevel(exitBackgroundImageGroup, false, exitAudio);
        }
        else if(isPlayerCaught == true)
        {
            EndLevel(caughtBackgroundImageGroup, true, caughtAudio);
        }
    }

    private void EndLevel(CanvasGroup imageGroup, bool doRestart, AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        // timer = timer + Time.deltaTime;

        imageGroup.alpha = timer / fadeDuration;

        if(timer > fadeDuration + displayImageDuration)
        {
            if (doRestart == true)
            {
                SceneManager.LoadScene(0);
            }
            else 
            {
                Application.Quit();
            }            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // .Equals : ==�� ������ ������ �� ����
        if (other.gameObject.Equals(player))
        {
            isPlayerExit = true;
        }
    }

    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }
}
