using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject player;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player"); 
    }
    private void Update()
    {
        //добавляем Enemy физическое движение
        //для того чтоб Enemy гнался за Player мы высчитываем вектор направления
        //и вектор направления всегда равен player.transform.position - transform.position
        // то есть вычитаем вектор игрока из вектора врага(ну или любых других объектов)
        //и полуаем тот вектор по которому нужно двигаться
        //NORMALIZED делает так что любая цифра полученная становится около единицы то есть все происходит в
        //рамках от -1 до 1;
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
