
namespace StrategyPattern.Console
{
  using System;
  using PrototypePattern.Commands;
  using PrototypePattern.Documents;

  public class Program
  {
    public static void Main(string[] args)
    {
      var doc = new TextDocument("Kaio");
      var copyCmd = new CopyCommand(target: doc, startAt: 0, copyLength: 4);
      copyCmd.Execute();

      var pasteCmd = new PasteCommand(
        target: doc,
        contentToPaste: copyCmd.Buffer,
        pastePosition: doc.GetContents().Length
      );

      Console.WriteLine(doc.GetContents()); // output: Kaio
      pasteCmd.Execute();
      Console.WriteLine(doc.GetContents()); // output: KaioKaio
    }
  }
}