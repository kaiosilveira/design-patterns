using BoolExParser.Domain.Language.Contexts;

namespace BoolExParser.Domain.Language.Expressions;

public interface BooleanExp
{
  public bool Evaluate(Context context);
  public BooleanExp Replace(char name, BooleanExp exp);
  public BooleanExp Copy();
  public string GetName();
}