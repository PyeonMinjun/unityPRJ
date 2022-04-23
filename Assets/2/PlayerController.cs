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
        //score 값이 음수가 되지 않도록
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
        //플레이어 사망 애니메이션 재생 중일 떄 이동 ,공격이 불가능하게 설정
        if (isDie == true) return;

        //방향 키를 눌러 이동 방향 설정 상하 좌우 이동방향 전달
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        // 공격 키를 down/up으로 공격 시작/종료
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
        // 플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하도록 함
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x), 
                                          Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));

    }

    public void Ondie()
    {
        //이동 방향 초기화
        movement2D.MoveTo(Vector3.zero);
        //사망 애니메이션 재생
        animator.SetTrigger("onDie");
        //적들과 충돌하지 않도록 충돌 박스 삭제
        Destroy(GetComponent<CircleCollider2D>());
        isDie = true;
    }    

    public void OnDieEvent()
    {
        //디바이스 흭득한 점수 socre 저장
        PlayerPrefs.SetInt("Score", score);
        //플레이어 사망 시 nextSceneName 씬으로 이동
        SceneManager.LoadScene(nextSceneName);
    }
}
