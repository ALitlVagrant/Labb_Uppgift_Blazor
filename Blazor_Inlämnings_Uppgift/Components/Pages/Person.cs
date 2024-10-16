using System.ComponentModel.Design;

namespace Luhn_SSN;

public class Person
{
    private string FirstName { get; }
    private string LastName { get;}
    private string SSN { get; }

    private string Gender {get; set;}


    //Konstruktor
    public Person(string firstName, string lastName, string ssn)
    {
        FirstName = firstName;
        LastName = lastName; 
        //Personnummer i string
        SSN = ssn;
        
    }
    
    //Metod som använder luhn algoritmen för att avgöra om det är ett riktigt persnmr
    public bool IsValidSsn()
    {
        
        List<int> numbers = new List<int>();
        
        foreach (char i in SSN)
        {
            numbers.Add(int.Parse(i.ToString()));
        }

        int kontrollsiffra = numbers[9];
        numbers.RemoveAt(9);


        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 == 0)
            {
                numbers[i] *= 2;

                if (numbers[i] > 9)
                {
                    var tiotal = numbers[i] / 10;
                    
                    var mindretal = numbers[i] % 10;
                    
                    numbers[i] = mindretal + tiotal; //summera talen om de är över 9
                }
            }
            
        }
        int totalsumma = numbers.Sum();
        totalsumma += kontrollsiffra;

        if (totalsumma % 10 == 0)
        {
            
            Console.WriteLine($"{SSN} is valid ssn:");
            return true;
        }
        else
        {
            Console.WriteLine($"{SSN} is not valid ssn.");
            return false;
        }
       
    }
    public void GenderCheck()
    {
        List<int> intList = new List<int>();

        foreach (char i in SSN)
        {
            intList.Add(int.Parse(i.ToString()));
        }

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