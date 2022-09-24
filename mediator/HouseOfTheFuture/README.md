# House of the future

Mediator:

CalendarEvents.TICK:

- sprinkler.checkTime
- alarm.checkTime

AlarmEvents.ALARM_TRIGGERED:

- CoffeePot.startBrewing
- Display.displayUpcomingEvents
- Display.displayTemperature
- Bath.warmUp

CoffeePotEvents.COFFEE_READY:

- Display.notifyCoffeeReady