using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    //Число собранных монет
    public int coins;

    //Метод, увеличивающий число монеток
    public void CollectCoins()
    {
        coins++;
        //print("Собранные монетки: " + coins);
    }
}


using System.Collections;              // ← Подключаем библиотеки
using System.Collections.Generic;
using UnityEngine;

public class CoinsCounter : MonoBehaviour // ← Класс CoinsCounter (модуль счётчика монет)
{
    

    public int coins;                  // ← Количество собранных монет
                                       //   public = видно в Inspector И другие скрипты могут читать
                                       //   int = целое число (0, 1, 2, 3...)
                                       //
                                       //   КАК БЫЛО РАНЬШЕ:
                                       //   В старом Player.cs: private int coins;
                                       //   (private = скрыто от других скриптов)
                                       //
                                       //   КАК СТАЛО:
                                       //   public int coins; в отдельном модуле
                                       //   Теперь другие скрипты могут читать значение!

    // ═══════════════════════════════════════════════════════════════
    // МЕТОД: СОБРАТЬ МОНЕТКУ
    // ═══════════════════════════════════════════════════════════════
    // Этот метод ВЫЗЫВАЕТ скрипт Coin.cs
    //
    // КАК ЕГО ВЫЗЫВАЮТ (в Coin.cs):
    // void OnTriggerEnter(Collider other) {
    //     CoinsCounter coins = other.GetComponent<CoinsCounter>(); ← Находим модуль
    //     if (coins != null) {
    //         coins.CollectCoins(); ← Вызываем этот метод
    //     }
    // }
    // ═══════════════════════════════════════════════════════════════

    public void CollectCoins()         // ← public = можно вызвать из других скриптов
    {                                  //   void = ничего не возвращает

        coins++;                       // ← Увеличиваем счётчик на 1
                                       // ↑   ↑
                                       // │   └─ ++ означает "прибавить 1"
                                       // └─ Переменная coins
                                       //
                                       // Эквивалентно: coins = coins + 1;
                                       //
                                       // Пример:
                                       // Было: coins = 5
                                       // Собрали монетку: coins++ выполнился
                                       // Стало: coins = 6

        // ───────────────────────────────────────────────────────────
        // ВЫВОД В КОНСОЛЬ (закомментирован)
        // ───────────────────────────────────────────────────────────

        //print("Собранные монетки: " + coins);
        //
        // КАК БЫЛО РАНЬШЕ:
        // В старом Player.cs здесь был print("Собранные монетки: " + coins);
        // Информация выводилась в консоль Unity
        //
        // КАК СТАЛО:
        // Убрали print, потому что PlayerUI сам показывает монетки на экране!
        // PlayerUI читает переменную coins и обновляет текст:
        //   coinsCounterText.text = coinsCount.coins.ToString();
        //
        // Если хотите включить для отладки, уберите // перед print
    }

} // ← Конец класса CoinsCounter