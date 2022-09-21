using Xunit;
using Moq;
using MightyGumballMailing.Domain.Handlers;
using MightyGumballMailing.Domain.Entities;
using MightyGumballMailing.Domain.Enumerators;
using MightyGumballMailing.Domain.Services;

namespace MightyGumballMailing.DomainTests;

public class FanMailHandlerTest
{
  [Fact]
  public void TestHandlesFanEmail()
  {
    var mockedMailSvc = new Mock<MailService>();
    var mockedSuccessorMailHandler = new Mock<MailHandler>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.FAN,
      subject: "Best platform ever!",
      body: "Hello, I've been using your product for a while and I think it's really amazing!"
    );

    var handler = new FanMailHandler(
      mailService: mockedMailSvc.Object,
      successor: mockedSuccessorMailHandler.Object
    );

    handler.HandleIncomingEmail(email);

    mockedMailSvc.Verify(instance => instance.ForwardToCEO(email), Times.Once());
  }

  [Fact]
  public void TestDoesNothingIfEmailTypeIsNotFanAndThereIsNoSuccessor()
  {
    var mockedMailSvc = new Mock<MailService>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.UNKNOWN,
      subject: "Candidate application - Sr Software Engineer",
      body: "Hello, I would like to apply to the senior software engineer role"
    );

    var handler = new FanMailHandler(mailService: mockedMailSvc.Object, successor: null);

    handler.HandleIncomingEmail(email);
  }

  [Fact]
  public void TestDelegatesHandlingToSuccessorIfMailTypeIsNotFan()
  {
    var mockedMailSvc = new Mock<MailService>();
    var mockedSuccessorMailHandler = new Mock<MailHandler>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.UNKNOWN,
      subject: "Candidate application - Sr Software Engineer",
      body: "Hello, I would like to apply to the senior software engineer role"
    );

    var handler = new FanMailHandler(
      mailService: mockedMailSvc.Object,
      successor: mockedSuccessorMailHandler.Object
    );

    handler.HandleIncomingEmail(email);

    mockedSuccessorMailHandler.Verify(instance => instance.HandleIncomingEmail(email), Times.Once());
  }
}