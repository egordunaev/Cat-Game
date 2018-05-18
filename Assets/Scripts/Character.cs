using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс, описывающий действия персонажа.
/// </summary>
public class Character : Unit
{

    [SerializeField]
    private int lives = 5;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            livesBar.Refresh();
        }
    }

    private LivesBar livesBar;

    [SerializeField]
    private float speed = 3.0F;

    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded = false;

    private Bullet bullet;

    public int score=0;
    


    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State",(int) value); }
    }
    new private Rigidbody2D rigidbody;

    private Animator animator;

    private SpriteRenderer sprite;

    /// <summary>
    /// Метод для получения ссылок на данные компоненты.
    /// </summary>
    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        bullet = Resources.Load<Bullet>("Bullet");
      
    }
    /// <summary>
    /// Метод "фикса" двойного прыжка (возможности прыжка в воздухе).
    /// </summary>
    private void FixedUpdate()
    {
        CheckGround();
    }
    /// <summary>
    /// Метод вызова соответствующих методов при нажатии определенных кнопок.
    /// </summary>
    private void Update()
    {
       if(isGrounded) State = CharState.idle;

        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
    /// <summary>
    /// Метод, описывающий бег персонажа.
    /// </summary>
    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;
        if(isGrounded) State = CharState.runs;
    }
    /// <summary>
    /// Метод, описывающий прыжки персонажа.
    /// </summary>
    private void Jump()
    {   
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    /// <summary>
    /// Метод, описывающий стрельбу персонажа.
    /// </summary>
    private void Shoot()
    {
        Vector3 position = transform.position; position.y += -0.5F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }
    /// <summary>
    /// Метод получения урона персонажем.
    /// </summary>
    public override void ReceiveDamage()
    {
        if (lives != 0)
        {
            Lives--;

            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);

            Debug.Log(lives);
        }
        else
        {
            gameOver();
        }
    }
    /// <summary>
    /// Метод проверки нахождения персонажа на поверхности для возможности прыжка.
    /// </summary>
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0F);
        isGrounded = colliders.Length > 1;
        if(!isGrounded) State = CharState.jump;
    }
    /// <summary>
    /// Метод, описывающий возможность получения урона при столкновении коллайдеров (его компоненты определяют форму объекта для физических столкновений),  а также поедания корма. Условие перехода между сценами.
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.gameObject.GetComponent<Unit>();
        if(unit)
        {
            ReceiveDamage();
        }

        if (collider.gameObject.name == "Korm")
        {
            Destroy(collider.gameObject); score++; PlayerPrefs.SetInt("Score", score);
        }
        if (collider.gameObject.name == "endLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.LoadScene("Level2");


        }
    }
   
    /// <summary>
    /// Заготовка экрана Game Over
    /// </summary>
    public void gameOver()
    {
        PlayerPrefs.SetInt("Score", 0);
        Application.LoadLevel(Application.loadedLevel);
        print("Game Over!");
    }

    /// <summary>
    /// Метод, описывающий вывод окна с отображением очков.
    /// </summary>
    public void OnGUI()
    {

        //PlayerPrefs.SetInt("Score", score);
        if (SceneManager.GetActiveScene().name=="FinalScore")
        {
            GUI.Label(new Rect(280, 95, 100, 100), PlayerPrefs.GetInt("Score").ToString());
        }
        else
        {
            GUI.Box(new Rect(0, 50, 100, 100), "Очки :" + PlayerPrefs.GetInt("Score").ToString());
        }
    }

}
/// <summary>
/// Обозначение последовательности выполнения анимаций.
/// </summary>
public enum CharState
{
    idle,
    runs,
    jump
}

    
