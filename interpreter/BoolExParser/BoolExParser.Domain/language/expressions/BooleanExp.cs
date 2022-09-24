namespace BoolExParser.Domain;

public interface BooleanExp
{
  public bool Evaluate(Context context);
  public BooleanExp Replace(char name, BooleanExp exp);
  public BooleanExp Copy();
}