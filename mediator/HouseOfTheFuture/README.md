🚧 **This repository is a work in progress at the moment, feel free to look around but please don't expect it to be understandable at this point** 🚧

# House of the future

## Roadmap

Remaining refactorings and missing things:

- Pull down private methods inside ConcreteMediator
- Introduce ClockDependentWidget interface as a subinterface of Widget
- Document widget class hierarchy
- Document console app structure and background processes implementation to handle inputs in a non-blocking fashion

Mediator events:

ClockEvents.TICK:

- sprinkler.checkTime ✅
- alarm.checkTime ✅
- display.setCurrentTime ✅
- display.render (shows current time + upcoming events + alarm schedule) ✅

WeatherMonitor.TEMPERATURE_CHANGED:

- Display.SetCurrentTemperature ✅

Calendar.NEW_UPCOMING_EVENT:

- Display.AppendUpcomingEvent ✅

AlarmEvents.ALARM_TRIGGERED:

- CoffeePot.startBrewing ✅
- Display.displayTemperature ✅
- Display.displayGoodMorningMessage

CoffeePotEvents.COFFEE_READY:

- Display.notifyCoffeeReady ✅
