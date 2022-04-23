using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode KeyCodeAttack = KeyCode.Space;
    private bool isDie = false;
    private Movement2D movement2D;
    private Weapon weapon;
    private Animator animator;

    private int score;
    public int  Score
    {
        //score ���� ������ ���� �ʵ���
        set => score = Mathf.Max(0, value);
        get => score;
    }


    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
    }




    private void Update()
    {
        //�÷��̾� ��� �ִϸ��̼� ��� ���� �� �̵� ,������ �Ұ����ϰ� ����
        if (isDie == true) return;

        //���� Ű�� ���� �̵� ���� ���� ���� �¿� �̵����� ����
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        // ���� Ű�� down/up���� ���� ����/����
        if (Input.GetKeyDown(KeyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(KeyCodeAttack))
        {
            weapon.StopFiring();
        }

    }

    private void LateUpdate()
    {                                                                
        // �÷��̾� ĳ���Ͱ� ȭ�� ���� �ٱ����� ������ ���ϵ��� ��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x), 
                                          Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));

    }

    public void Ondie()
    {
        //�̵� ���� �ʱ�ȭ
        movement2D.MoveTo(Vector3.zero);
        //��� �ִϸ��̼� ���
        animator.SetTrigger("onDie");
        //����� �浹���� �ʵ��� �浹 �ڽ� ����
        Destroy(GetComponent<CircleCollider2D>());
        isDie = true;
    }    

    public void OnDieEvent()
    {
        //����̽� ŉ���� ���� socre ����
        PlayerPrefs.SetInt("Score", score);
        //�÷��̾� ��� �� nextSceneName ������ �̵�
        SceneManager.LoadScene(nextSceneName);
    }
}