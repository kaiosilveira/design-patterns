🚧 **This repository is a work in progress at the moment, feel free to look around but please don't expect it to be understandable at this point** 🚧

# House of the future

- WidgetHub class hierarchy and interactions:

```mermaid
classDiagram

class WidgetHub {
    void RegisterEvent(ApplcationEvent e)
}

class ConcreteWidgetHub {
    List widgets
    void RegisterEvent(ApplcationEvent e)
}

class Widget {
    WidgetType GetWidgetType()
}


<<interface>> WidgetHub
<<interface>> Widget

WidgetHub <|-- ConcreteWidgetHub : implements
ConcreteWidgetHub --> Widget : has-a-list-of
```

- Widget class hierarchy:

```mermaid
classDiagram

class Widget {
    WidgetType GetWidgetType()
}

class ClockDependentWidget {
    WidgetType GetWidgetType()
    void CheckTime()
}

class Clock {
    WidgetType GetWidgetType()
    void Tick()
}

class CalendarEvent {
    DateTime At
    string Description
}

class Calendar {
    WidgetType GetWidgetType()
    void AddEvent(CalendarEvent e)
}

class WeatherMonitor {
    void SetTemperature(int temp)
    int GetCurrentTemperature()
}

class Display {
    void SetCurrentTemperature(int temp)
    string ShowCurrentTemperature()
    void AppendUpcomingEvent(DateTime at, string description)
    string ShowUpcomingEvents()
    string ShowGoodMorningMessage()
    void SetCurrentDateTime(DateTime dateTime)
    void Render()
    void NotifyCoffeeReady()
    WidgetType GetWidgetType()
}

<<interface>> Widget
<<interface>> ClockDependentWidget

Widget <|-- ClockDependentWidget : extends
Widget <|-- Clock : implements
Widget <|-- WeatherMonitor : implements
Widget <|-- Calendar : implements
Widget <|-- Display : implements
Calendar --> CalendarEvent : has-many
```

- Clock dependent widgets class hierarchy:

```mermaid
classDiagram

class Widget {
    WidgetType GetWidgetType()
}

class ClockDependentWidget {
    WidgetType GetWidgetType()
    void CheckTime()
}

class Alarm {
    WidgetType GetWidgetType()
    void CheckTime()
    string Describe()
    void SetSchedule(Schedule schedule)
}

class Sprinkler {
    WidgetType GetWidgetType()
    void CheckTime(DateTime time)
    string Describe()
    void SetSchedule(Schedule schedule)
}

class CoffeePot {
  WidgetType GetWidgetType()
  void CheckTime(DateTime time)
  void StartBrewing()
}

<<interface>> Widget
<<interface>> ClockDependentWidget

Widget <|-- ClockDependentWidget : extends
ClockDependentWidget <|-- Alarm : implements
ClockDependentWidget <|-- Sprinkler : implements
ClockDependentWidget <|-- CoffeePot : implements
```

## Roadmap

Remaining refactorings and missing things:

- Format notifications list in the console app
- Document console app structure and background processes implementation to handle inputs in a non-blocking fashion

AlarmEvents.ALARM_TRIGGERED:

- Display.ShowAlarmText
- Display.ShowGoodMorningMessage
