using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemperatureUI : MonoBehaviour
{
	public Temperature temperature;
	public TextMeshProUGUI temperatureText;

	void Update()
	{
		float roundTemperature = Mathf.Round(temperature.temperatureCurrent * 10.0f) * 0.1f;
		temperatureText.text = roundTemperature.ToString();
	}
}


using System.Collections;              // ← Подключаем библиотеки
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                  // ← Для UI элементов
using TMPro;                           // ← Для TextMeshPro

public class TemperatureUI : MonoBehaviour // ← Класс TemperatureUI (интерфейс температуры)
{
    // ═══════════════════════════════════════════════════════════════
    // СВЯЗКИ ЧЕРЕЗ INSPECTOR (нужно перетащить мышкой!)
    // ═══════════════════════════════════════════════════════════════

    public Temperature temperature;    // ← Ссылка на модуль Temperature
                                       //   Отсюда берём текущую температуру
                                       //
                                       //   КАК НАСТРОИТЬ:
                                       //   1. Выбрать объект с TemperatureUI в Hierarchy
                                       //   2. Найти Player в Hierarchy
                                       //   3. Перетащить Player на это поле в Inspector
                                       //   4. Unity сам найдёт компонент Temperature на Player!
                                       //
                                       //   СВЯЗЬ МОДУЛЕЙ:
                                       //   TemperatureUI → Temperature (через Inspector)
                                       //   TemperatureUI читает temperature.temperatureCurrent

    public TextMeshProUGUI temperatureText; // ← Ссылка на текстовый элемент
                                            //   TextMeshProUGUI = тип текста в Unity (на Canvas)
                                            //   Здесь будем показывать температуру
                                            //
                                            //   КАК НАСТРОИТЬ:
                                            //   1. Создать на Canvas → UI → Text (TextMeshPro)
                                            //   2. Назвать "TemperatureText"
                                            //   3. Перетащить его сюда в Inspector

    // ═══════════════════════════════════════════════════════════════
    // МЕТОД UPDATE: ОБНОВЛЕНИЕ ОТОБРАЖЕНИЯ ТЕМПЕРАТУРЫ
    // ═══════════════════════════════════════════════════════════════

    void Update()                      // ← Вызывается каждый кадр
    {

        // ───────────────────────────────────────────────────────────
        // ОКРУГЛЕНИЕ ТЕМПЕРАТУРЫ ДО ОДНОЙ ЦИФРЫ ПОСЛЕ ЗАПЯТОЙ
        // ───────────────────────────────────────────────────────────

        float roundTemperature = Mathf.Round(temperature.temperatureCurrent * 10.0f) * 0.1f;
        // ↑                      ↑     ↑     ↑          ↑                  ↑ ↑       ↑ ↑
        // │                      │     │     │          │                  │ │       │ └─ Делим на 10
        // │                      │     │     │          │                  │ └─ Умножаем
        // │                      │     │     │          │                  └─ 10.0f
        // │                      │     │     │          └─ temperatureCurrent = текущая температура
        // │                      │     │     └─ temperature = ссылка на модуль Temperature
        // │                      │     └─ Round = функция округления
        // │                      └─ Mathf = класс Unity для математики
        // └─ roundTemperature = округлённая температура
        //
        // Разбор формулы:
        // Зачем умножать на 10 и делить на 0.1?
        // Это хитрый способ округлить до одной цифры после запятой!
        //
        // Пример 1:
        // temperature.temperatureCurrent = 36.6428
        // Умножаем на 10: 36.6428 * 10 = 366.428
        // Округляем: Mathf.Round(366.428) = 366
        // Умножаем на 0.1: 366 * 0.1 = 36.6
        // Результат: 36.6 ✓
        //
        // Пример 2:
        // temperature.temperatureCurrent = 35.9873
        // Умножаем на 10: 35.9873 * 10 = 359.873
        // Округляем: Mathf.Round(359.873) = 360
        // Умножаем на 0.1: 360 * 0.1 = 36.0
        // Результат: 36.0 ✓
        //
        // Зачем округлять?
        // Без округления: 36.64285714285714 (слишком много цифр)
        // С округлением: 36.6 (красиво и понятно)

        // ───────────────────────────────────────────────────────────
        // ОТОБРАЖЕНИЕ ТЕМПЕРАТУРЫ НА ЭКРАНЕ
        // ───────────────────────────────────────────────────────────

        temperatureText.text = roundTemperature.ToString();
        // ↑              ↑      ↑                ↑
        // │              │      │                └─ ToString() = преобразовать число в текст
        // │              │      │                   36.6 → "36.6"
        // │              │      └─ roundTemperature = округлённая температура (36.6)
        // │              └─ text = свойство TextMeshProUGUI (текст элемента)
        // └─ temperatureText = ссылка на текстовый элемент (перетащили в Inspector)
        //
        // Что происходит:
        // 1. Берём округлённую температуру (36.6)
        // 2. Преобразуем в текст ToString() → "36.6"
        // 3. Присваиваем текст UI элементу .text = "36.6"
        // 4. На экране игрок видит: 36.6
        //
        // Это работает каждый кадр, поэтому:
        // - Температура упала до 35.4 → Update() прочитает 35.4 → На экране: 35.4
        // - Игрок у костра, температура растёт 35.5 → 35.6 → 35.7 → ...
        // - Всё обновляется автоматически!
    }

} // ← Конец класса TemperatureUI