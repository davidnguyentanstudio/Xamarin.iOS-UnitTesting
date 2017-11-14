using System;
namespace TableView.Models
{
    public enum Gender
    {
        Male, Female, Unspecific
    }

    public static class GenderExtension {
        public static string ToString(this Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return "Male";
                case Gender.Female:
                    return "Female";
                default:
                    return "Unspecific";
            }
        }
    }
        
}
