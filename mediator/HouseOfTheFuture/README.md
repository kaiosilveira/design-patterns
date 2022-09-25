# House of the future

Mediator:

ClockEvents.TICK:

- sprinkler.checkTime
- alarm.checkTime

WeatherMonitor.TEMPERATURE_CHANGED:

- Display.SetCurrentTemperature

Calendar.NEW_UPCOMING_EVENT:

- Display.AppendUpcomingEvent

AlarmEvents.ALARM_TRIGGERED:

- CoffeePot.startBrewing
- Display.displayUpcomingEvents
- Display.displayTemperature
- Bath.warmUp

CoffeePotEvents.COFFEE_READY:

- Display.notifyCoffeeReady
