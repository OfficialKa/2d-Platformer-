using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrigger1 : MonoBehaviour
{

    public float speed = 10f; //Скорость движения пули
    public Rigidbody2D bullet; //Пуля как физический объект
    public Transform gunPoint; //Позиция откуда стреляет враг
    public float fireRate = 1; //Частота стрельбы в секундах
    public Transform player; //Наш игровой персонаж
    private Rigidbody2D clone; //Клон создаваемой пули врагом
    float elapsedTime = 0.0f; // Таймер
    private bool attack = false;
    private bool idle = true;
    public GameObject Enemy;
    private Animator anim;
    void Start()
    {
        anim = Enemy.GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetBool("enemyIdle", idle);
    }

    void OnTriggerStay2D(Collider2D other)
    {
       
        //Стрельба врага, если персонаж попадает в действие триггера
        if (other.gameObject.CompareTag("Player"))
        {
            //Установка рандомной частоты стрельбы каждый раз, когда персонаж заходит в триггер
            fireRate = Random.Range(0.5f, 3f);
            //Запуск таймера
            elapsedTime += Time.deltaTime;
           
            //Если пришло время стрелять и враг может стрелять, то враг стреляет
            if (elapsedTime > fireRate && enemy.shouldShoot)
            {
                Enemy.gameObject.GetComponent<enemy>(); //Запуск анимации стрельбы
                anim.SetBool("Attack", true);
                anim.SetBool("enemyIdle", false);
                StartCoroutine(ShootingOnce()); //Запуск коротины для разового воспроизведения анимации стрельбы врага
                elapsedTime = 0.0f; //Обнуление таймера
                clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation) as Rigidbody2D; //Создание клона пули врага
            }
        }
    }

    IEnumerator ShootingOnce() //Коротина разового воспроизведения анимации стрельбы
    {
        print("123123");
        yield return new WaitForSeconds(0.3f); //Ждем время, которое немного меньше полного времени анимации ( у меня 0.35)
        Enemy.gameObject.GetComponent<enemy>(); //Выключаем анимацию стрельбы
        anim.SetBool("Attack", false);
        anim.SetBool("enemyIdle", true);
    }
}
