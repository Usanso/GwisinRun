using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game UI")]
    [SerializeField] private GameObject m_pausedMenu;
    [SerializeField] private GameObject m_gameStartPanel;
    public static GameObject GameStartPanel;
    
    public static GameObject GameOverPanel;
    [SerializeField] private GameObject m_gameOverPanel;
    
    [Header("Basic Setting")]
    // PlayerController
    [HideInInspector] public CharacterController PlayerCont;
    // Player 위치
    [HideInInspector] public Transform PlayerTransform;
    // 머리 충돌 판정 오브젝트
    [HideInInspector] public PlayerHide HeadTriggerObject;

    private void Awake()
    {
        PlayerCont = GetComponent<CharacterController>();
        HeadTriggerObject = GetComponentInChildren<PlayerHide>();
        PlayerTransform = transform;
        
        GameStartPanel = m_gameStartPanel;
        GameOverPanel = m_gameOverPanel;
    }

    void Update()
    {
        CheckPauseKeyPressed();
    }

    private void CheckPauseKeyPressed()
    {
        if (GameManager.Instance.Input.PauseKeyPressed)
        {
            if (GameStartPanel != null && GameStartPanel.activeSelf == true)
                return;
            
            if (GameManager.Instance.IsPaused == false)
            {
                m_pausedMenu.SetActive(true);
            }
            else
            {
                m_pausedMenu.SetActive(false);
                m_pausedMenu.GetComponent<PauseMenuUI>().Close();
            }
        }
    } 

    public void Die()
    {
        GameOverPanel.SetActive(true);
    }
}

