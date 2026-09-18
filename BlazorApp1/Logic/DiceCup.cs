namespace Logic;

public class DiceCup
{
    private List<Dice> dices;

    public DiceCup(int antalTerninger)
    {
        dices = new();
        for (int i = 0; i < antalTerninger; i++)
            dices.Add(new Dice(6));
    }

    public void Shake()
    {
        foreach (Dice d in dices)
            d.Roll();
    }

    public int[] Eyes()
    {
        int[] result = new int[dices.Count];
        for (int i = 0; i < dices.Count; i++)
            result[i] = dices[i].GetEyes();
        Array.Sort(result);
            
        return result;
    }

    public int Count => dices.Count;
}