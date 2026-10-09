using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAttack : MonoBehaviour
{
    //Префаб огненного шара и параметр Transform точки атаки
    public GameObject fireballPrefab;
    public Transform attackPoint;

    void Update()
    {
        //Если игрок кликает левой кнопкой мыши, то создаётся огненный шар
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, attackPoint.position, attackPoint.rotation);
        }
    }
}


using System.Collections;              // ← Подключаем библиотеки
using System.Collections.Generic;
using UnityEngine;

public class FireballAttack : MonoBehaviour // ← Класс FireballAttack (модуль атаки)
{
    // ═══════════════════════════════════════════════════════════════
    // СВЯЗКИ ЧЕРЕЗ INSPECTOR (нужно перетащить мышкой!)
    // ═══════════════════════════════════════════════════════════════

    public GameObject fireballPrefab;  // ← Ссылка на префаб огненного шара
                                       //   GameObject = игровой объект
                                       //   Префаб = заготовка объекта (шаблон)
                                       //
                                       //   КАК НАСТРОИТЬ:
                                       //   1. Найти в Project папку Prefabs
                                       //   2. Найти файл Fireball.prefab
                                       //   3. Перетащить его сюда в Inspector
                                       //
                                       //   КАК БЫЛО РАНЬШЕ:
                                       //   Эта переменная была в Player.cs
                                       //
                                       //   КАК СТАЛО:
                                       //   Переменная в отдельном модуле FireballAttack

    public Transform attackPoint;      // ← Ссылка на точку атаки (откуда летит файербол)
                                       //   Transform = позиция и поворот объекта
                                       //
                                       //   КАК НАСТРОИТЬ:
                                       //   1. Создать пустой объект (Hierarchy → Create Empty)
                                       //   2. Сделать его дочерним для Player (перетащить на Player)
                                       //   3. Назвать "AttackPoint"
                                       //   4. Передвинуть ПЕРЕД игроком (где должен появляться файербол)
                                       //   5. Перетащить AttackPoint сюда в Inspector
                                       //
                                       //   ЗАЧЕМ НУЖЕН AttackPoint:
                                       //   Без него файербол появлялся бы в центре игрока (в ногах)
                                       //   С AttackPoint файербол появляется перед игроком

    // ═══════════════════════════════════════════════════════════════
    // МЕТОД UPDATE: СТРЕЛЬБА
    // ═══════════════════════════════════════════════════════════════
    // КАК БЫЛО РАНЬШЕ:
    // Весь этот код был внутри Player.cs в методе Update()
    //
    // КАК СТАЛО:
    // Теперь стрельба в отдельном модуле
    // ═══════════════════════════════════════════════════════════════

    void Update()                      // ← Вызывается каждый кадр
    {

        if (Input.GetMouseButtonDown(0)) // ← Проверяем: нажата ли левая кнопка мыши?
        {                              //   Input = система ввода Unity
                                       //   GetMouseButtonDown = нажатие кнопки мыши (один раз)
                                       //   0 = левая кнопка, 1 = правая, 2 = средняя
                                       //   Down = в момент нажатия (не удержание!)
                                       //
                                       //   GetMouseButtonDown(0) - срабатывает один раз при нажатии
                                       //   GetMouseButton(0) - срабатывает, пока кнопка зажата

            // СОЗДАНИЕ ОГНЕННОГО ШАРА

            Instantiate(fireballPrefab, attackPoint.position, attackPoint.rotation);
            // ↑          ↑               ↑                    ↑
            // │          │               │                    └─ Rotation = поворот AttackPoint
            // │          │               │                       (куда смотрит → туда полетит файербол)
            // │          │               └─ Position = позиция AttackPoint (где создать)
            // │          └─ ЧТО создаём (префаб файербола)
            // └─ Instantiate = метод Unity для создания копии объекта
            //
            // Что происходит:
            // 1. Unity берёт префаб fireballPrefab (шаблон)
            // 2. Создаёт его копию в точке attackPoint.position
            // 3. Поворачивает копию так же, как attackPoint.rotation
            // 4. У файербола есть свой скрипт движения, он начинает лететь
            //
            // Пример:
            // AttackPoint находится перед игроком на позиции (5, 1, 0)
            // AttackPoint смотрит вправо (rotation = 90°)
            // Instantiate создаст файербол на (5, 1, 0) смотрящий вправо
            // Файербол полетит вправо
        }
    }

} // ← Конец класса FireballAttack