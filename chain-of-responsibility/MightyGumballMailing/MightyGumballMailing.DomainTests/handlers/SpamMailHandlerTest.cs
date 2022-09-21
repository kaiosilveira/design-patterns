using Xunit;
using Moq;
using MightyGumballMailing.Domain.Handlers;
using MightyGumballMailing.Domain.Entities;
using MightyGumballMailing.Domain.Enumerators;
using MightyGumballMailing.Domain.Services;

namespace MightyGumballMailing.DomainTests;

public class SpamMailHandlerTest
{
  [Fact]
  public void TestHandlesSpamEmail()
  {
    var mockedMailSvc = new Mock<MailService>();
    var mockedSuccessorMailHandler = new Mock<MailHandler>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.SPAM,
      subject: "You've just won the lottery",
      body: "Congrats on winning the lottery, Mr. Lucky!"
    );

    var handler = new SpamMailHandler(
      mailService: mockedMailSvc.Object,
      successor: mockedSuccessorMailHandler.Object
    );

    handler.HandleIncomingEmail(email);

    mockedMailSvc.Verify(instance => instance.MoveToJunk(email.Id), Times.Once());
  }

  [Fact]
  public void TestDelegatesHandlingToSuccessorIfMailTypeIsNotSpam()
  {
    var mockedMailSvc = new Mock<MailService>();
    var mockedSuccessorMailHandler = new Mock<MailHandler>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.UNKNOWN,
      subject: "Candidate application - Sr Software Engineer",
      body: "Hello, I would like to apply to the senior software engineer role"
    );

    var handler = new SpamMailHandler(
      mailService: mockedMailSvc.Object,
      successor: mockedSuccessorMailHandler.Object
    );

    handler.HandleIncomingEmail(email);

    mockedSuccessorMailHandler.Verify(instance => instance.HandleIncomingEmail(email), Times.Once());
  }
}