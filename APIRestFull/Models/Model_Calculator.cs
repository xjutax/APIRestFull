namespace APIRestFull.Models
{
    public class Input_Calculator
    {
        public int Memoria { get; set; }
        public string Usuario { get; set; }
    }

    public class Model_Calculator
    {
        public int Id { get; set; }
        public int Memoria { get; set; }
        public string Usuario { get; set; }
    }

    public class Dto_Calculator
    {        
        public int Memoria { get; set; }
        public string Usuario { get; set; }
    }
}
