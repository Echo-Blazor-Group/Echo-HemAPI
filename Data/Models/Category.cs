namespace Echo_HemAPI.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        public string EstateCategory { get; set; }

        public List<Estate> Estate { get; set; }
    }



    /*
 
        Bostadsrättslägenhet

        Bostadsrättsradhus

        Villa

        Fritidshus

     */
}
