🚧 **This repository is a work in progress at the moment, feel free to look around but please don't expect it to be understandable at this point** 🚧

# House of the future

## Roadmap

Remaining refactorings and missing things:

- Make mediator readonly in concrete widget classes
- Rename mediator to WidgetHub
- Document widget class hierarchy
- Introduce ClockDependentWidget interface as a subinterface of Widget
- Document console app structure and background processes implementation to handle inputs in a non-blocking fashion
- Pull down private methods inside ConcreteMediator

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
