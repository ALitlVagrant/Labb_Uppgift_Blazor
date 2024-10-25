
namespace Blazor_Inlämnings_Uppgift;

public class Person
{
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Ssn { get;  set; }

    public string Gender {get;  set;}


    //Konstruktor
    public Person(string firstName, string lastName, string ssn)
    {
        FirstName = firstName;
        LastName = lastName; 
        //Personnummer i string
        Ssn = ssn;
        
        
    }
    
    //Metod som använder luhn algoritmen för att avgöra om det är ett riktigt persnmr
    public bool IsValidSsn()
    {
        
        //Skapar int lista
        List<int> numbers = new List<int>();
        
        //För varje char i inuti Ssn, lägg till i numbers lista + convert
        foreach (char i in Ssn)
        {
            numbers.Add(int.Parse(i.ToString()));
        }
        
        //Skapar upp variabel kontrollsiffra som är på index plats 9
        int kontrollsiffra = numbers[9];
        //tar bort kontrollsiffra från listan eftersom den inte får vara med i algoritmen.
        numbers.RemoveAt(9);

        //Loopar igenom alla element i listan, 
        for (int i = 0; i < numbers.Count; i++)
        {
            //utför operationer på jämna index positioner som tex 0, 2 ,6
            if (i % 2 == 0)
            {
                //multiplicerar dom jämna index pos med 2 enligt luhn algo
                numbers[i] *= 2;
                
                //Om nummret blir större än 9 efter det multiplicerats separera och summera
                if (numbers[i] > 9)
                {
                    var tiotal = numbers[i] / 10;
                    
                    var mindretal = numbers[i] % 10;
                    
                    numbers[i] = mindretal + tiotal; //summera talen om de är över 9
                }
            }
            
        }
        //skapar upp variabel totalsumma som får tilldelat värde på hela numbers listan summerad.
        int totalsumma = numbers.Sum();
        
        //summerar in kontrollsiffra 
        totalsumma += kontrollsiffra;
        
        //Om den totala summan på numbers listan är jämnt delbart med 10 så är det ett gilltigt personnummer enligt Luhn algo
        if (totalsumma % 10 == 0)
        {
            
            Console.WriteLine($"{Ssn} is valid ssn:");
            return true;
        }
        else
        {
            Console.WriteLine($"{Ssn} is not valid ssn.");
            return false;
        }
       
    }
    public void GenderCheck()
    {
        List<int> intList = new List<int>();

        foreach (char i in Ssn)
        {
            intList.Add(int.Parse(i.ToString()));
        }
        
        //Om  index 8 är ett jämnt tal så är Gender = "Kvinna"
        if (intList[8] % 2 == 0)
        {
            Gender = "Kvinna";
        }
        else
        {
            Gender = "Man";
        }
    }
    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public string GetGender()
    {
        return Gender;
    }
}