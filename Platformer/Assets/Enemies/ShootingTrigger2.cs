using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrigger2 : MonoBehaviour
{

    public float speed = 10f; //Скорость движения пули
    public Rigidbody2D bullet; //Пуля как физический объект
    public Transform gunPoint; //Позиция откуда стреляет враг
    public float fireRate = 1; //Частота стрельбы в секундах
    public Transform player; //Наш игровой персонаж
    private Rigidbody2D clone; //Клон создаваемой пули врагом
    float elapsedTime = 0.0f; // Таймер
    public GameObject enemy;
    public GameObject Enemy;

    void Update()
    {
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
            if (elapsedTime > fireRate && Enemy.gameObject.GetComponent<Enemy>().shouldShoot)
            {
                enemy.gameObject.GetComponent<Enemy>().anim.SetBool("Attack", true); //Запуск анимации стрельбы
                StartCoroutine(ShootingOnce()); //Запуск коротины для разового воспроизведения анимации стрельбы врага
                elapsedTime = 0.0f; //Обнуление таймера
                clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation) as Rigidbody2D; //Создание клона пули врага
            }
        }
    }

    IEnumerator ShootingOnce() //Коротина разового воспроизведения анимации стрельбы
    {
        yield return new WaitForSeconds(0.3f); //Ждем время, которое немного меньше полного времени анимации ( у меня 0.35)
        enemy.gameObject.GetComponent<Enemy>().anim.SetBool("Attack", false); //Выключаем анимацию стрельбы
    }
}
