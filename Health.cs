using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //Текущее здоровье игрока
    public int currenthealth = 10;
    //Максимальное здоровье игрока
    public int maxHealth = 10;
    //Компонент, отвечающий за проигрывание звуков
    public AudioSource audioSource;
    //Звуковой файл, содержащий звуковой эффект нанесения урона
    public AudioClip damageSound;
    //Метод, обрабатывающий нанесённый урон
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;

        //Если здоровье ещё есть, то проигрывается звук нанесения урона
        if (currenthealth > 0)
        {
            audioSource.PlayOneShot(damageSound);
            //print("Здоровье игрока: " + health);
        }
        //Если здоровья нет, то перезапускается текущая сцена
        else
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}




using System.Collections;              // ← Подключаем библиотеки
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;     // ← Для перезагрузки сцены

public class Health : MonoBehaviour    // ← Класс Health (модуль здоровья)
{
   

    public int currenthealth = 10;     // ← Текущее здоровье
                                       //   public = видно в Inspector
                                       //   int = целое число (10, 8, 5)
                                       //   = 10 означает начальное значение

    public int maxHealth = 10;         // ← Максимальное здоровье
                                       //   Нужно для UI (полоска здоровья)

    // ═══════════════════════════════════════════════════════════════
    // СВЯЗКИ ЧЕРЕЗ INSPECTOR (нужно перетащить мышкой!)
    // ═══════════════════════════════════════════════════════════════

    public AudioSource audioSource;    // ← Ссылка на AudioSource (для проигрывания звуков)
                                       //   КАК НАСТРОИТЬ:
                                       //   1. Найти на Player компонент AudioSource
                                       //   2. Перетащить его сюда в Inspector
                                       //
                                       //   КАК БЫЛО РАНЬШЕ:
                                       //   В старом Player.cs это было внутри того же скрипта
                                       //
                                       //   КАК СТАЛО:
                                       //   Health получает ссылку извне (через Inspector)

    public AudioClip damageSound;      // ← Ссылка на звуковой файл урона
                                       //   AudioClip = звуковой файл
                                       //   КАК НАСТРОИТЬ:
                                       //   1. Найти звуковой файл в папке Assets
                                       //   2. Перетащить его сюда в Inspector

    // ═══════════════════════════════════════════════════════════════
    // МЕТОД: ПОЛУЧЕНИЕ УРОНА
    // ═══════════════════════════════════════════════════════════════
    // Этот метод ВЫЗЫВАЮТ другие скрипты:
    // - Enemy.cs вызывает при столкновении
    // - Temperature.cs вызывает при замерзании
    //
    // КАК ЕГО ВЫЗЫВАЮТ:
    // 1) Через GetComponent (Enemy):
    //    Health health = player.GetComponent<Health>();
    //    health.TakeDamage(2);
    //
    // 2) Через ссылку в Inspector (Temperature):
    //    public Health health; // перетащили в Inspector
    //    health.TakeDamage(2);
    // ═══════════════════════════════════════════════════════════════

    public void TakeDamage(int damage) // ← public = можно вызвать из других скриптов
    {                                  //   void = ничего не возвращает
                                       //   int damage = параметр (сколько урона наносим)

        currenthealth -= damage;       // ← Отнимаем урон от текущего здоровья
                                       // ↑            ↑  ↑
                                       // │            │  └─ Количество урона (например, 2)
                                       // │            └─ Отнять и присвоить (-=)
                                       // └─ Текущее здоровье
                                       //
                                       // Пример:
                                       // Было: currenthealth = 10
                                       // Получили урон: damage = 2
                                       // Стало: currenthealth = 8

        // ───────────────────────────────────────────────────────────
        // ПРОВЕРКА: ЖИВ ЛИ ИГРОК?
        // ───────────────────────────────────────────────────────────

        if (currenthealth > 0)         // ← Если здоровье больше нуля
        {                              //   > означает "больше"

            // ИГРОК ЖИВ → проигрываем звук урона

            audioSource.PlayOneShot(damageSound);
            // ↑          ↑           ↑
            // │          │           └─ Какой звук проиграть
            // │          └─ PlayOneShot = проиграть звук один раз
            // └─ AudioSource (компонент для звука, перетащили в Inspector)
        }
        else                           // ← Иначе (здоровье <= 0)
        {
            // ИГРОК МЁРТВ → перезагружаем уровень

            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            // ↑            ↑ ↑                          ↑
            // │            │ └─ Получаем текущую сцену └─ Номер сцены
            // │            └─ SceneManager = менеджер сцен Unity
            // └─ Сохраняем номер сцены в переменную

            SceneManager.LoadScene(sceneIndex);
            // ↑           ↑         ↑
            // │           │         └─ Загружаем сцену по номеру
            // │           └─ Метод загрузки сцены
            // └─ SceneManager
            //
            // Результат: уровень перезапускается, игра начинается заново
        }
    }

} // ← Конец класса Health


## 🔗 Два способа связать модули

### 1️⃣ Через Inspector (постоянная связь)

```csharp
public Health health;  // Перетащить в Inspector
```

**Когда использовать: **
-Связь известна заранее
-Связь постоянная (работает всё время)
- Примеры: PlayerUI → Health, Temperature → Health

---

### 2️⃣ Через GetComponent (поиск при касании)

```csharp
Health health = other.GetComponent<Health>();
if (health != null)
{
    health.TakeDamage(2);
}
```

**Когда использовать: **
-НЕ знаем заранее, с кем столкнёмся
- Разовое взаимодействие (собрали монетку, получили урон)
- Примеры: Enemy → Health, Coin → CoinsCounter, Bonfire → Temperature
