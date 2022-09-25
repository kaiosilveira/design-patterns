# House of the future

Mediator:

ClockEvents.TICK:

- sprinkler.checkTime ✅
- alarm.checkTime ✅
- display.setCurrentTime ✅
- display.render (shows current time + upcoming events + alarm schedule) ✅

WeatherMonitor.TEMPERATURE_CHANGED:

- Display.SetCurrentTemperature ✅

Calendar.NEW_UPCOMING_EVENT:

- Display.AppendUpcomingEvent

AlarmEvents.ALARM_TRIGGERED:

- CoffeePot.startBrewing ✅
- Display.displayTemperature ✅
- Display.displayGoodMorningMessage

CoffeePotEvents.COFFEE_READY:

- Display.notifyCoffeeReady
