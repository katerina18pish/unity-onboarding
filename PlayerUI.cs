using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
	public CoinsCounter coinsCount;
	public Health health;
	public TextMeshProUGUI coinsCounterText;
	public Slider healthSlider;

	void Update()
	{
		// Обновляем текст с кол-вом монеток
		coinsCounterText.text = coinsCount.coins.ToString();
		// Обновляем значение здоровья игрока
		healthSlider.maxValue = health.maxHealth;
		healthSlider.value = health.currenthealth;
	}
}


using System.Collections;              // ← Подключаем библиотеки
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                  // ← Для UI элементов (Slider)
using TMPro;                           // ← Для TextMeshPro (современный текст Unity)

public class PlayerUI : MonoBehaviour  // ← Класс PlayerUI (модуль интерфейса)
{
    // ═══════════════════════════════════════════════════════════════
    // СВЯЗКИ К ДАННЫМ (модули на игроке)
    // ═══════════════════════════════════════════════════════════════
    // Эти переменные = МОСТИКИ к другим модулям
    // Все настраиваются через Inspector (перетащить мышкой!)

    public CoinsCounter coinsCount;    // ← Ссылка на модуль CoinsCounter
                                       //   Отсюда берём количество монет
                                       //
                                       //   КАК НАСТРОИТЬ:
                                       //   1. Выбрать объект с PlayerUI в Hierarchy
                                       //   2. Найти Player в Hierarchy
                                       //   3. Перетащить Player на это поле в Inspector
                                       //   4. Unity САМ найдёт компонент CoinsCounter на Player!
                                       //
                                       //   КАК БЫЛО РАНЬШЕ:
                                       //   Монетки были внутри Player.cs: private int coins;
                                       //   Мы не могли их прочитать извне
                                       //
                                       //   КАК СТАЛО:
                                       //   Монетки в отдельном модуле CoinsCounter
                                       //   PlayerUI получает ссылку через Inspector
                                       //   Может читать: coinsCount.coins

    public Health health;              // ← Ссылка на модуль Health
                                       //   Отсюда берём текущее и максимальное здоровье
                                       //
                                       //   КАК НАСТРОИТЬ:
                                       //   1. Выбрать объект с PlayerUI в Hierarchy
                                       //   2. Найти Player в Hierarchy
                                       //   3. Перетащить Player на это поле в Inspector
                                       //   4. Unity САМ найдёт компонент Health на Player!
                                       //
                                       //   Можем читать:
                                       //   - health.currenthealth (текущее здоровье)
                                       //   - health.maxHealth (максимальное здоровье)

    // ═══════════════════════════════════════════════════════════════
    // СВЯЗКИ К ИНТЕРФЕЙСУ (UI элементы на Canvas)
    // ═══════════════════════════════════════════════════════════════

    public TextMeshProUGUI coinsCounterText; // ← Ссылка на текстовый элемент для монет
                                             //   TextMeshProUGUI = тип текста в Unity (на Canvas)
                                             //
                                             //   КАК НАСТРОИТЬ:
                                             //   1. Найти на Canvas текстовый элемент (например, "CoinsText")
                                             //   2. Перетащить его сюда в Inspector
                                             //
                                             //   Можем менять текст:
                                             //   coinsCounterText.text = "10";

    public Slider healthSlider;        // ← Ссылка на полоску здоровья
                                       //   Slider = ползунок/полоска в Unity
                                       //
                                       //   КАК НАСТРОИТЬ:
                                       //   1. Найти на Canvas Slider (например, "HealthBar")
                                       //   2. Перетащить его сюда в Inspector
                                       //
                                       //   Можем менять:
                                       //   healthSlider.value = 8; (текущее значение)
                                       //   healthSlider.maxValue = 10; (максимум)

    // ═══════════════════════════════════════════════════════════════
    // МЕТОД UPDATE: ОБНОВЛЕНИЕ ИНТЕРФЕЙСА
    // ═══════════════════════════════════════════════════════════════
    // Каждый кадр читаем данные из модулей и показываем на экране
    //
    // КАК БЫЛО РАНЬШЕ:
    // В Player.cs был print("Монетки: " + coins) в консоль
    // Игрок не видел информацию на экране!
    //
    // КАК СТАЛО:
    // PlayerUI постоянно обновляет UI элементы
    // Игрок видит красивый интерфейс на экране
    // ═══════════════════════════════════════════════════════════════

    void Update()                      // ← Вызывается каждый кадр
    {

        // ───────────────────────────────────────────────────────────
        // ОБНОВЛЕНИЕ СЧЁТЧИКА МОНЕТ
        // ───────────────────────────────────────────────────────────

        coinsCounterText.text = coinsCount.coins.ToString();
        // ↑               ↑     ↑         ↑     ↑
        // │               │     │         │     └─ ToString() = преобразовать число в текст
        // │               │     │         │        5 → "5"
        // │               │     │         └─ coins = переменная из CoinsCounter
        // │               │     │            (сколько монет собрано)
        // │               │     └─ coinsCount = ссылка на модуль CoinsCounter
        // │               │        (перетащили в Inspector)
        // │               └─ text = свойство TextMeshProUGUI (текст элемента)
        // └─ coinsCounterText = ссылка на текстовый элемент
        //    (перетащили в Inspector)
        //
        // Что происходит:
        // 1. Берём значение coinsCount.coins (например, 5)
        // 2. Преобразуем в текст .ToString() ("5")
        // 3. Присваиваем текст UI элементу .text = "5"
        // 4. На экране игрок видит: 5
        //
        // Это работает каждый кадр, поэтому:
        // - Собрали монетку → coins стало 6
        // - В следующем кадре Update() прочитает 6
        // - На экране обновится: 6

        // ───────────────────────────────────────────────────────────
        // ОБНОВЛЕНИЕ ПОЛОСКИ ЗДОРОВЬЯ
        // ───────────────────────────────────────────────────────────

        healthSlider.maxValue = health.maxHealth;
        // ↑           ↑         ↑      ↑
        // │           │         │      └─ maxHealth = переменная из Health (обычно 10)
        // │           │         └─ health = ссылка на модуль Health (перетащили в Inspector)
        // │           └─ maxValue = максимальное значение слайдера
        // └─ healthSlider = ссылка на Slider (перетащили в Inspector)
        //
        // Устанавливаем максимум полоски = 10

        healthSlider.value = health.currenthealth;
        // ↑           ↑      ↑      ↑
        // │           │      │      └─ currenthealth = текущее здоровье из Health
        // │           │      │         (меняется когда получаем урон)
        // │           │      └─ health = ссылка на модуль Health
        // │           └─ value = текущее значение слайдера
        // └─ healthSlider = ссылка на Slider
        //
        // Устанавливаем текущее значение полоски = текущее здоровье
        //
        // Пример работы слайдера:
        // maxValue = 10 (полоска полная при 10)
        // value = 8 (сейчас 8 здоровья)
        // Полоска заполнена на 80% (8 из 10)
        //
        // Получили урон 2:
        // currenthealth стало 6 (в модуле Health)
        // В следующем кадре Update() прочитает 6
        // healthSlider.value станет 6
        // Полоска уменьшится до 60% (6 из 10)
    }

} // ← Конец класса PlayerUI