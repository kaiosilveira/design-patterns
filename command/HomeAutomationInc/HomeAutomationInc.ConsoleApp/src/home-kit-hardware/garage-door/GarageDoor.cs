namespace HomeAutomationInc.Hardware;

public class GarageDoor
{
  public bool IsOpen { get; private set; }
  public void Up()
  {
    this.IsOpen = true;
  }

  public void Down()
  {
    this.IsOpen = false;
  }
}