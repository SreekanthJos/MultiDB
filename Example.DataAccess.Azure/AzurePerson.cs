namespace Example.DataAccess.Azure
{
    public class AzurePerson
    {


        public int RowKey

        {
            get; set;
        }
        public int PatitionKey

        {
            get; set;
        }

        public string FirstName

        {
            get { return "Hello"; }
            set { value = "aa"; }
        }

        public string LastName

        {
            get; set;
        }

        public string Address

        {
            get; set;
        }
    }
}