using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 3; //Установка здоровья врага
    public Transform startPos; //Позиция откуда враг начинает движение
    private bool LookRight = true;  //Смотрит ли враг вправо?
    private bool RightEnd = false; //Достиг ли враг конца движения в правую сторону?
    public float TimeToMoveRight = 1f; //Время для движения вправо
    public float TimeToMoveLeft = 1f; //Время для движения влево
    private Rigidbody2D enemyrb; //Компонент Rigidbody2D врага
    public Animator anim; //Компонент Animator врага
    public bool shouldMove = true; //Должен ли враг двигаться?
    public bool shouldShoot = true; //Должен ли враг стрелять?
    public GameObject Character; //Наш персонаж как игровой объект
    public float speed = 5f; //Скорость движения персонажа
    public bool moveLeft = false; //Движется ли персонаж влево?
    public bool shooting = false; //Стреляет ли враг?

    [SerializeField]
    private int sethealth;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (value <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(this.gameObject, 1);
        shouldMove = false;
        shouldShoot = false;
    }

    public void takeDamage(int damage)
    {
        Health -= damage;
    }

    void Start()
    {
        Health = sethealth;
        enemyrb = GetComponent<Rigidbody2D>();//Получаем компонент Rigidbody в переменную
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -1); //Устанавливаем позицию врага по координате z на -5
        anim = GetComponent<Animator>(); //Получаем компонент Animator в переменную
        StartCoroutine(Move()); //Запускаем движение врага
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Health", health); //Устанавливаем связь между переменной в аниматоре и переменной в скрипте
        if (!RightEnd && shouldMove) //Движение вправо
        {
            MoveRight();
        }
        else if (RightEnd && shouldMove) //Движение влево
        {
            MoveLeft();
        }

        if (!shouldMove && !shooting) //Смерть врага
        {
            StartCoroutine(WaitBeforeDelete());
        }
    }

    private void Flip() //Метод поворота врага на 180 градусов
    {
        LookRight = !LookRight;
        transform.Rotate(0, 180, 0);
    }

    private void MoveRight() //Метод движения врага вправо
    {
        moveLeft = false;
        enemyrb.transform.position = new Vector3(transform.position.x + 0.1f*speed, transform.position.y, transform.position.z);

    }

    private void MoveLeft() //Метод движения врага влево
    {
        moveLeft = true;
        enemyrb.transform.position = new Vector3(transform.position.x - 0.1f*speed, transform.position.y, transform.position.z);
    }

    IEnumerator WaitBeforeDelete() //Коротина ожидания проигрывания анимации перед смертью
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    IEnumerator Move() //Коротина движения персонажа
    {
        if (shouldMove)
        {
            yield return new WaitForSeconds(TimeToMoveRight);
            RightEnd = true;
            moveLeft=false;
            Flip();
            yield return new WaitForSeconds(TimeToMoveLeft);
            RightEnd = false;
            moveLeft = true;
            Flip();
            StartCoroutine(Move());
        }
    }
}
