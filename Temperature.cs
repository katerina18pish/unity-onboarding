using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
	public Health health;
	public int playerDamage = 2;
	public float temperatureCurrent = 36.6f;
	public float temperatureNormal = 36.6f;
	public float temperatureCritical = 34f;
	public float freezeSpeed = 0.05f;
	float freezeDamageTimer = 1;
	public float freezeDamageDelay = 2;

	void Update()
	{
		// Температура постоянно убывает с указанной скоростью
		temperatureCurrent -= freezeSpeed * Time.deltaTime;

		// Если температура тела упала ниже критической
		if (temperatureCurrent <= temperatureCritical)
		{
			if (freezeDamageTimer <= 0)
			{
				health.TakeDamage(playerDamage);
				freezeDamageTimer += freezeDamageDelay;
			}
			else
			{
				freezeDamageTimer -= Time.deltaTime;
			}
		}
	}
}





using System.Collections;              // ← Подключаем библиотеки
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour // ← Класс Temperature (система температуры)
{
    // ═══════════════════════════════════════════════════════════════
    // СВЯЗКА К МОДУЛЮ HEALTH (через Inspector)
    // ═══════════════════════════════════════════════════════════════

    public Health health;              // ← Ссылка на модуль Health
                                       //   Нужна, чтобы наносить урон от замерзания
                                       //
                                       //   КАК НАСТРОИТЬ:
                                       //   1. Выбрать объект Player в Hierarchy
                                       //   2. В Inspector найти компонент Temperature
                                       //   3. Найти поле "Health"
                                       //   4. Перетащить Player на это поле
                                       //   5. Unity сам найдёт компонент Health на Player!
                                       //
                                       //   СВЯЗЬ МОДУЛЕЙ:
                                       //   Temperature → Health (через Inspector)
                                       //   Temperature вызывает health.TakeDamage()

    public int playerDamage = 2;       // ← Урон от замерзания (каждые 2 секунды)

    // ═══════════════════════════════════════════════════════════════
    // ПЕРЕМЕННЫЕ ТЕМПЕРАТУРЫ
    // ═══════════════════════════════════════════════════════════════

    public float temperatureCurrent = 36.6f; // ← Текущая температура тела
                                             //   float = число с дробной частью
                                             //   36.6f - буква f означает "float число"
                                             //   36.6 градусов - нормальная температура человека

    public float temperatureNormal = 36.6f;  // ← Нормальная температура (цель согревания)

    public float temperatureCritical = 34f;  // ← Критическая температура (начинается урон)
                                             //   Если температура упадёт ниже 34° - начнётся урон

    public float freezeSpeed = 0.05f;  // ← Скорость замерзания (насколько быстро мёрзнем)
                                       //   0.05 градусов в секунду
                                       //   За 52 секунды упадёт с 36.6 до 34

    float freezeDamageTimer = 1;       // ← Таймер урона (обратный отсчёт)
                                       //   float без public = не видно в Inspector
                                       //   Используется внутри скрипта для отсчёта времени

    public float freezeDamageDelay = 2; // ← Задержка между уроном (каждые 2 секунды)

    // ═══════════════════════════════════════════════════════════════
    // МЕТОД UPDATE: ЗАМЕРЗАНИЕ И УРОН
    // ═══════════════════════════════════════════════════════════════

    void Update()                      // ← Вызывается каждый кадр
    {

        // ───────────────────────────────────────────────────────────
        // ПОСТОЯННОЕ ЗАМЕРЗАНИЕ
        // ───────────────────────────────────────────────────────────

        temperatureCurrent -= freezeSpeed * Time.deltaTime;
        // ↑                 ↑  ↑            ↑ ↑
        // │                 │  │            │ └─ Время между кадрами (0.016 при 60 FPS)
        // │                 │  │            └─ Умножаем на скорость замерзания
        // │                 │  └─ freezeSpeed = 0.05 (градусов в секунду)
        // │                 └─ -= означает "отнять и присвоить"
        // └─ temperatureCurrent = текущая температура
        //
        // Что происходит:
        // Каждый кадр температура немного падает
        // freezeSpeed * Time.deltaTime = 0.05 * 0.016 = 0.0008 градусов за кадр
        // За 1 секунду (60 кадров): 0.0008 * 60 = 0.048 ≈ 0.05 градусов
        //
        // Пример:
        // Начало: temperatureCurrent = 36.6
        // Через 10 секунд: 36.6 - (0.05 * 10) = 36.1
        // Через 52 секунды: 36.6 - (0.05 * 52) = 34.0 (критическая!)

        // ───────────────────────────────────────────────────────────
        // ПРОВЕРКА: ТЕМПЕРАТУРА НИЖЕ КРИТИЧЕСКОЙ?
        // ───────────────────────────────────────────────────────────

        if (temperatureCurrent <= temperatureCritical) // ← Если температура <= 34°
        {                                //   <= означает "меньше или равно"

            // Температура критическая → начинаем наносить урон

            // ───────────────────────────────────────────────────────
            // ТАЙМЕР УРОНА (каждые 2 секунды)
            // ───────────────────────────────────────────────────────

            if (freezeDamageTimer <= 0)  // ← Если таймер дошёл до нуля
            {                            //   Пришло время нанести урон!

                // НАНЕСЕНИЕ УРОНА ЧЕРЕЗ МОДУЛЬ HEALTH

                health.TakeDamage(playerDamage);
                // ↑     ↑          ↑
                // │     │          └─ playerDamage = 2 (урон от замерзания)
                // │     └─ TakeDamage = метод из модуля Health
                // └─ health = ссылка на модуль Health (перетащили в Inspector)
                //
                // Говорим модулю Health: "Нанеси 2 урона!"
                // Health сам отнимет здоровье, проиграет звук, проверит смерть
                //
                // СВЯЗЬ МОДУЛЕЙ:
                // Temperature не знает КАК работает Health
                // Temperature просто говорит: "Нанеси урон"
                // Это модульность!

                freezeDamageTimer += freezeDamageDelay;
                // ↑                ↑  ↑
                // │                │  └─ freezeDamageDelay = 2 (секунды)
                // │                └─ += означает "прибавить"
                // └─ Сбрасываем таймер на 2 секунды
                //
                // Пример:
                // Было: freezeDamageTimer = 0
                // Стало: freezeDamageTimer = 2
                // Через 2 секунды таймер снова дойдёт до 0
                // И мы снова нанесём урон
            }
            else                         // ← Иначе (таймер ещё не дошёл до нуля)
            {

                freezeDamageTimer -= Time.deltaTime;
                // ↑                ↑  ↑
                // │                │  └─ Время между кадрами (0.016)
                // │                └─ -= означает "отнять"
                // └─ Уменьшаем таймер
                //
                // Каждый кадр отнимаем время от таймера
                // freezeDamageTimer = 2.0
                // Через 1 кадр: 2.0 - 0.016 = 1.984
                // Через 2 секунды (120 кадров): 2.0 - (0.016 * 120) = 0
                // Таймер дошёл до нуля → нанесём урон!
            }
        }
    }

} // ← Конец класса Temperature